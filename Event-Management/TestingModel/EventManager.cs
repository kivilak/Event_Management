using Event_Management.Model;
using System;
using System.Collections.ObjectModel;
using Event_Management.TestingModel;

namespace Event_Management.TestingModel

{
    public class EventManager
    {


        // Singleton instance
        private static EventManager _instance;
        public EventManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EventManager();
                return _instance;
            }
        }

        private EventManager() { }
        public async Task<ObservableCollection<Event>> GetAllEvents()
        {
            var events = new ObservableCollection<Event>();
            var db = DatabaseManager.Instance;
            var query = "SELECT * FROM Events";

            try
            {
                using (var command = db.CreateCommand(query))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var eventItem = new Event
                        {
                            EventName = reader["EventName"] == DBNull.Value ? "" : reader["EventName"].ToString(),
                            EventType = reader["EventType"] == DBNull.Value ? "" : reader["EventType"].ToString(),
                            Category = reader["Category"] == DBNull.Value ? "" : reader["Category"].ToString(),
                            Description = reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString(),
                            EventDate = Convert.ToDateTime(reader["EventDate"]),
                            StartTime = (TimeSpan)(reader["StartTime"]),
                            EndTime = (TimeSpan)(reader["EndTime"]),
                            VenueName = reader["VenueName"] == DBNull.Value ? "" : reader["VenueName"].ToString(),
                            StreetAddress = reader["StreetAddress"] == DBNull.Value ? "" : reader["StreetAddress"].ToString(),
                            City = reader["City"] == DBNull.Value ? "" : reader["City"].ToString(),
                            StateProvince = reader["StateProvince"] == DBNull.Value ? "" : reader["StateProvince"].ToString(),
                            MaximumCapacity = Convert.ToInt32(reader["MaximumCapacity"]),
                            CurrentRegistrations = Convert.ToInt32(reader["CurrentRegistrations"]),
                            OrgContact = reader["OrgContact"] == DBNull.Value ? "" : reader["OrgContact"].ToString(),
                            OrgEmail = reader["OrgEmail"] == DBNull.Value ? "" : reader["OrgEmail"].ToString(),
                            OrgWeb = reader["OrgWeb"] == DBNull.Value ? "" : reader["OrgWeb"].ToString(),
                            RegularPrice = Convert.ToDecimal(reader["RegularPrice"]),
                            EarlyBirdPrice = Convert.ToDecimal(reader["EarlyBirdPrice"]),
                            VipPrice = Convert.ToDecimal(reader["VipPrice"]),
                            IsFreeEvent = Convert.ToBoolean(reader["IsFreeEvent"])
                        };
                        events.Add(eventItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving events: {ex.Message}");
            }

            return events;
        }

        public async Task<bool> AddEvent(Task task)
        {
            var db = DatabaseManager.Instance;
            var query = "INSERT INTO Events(EventName, EventType, Category, Description, EventDate, StartTime, EndTime, VenueName, StreetAddress, City, StateProvince, MaximumCapacity, CurrentRegistrations, OrgContact, OrgEmail, OrgWeb, RegularPrice, EarlyBirdPrice, VipPrice, IsFreeEvent)" +
                "VALUES(@EventName, @EventType, @Category, @Description, @EventDate, @StartTime, @EndTime, @VenueName, @StreetAddress, @City, @StateProvince, @MaximumCapacity, @CurrentRegistrations, @OrgContact, @OrgEmail, @OrgWeb, @RegularPrice, @EarlyBirdPrice, @VipPrice, @IsFreeEvent)";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@Title", task.Title ?? "");
                    command.Parameters.AddWithValue("@Category", task.Category ?? "");
                    command.Parameters.AddWithValue("@Description", task.Description ?? "");
                    command.Parameters.AddWithValue("@Status", task.Status ?? "");
                    command.Parameters.AddWithValue("@Priority", task.Priority ?? "");
                    command.Parameters.AddWithValue("@CheckedIn", task.CheckedIn);
                    command.Parameters.AddWithValue("@EventId", task.EventId);


                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding guest: {ex.Message}");
                return false;
            }

        }

        public async Task<bool> AddEvent(Event eventItem)
        {
            var db = DatabaseManager.Instance;
            var query = "INSERT INTO Events (EventName, EventType, Category, Description, EventDate, StartTime, EndTime, " +
                        "VenueName, StreetAddress, City, StateProvince, MaximumCapacity, CurrentRegistrations, " +
                        "OrgContact, OrgEmail, OrgWeb, RegularPrice, EarlyBirdPrice, VipPrice, IsFreeEvent) " +
                        "VALUES (@EventName, @EventType, @Category, @Description, @EventDate, @StartTime, @EndTime, " +
                        "@VenueName, @StreetAddress, @City, @StateProvince, @MaximumCapacity, @CurrentRegistrations, " +
                        "@OrgContact, @OrgEmail, @OrgWeb, @RegularPrice, @EarlyBirdPrice, @VipPrice, @IsFreeEvent)";
            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@EventName", eventItem.EventName ?? "");
                    command.Parameters.AddWithValue("@EventType", eventItem.EventType ?? "");
                    command.Parameters.AddWithValue("@Category", eventItem.Category ?? "");
                    command.Parameters.AddWithValue("@Description", eventItem.Description ?? "");
                    command.Parameters.AddWithValue("@EventDate", eventItem.EventDate);
                    command.Parameters.AddWithValue("@StartTime", eventItem.StartTime);
                    command.Parameters.AddWithValue("@EndTime", eventItem.EndTime);
                    command.Parameters.AddWithValue("@VenueName", eventItem.VenueName ?? "");
                    command.Parameters.AddWithValue("@StreetAddress", eventItem.StreetAddress ?? "");
                    command.Parameters.AddWithValue("@City", eventItem.City ?? "");
                    command.Parameters.AddWithValue("@StateProvince", eventItem.StateProvince ?? "");
                    command.Parameters.AddWithValue("@MaximumCapacity", eventItem.MaximumCapacity);
                    command.Parameters.AddWithValue("@CurrentRegistrations", eventItem.CurrentRegistrations);
                    command.Parameters.AddWithValue("@OrgContact", eventItem.OrgContact ?? "");
                    command.Parameters.AddWithValue("@OrgEmail", eventItem.OrgEmail ?? "");
                    command.Parameters.AddWithValue("@OrgWeb", eventItem.OrgWeb ?? "");
                    command.Parameters.AddWithValue("@RegularPrice", eventItem.RegularPrice);
                    command.Parameters.AddWithValue("@EarlyBirdPrice", eventItem.EarlyBirdPrice);
                    command.Parameters.AddWithValue("@VipPrice", eventItem.VipPrice);
                    command.Parameters.AddWithValue("@IsFreeEvent", eventItem.IsFreeEvent);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding event: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            var db = DatabaseManager.Instance;
            var query = "DELETE FROM Events WHERE EventId = @EventId";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting event: {ex.Message}");
                return false;
            }
        }

        //public static void AddEvent(Event e)
        //{
        //    Events.Add(e);
        //}

        public async Task<Event> GetEventById(int eventId)
        {
            var db = DatabaseManager.Instance;
            var query = "SELECT * FROM Events WHERE EventId = @EventId";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Event
                            {
                                //EventId = Convert.ToInt32(reader["EventId"]),
                                EventName = reader["EventName"] == DBNull.Value ? "" : reader["EventName"].ToString(),
                                EventType = reader["EventType"] == DBNull.Value ? "" : reader["EventType"].ToString(),
                                Category = reader["Category"] == DBNull.Value ? "" : reader["Category"].ToString(),
                                Description = reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString(),
                                EventDate = Convert.ToDateTime(reader["EventDate"]),
                                StartTime = (TimeSpan)(reader["StartTime"]),
                                EndTime = (TimeSpan)(reader["EndTime"]),
                                VenueName = reader["VenueName"] == DBNull.Value ? "" : reader["VenueName"].ToString(),
                                StreetAddress = reader["StreetAddress"] == DBNull.Value ? "" : reader["StreetAddress"].ToString(),
                                City = reader["City"] == DBNull.Value ? "" : reader["City"].ToString(),
                                StateProvince = reader["StateProvince"] == DBNull.Value ? "" : reader["StateProvince"].ToString(),
                                MaximumCapacity = Convert.ToInt32(reader["MaximumCapacity"]),
                                CurrentRegistrations = Convert.ToInt32(reader["CurrentRegistrations"]),
                                OrgContact = reader["OrgContact"] == DBNull.Value ? "" : reader["OrgContact"].ToString(),
                                OrgEmail = reader["OrgEmail"] == DBNull.Value ? "" : reader["OrgEmail"].ToString(),
                                OrgWeb = reader["OrgWeb"] == DBNull.Value ? "" : reader["OrgWeb"].ToString(),
                                RegularPrice = Convert.ToDecimal(reader["RegularPrice"]),
                                EarlyBirdPrice = Convert.ToDecimal(reader["EarlyBirdPrice"]),
                                VipPrice = Convert.ToDecimal(reader["VipPrice"]),
                                IsFreeEvent = Convert.ToBoolean(reader["IsFreeEvent"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving event: {ex.Message}");
            }

            return null;
        }

        //methods for events summary

        public async Task<int> GetTotalEventCount()
        {
            var db = DatabaseManager.Instance;
            var query = "SELECT COUNT(*) FROM Events";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting total event count: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> GetTotalUpcomingEventCount()
        {
            var db = DatabaseManager.Instance;
            var query = "SELECT COUNT(*) FROM Events WHERE EventDate >= @Today";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@Today", DateTime.Today);
                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting upcoming event count: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> GetTotalGuests()
        {
            var db = DatabaseManager.Instance;
            var query = "SELECT SUM(CurrentRegistrations) FROM Events";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    var result = await command.ExecuteScalarAsync();
                    if (result == DBNull.Value || result == null)
                        return 0;
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting total guests: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> GetTotalBudget()
        {
            var db = DatabaseManager.Instance;
            var query = "SELECT SUM(RegularPrice * CurrentRegistrations) AS TotalBudget FROM Events";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    var result = await command.ExecuteScalarAsync();
                    if (result == DBNull.Value || result == null)
                        return 0.00;
                    return Convert.ToDouble(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting total budget: {ex.Message}");
                return 0.00;
            }
        }

    }
}
