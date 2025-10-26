using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Event_Management.Model
{
    class TaskManager
    {
        public ObservableCollection<Task> Tasks { get; private set; }

        public TaskManager()
        {

        }

        public async Task<ObservableCollection<Task>> GetAllTasks()       // return all the guests
        {
            var tasks = new ObservableCollection<Task>();
            var db = DatabaseManager.Instance;
            var query = "SELECT * FROM Task";

            try
            {
                using (var command = db.CreateCommand(query))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var task = new Task
                        {
                            TaskId = Convert.ToInt32(reader["TaskId"]),
                            Title = reader["Title"]?.ToString(),
                            Category = reader["Category"]?.ToString(),
                            Description = reader["Description"]?.ToString(),
                            Status = reader["Status"]?.ToString(),
                            Priority = reader["Priority"]?.ToString(),
                            CheckedIn = Convert.ToBoolean(reader["CheckedIn"]),
                            EventId = Convert.ToInt32(reader["EventId"])
                        };

                        tasks.Add(task);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving tasks: {ex.Message}");
            }

            return tasks;
        }

        public async Task<bool> AddTask(Task task)
        {
            var db = DatabaseManager.Instance;
            var query = "INSERT INTO Task(Title, Category, Description, Status, Priority, CheckedIn, EventId)" +
                "VALUES(@Title, @Category, @Description, @Status, @Priority, @CheckedIn, @EventId)";

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

        public async Task<bool> DeleteTask(int taskId)
        {
            var db = DatabaseManager.Instance;
            var query = "DELETE FROM Task WHERE TaskId = @TaskId";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@TaskId", taskId);

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
