using System.Collections.ObjectModel;

namespace Event_Management.Model
{
    public class ReportsManager
    {
        public IObservable<EventSummary> Events { get; set; }

        public ReportsManager() { }

        public async Task<ObservableCollection<EventSummary>> GetAllEventSummary()
        {
            var events = new ObservableCollection<EventSummary>();
            var db = DatabaseManager.Instance;

            var query = "SELECT e.event_name, e.status, " +
                "COUNT(DISTINCT g.GuestId) AS Guests, " +
                "SUM(b.Estimated) AS Budget, " +
                "SUM(b.Actual) AS Spent " +
                "FROM events e " +
                "LEFT JOIN Guest g ON e.event_id = g.EventId " +
                "LEFT JOIN Budget b ON e.event_id = b.EventId " +
                "GROUP BY e.event_id, e.event_name, e.status " +
                "ORDER BY e.event_id";

            try
            {
                using (var command = db.CreateCommand(query))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var eventSummary = new EventSummary
                        {
                            EventName = reader["event_name"]?.ToString(),
                            Status = reader["status"]?.ToString(),
                            Guests = reader["Guests"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Guests"]),
                            Budget = reader["Budget"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Budget"]),
                            Spent = reader["Spent"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Spent"])
                        };
                        
                        events.Add(eventSummary);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving event summary: {ex.Message}");
            }

            return events;
        }

        public async Task<ObservableCollection<GuestAttendance>> GetAllGuestAttendance()
        {
            var guestAttendances = new ObservableCollection<GuestAttendance>();
            var db = DatabaseManager.Instance;

            var query = "SELECT e.event_name, " +
                "COUNT(g.GuestId) AS Invited, " +
                "SUM(CASE WHEN g.RsvpStatus = 'confirmed' THEN 1 ELSE 0 END) AS Confirmed, " +
                "SUM(CASE WHEN g.RsvpStatus = 'declined' THEN 1 ELSE 0 END) AS Declined, " +
                "SUM(CASE WHEN g.RsvpStatus = 'pending' THEN 1 ELSE 0 END) AS Pending " +
                "FROM events e " +
                "LEFT JOIN Guest g ON e.event_id = g.EventId " +
                "GROUP BY e.event_id, e.event_name " +
                "ORDER BY e.event_id";

            try
            {
                using (var command = db.CreateCommand(query))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var guestAttendance = new GuestAttendance
                        {
                            EventName = reader["event_name"]?.ToString(),
                            Invited = reader["Invited"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Invited"]),
                            Confirmed = reader["Confirmed"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Confirmed"]),
                            Declined = reader["Declined"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Declined"]),
                            Pending = reader["Pending"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Pending"])
                        };

                        guestAttendances.Add(guestAttendance);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving guest attendance: {ex.Message}");
            }

            return guestAttendances;
        }
    }
}
