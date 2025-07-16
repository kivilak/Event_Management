using System.Collections.ObjectModel;

namespace Event_Management.TestingModel
{
    class GuestManager
    {
        public ObservableCollection<Guest> Guests { get; private set; }

        public GuestManager()
        {

        }

        public async Task<ObservableCollection<Guest>> GetAllGuests()
        {
            var guests = new ObservableCollection<Guest>();
            var db = DatabaseManager.Instance;
            var query = "SELECT * FROM Guest";

            try
            {
                using (var command = db.CreateCommand(query))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var guest = new Guest
                        {
                            GuestId = Convert.ToInt32(reader["GuestId"]),
                            Name = reader["Name"]?.ToString(),
                            Email = reader["Email"]?.ToString(),
                            Phone = reader["Phone"]?.ToString(),
                            Category = reader["Category"]?.ToString(),
                            RsvpStatus = reader["RsvpStatus"]?.ToString(),
                            Dietary = reader["Dietary"]?.ToString(),
                            CheckedIn = Convert.ToBoolean(reader["CheckedIn"]),
                            EventId = Convert.ToInt32(reader["EventId"])
                        };

                        guests.Add(guest);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving guests: {ex.Message}");
            }

            return guests;
        }
    }
}
