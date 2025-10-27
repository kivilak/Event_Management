using System.Collections.ObjectModel;

namespace Event_Management.Model
{
    class GuestManager
    {
        public ObservableCollection<Guest> Guests { get; private set; }

        public GuestManager()
        {

        }

        public async Task<ObservableCollection<Guest>> GetAllGuests()       // return all the guests
        {
            var guests = new ObservableCollection<Guest>();
            var db = DatabaseManager.Instance;
            //var query = "SELECT * FROM Guest";
            var query = "SELECT GuestId, Name, Email, Phone, Category, RsvpStatus, Dietary, CheckedIn, EventId " +
                "FROM Guest";

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

        public async Task<bool> AddGuest(Guest guest)
        {
            var db = DatabaseManager.Instance;
            var query = "INSERT INTO Guest(Name, Email, Phone, Category, RsvpStatus, Dietary, CheckedIn, EventId)" +
                "VALUES(@Name, @Email, @Phone, @Category, @RsvpStatus, @Dietary, @CheckedIn, @EventId)";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@Name", guest.Name ?? "");
                    command.Parameters.AddWithValue("@Email", guest.Email ?? "");
                    command.Parameters.AddWithValue("@Phone", guest.Phone ?? "");
                    command.Parameters.AddWithValue("@Category", guest.Category ?? "");
                    command.Parameters.AddWithValue("@RsvpStatus", guest.RsvpStatus ?? "");
                    command.Parameters.AddWithValue("@Dietary", guest.Dietary ?? "");
                    command.Parameters.AddWithValue("@CheckedIn", guest.CheckedIn);
                    command.Parameters.AddWithValue("@EventId", guest.EventId);

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

        public async Task<bool> DeleteGuest(int guestId)
        {
            var db = DatabaseManager.Instance;
            var query = "DELETE FROM Guest WHERE GuestId = @GuestId";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@GuestId", guestId);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting guest: {ex.Message}");
                return false;
            }
        }
    }
}
