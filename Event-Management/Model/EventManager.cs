using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Model
{
    class EventManager
    {
        public ObservableCollection<Event> Events { get; private set; }

        public EventManager()
        {

        }

        public async Task<ObservableCollection<Event>> GetAllEvents()
        {
            var events = new ObservableCollection<Event>();
            var db = DatabaseManager.Instance;
            var query = "SELECT event_id, event_name, event_type, category, description, event_date, start_time, end_time, venue_name, street_address, city, state_province, maximum_capacity, current_registrations  FROM events";

            try
            {
                using (var command = db.CreateCommand(query))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var eventItem = new Event
                        {
                            event_id = Convert.ToInt32(reader["event_id"]),
                            event_name = reader["event_name"] == DBNull.Value ? "" : reader["event_name"].ToString(),
                            event_type = reader["event_type"] == DBNull.Value ? "" : reader["event_type"].ToString(),
                            category = reader["category"] == DBNull.Value ? "" : reader["category"].ToString(),
                            description = reader["description"] == DBNull.Value ? "" : reader["description"].ToString(),
                            event_date = Convert.ToDateTime(reader["event_date"]),
                            start_time = (TimeSpan)(reader["start_time"]),
                            end_time = (TimeSpan)(reader["end_time"]),
                            venue_name = reader["venue_name"] == DBNull.Value ? "" : reader["venue_name"].ToString(),
                            street_address = reader["street_address"] == DBNull.Value ? "" : reader["street_address"].ToString(),
                            city = reader["city"] == DBNull.Value ? "" : reader["city"].ToString(),
                            state_province = reader["state_province"] == DBNull.Value ? "" : reader["state_province"].ToString(),
                            maximum_capacity = Convert.ToInt32(reader["maximum_capacity"]),
                            current_registrations = Convert.ToInt32(reader["current_registrations"]),
                            phone_number = reader["phone_number"] == DBNull.Value ? "" : reader["phone_number"].ToString(),
                            email = reader["email"] == DBNull.Value ? "" : reader["email"].ToString(),
                            event_web = reader["event_web"] == DBNull.Value ? "" : reader["event_web"].ToString(),
                            regular_price = Convert.ToDecimal(reader["regular_price"]),
                            early_bird_price = Convert.ToDecimal(reader["early_bird_price"]),
                            vip_price = Convert.ToDecimal(reader["vip_price"]),
                            is_free_event = Convert.ToBoolean(reader["is_free_event"])
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

        public async Task<bool> AddEvent(Event eventItem)
        {
            var db = DatabaseManager.Instance;
            var query = "INSERT INTO events (event_name, event_type, category, description, event_date, start_time, end_time, " +
                        "venue_name, street_address, city, state_province, maximum_capacity, current_registrations, " +
                        "phone_number, email, event_web, regular_price, early_bird_price, vip_price, is_free_event) " +
                        "VALUES (@EventName, @EventType, @Category, @Description, @EventDate, @StartTime, @EndTime, " +
                        "@VenueName, @StreetAddress, @City, @StateProvince, @MaximumCapacity, @CurrentRegistrations, " +
                        "@OrgContact, @OrgEmail, @OrgWeb, @RegularPrice, @EarlyBirdPrice, @VipPrice, @IsFreeEvent)";
            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@EventName", eventItem.event_name ?? "");
                    command.Parameters.AddWithValue("@EventType", eventItem.event_type ?? "");
                    command.Parameters.AddWithValue("@Category", eventItem.category ?? "");
                    command.Parameters.AddWithValue("@Description", eventItem.description ?? "");
                    command.Parameters.AddWithValue("@EventDate", eventItem.event_date);
                    command.Parameters.AddWithValue("@StartTime", eventItem.start_time);
                    command.Parameters.AddWithValue("@EndTime", eventItem.end_time);
                    command.Parameters.AddWithValue("@VenueName", eventItem.venue_name ?? "");
                    command.Parameters.AddWithValue("@StreetAddress", eventItem.street_address ?? "");
                    command.Parameters.AddWithValue("@City", eventItem.city ?? "");
                    command.Parameters.AddWithValue("@StateProvince", eventItem.state_province ?? "");
                    command.Parameters.AddWithValue("@MaximumCapacity", eventItem.maximum_capacity);
                    command.Parameters.AddWithValue("@CurrentRegistrations", eventItem.current_registrations);
                    command.Parameters.AddWithValue("@OrgContact", eventItem.phone_number ?? "");
                    command.Parameters.AddWithValue("@OrgEmail", eventItem.email ?? "");
                    command.Parameters.AddWithValue("@OrgWeb", eventItem.event_web ?? "");
                    command.Parameters.AddWithValue("@RegularPrice", eventItem.regular_price);
                    command.Parameters.AddWithValue("@EarlyBirdPrice", eventItem.early_bird_price);
                    command.Parameters.AddWithValue("@VipPrice", eventItem.vip_price);
                    command.Parameters.AddWithValue("@IsFreeEvent", eventItem.is_free_event);

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
            var query = "DELETE FROM Events WHERE event_id = @EventId";

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
                                event_id = Convert.ToInt32(reader["event_id"]),
                                event_name = reader["event_name"] == DBNull.Value ? "" : reader["event_name"].ToString(),
                                event_type = reader["event_type"] == DBNull.Value ? "" : reader["event_type"].ToString(),
                                category = reader["category"] == DBNull.Value ? "" : reader["category"].ToString(),
                                description = reader["description"] == DBNull.Value ? "" : reader["description"].ToString(),
                                event_date = Convert.ToDateTime(reader["event_date"]),
                                start_time = (TimeSpan)(reader["start_time"]),
                                end_time = (TimeSpan)(reader["end_time"]),
                                venue_name = reader["venue_name"] == DBNull.Value ? "" : reader["venue_name"].ToString(),
                                street_address = reader["street_address"] == DBNull.Value ? "" : reader["street_address"].ToString(),
                                city = reader["city"] == DBNull.Value ? "" : reader["city"].ToString(),
                                state_province = reader["state_province"] == DBNull.Value ? "" : reader["state_province"].ToString(),
                                maximum_capacity = Convert.ToInt32(reader["maximum_capacity"]),
                                current_registrations = Convert.ToInt32(reader["current_registrations"]),
                                phone_number = reader["phone_number"] == DBNull.Value ? "" : reader["phone_number"].ToString(),
                                email = reader["email"] == DBNull.Value ? "" : reader["email"].ToString(),
                                event_web = reader["event_web"] == DBNull.Value ? "" : reader["event_web"].ToString(),
                                regular_price = Convert.ToDecimal(reader["regular_price"]),
                                early_bird_price = Convert.ToDecimal(reader["early_bird_price"]),
                                vip_price = Convert.ToDecimal(reader["vip_price"]),
                                is_free_event = Convert.ToBoolean(reader["is_free_event"])
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

        public async Task<int> GetTotalEventCount()
        {
            var db = DatabaseManager.Instance;
            var query = "SELECT COUNT(*) FROM events";

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
            var query = "SELECT COUNT(*) FROM events WHERE event_date >= @Today";

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
            var query = "SELECT SUM(current_registrations) FROM events";

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
            var query = "SELECT SUM(regular_price * current_registrations) AS TotalBudget FROM events";

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
