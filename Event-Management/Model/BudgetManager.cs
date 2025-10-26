using Event_Management.TestingModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Model
{
    public class BudgetManager
    {
        public ObservableCollection<Budget> Budgets { get; set; }

        public BudgetManager() { }

        public async Task<ObservableCollection<Budget>> GetAllBudgets()
        {
            var budgets = new ObservableCollection<Budget>();
            var db = DatabaseManager.Instance;
            var query = "SELECT * FROM Budget";
            //var query = "SELECT BudgetId, Category, Estimated, Actual, Difference, Status, EventId, Event FROM Budget, Event WHERE Budget.EventId = Event.EventId";

            try
            {
                using (var command = db.CreateCommand(query))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var budget = new Budget
                        {
                            BudgetId = Convert.ToInt32(reader["BudgetId"]),
                            Category = reader["Category"]?.ToString(),
                            Event = "Tech Conference 2024",
                            //Event = reader["Event"]?.ToString(),
                            Estimated = Convert.ToDouble(reader["Estimated"]),
                            Actual = Convert.ToDouble(reader["Actual"]),
                            EventId = Convert.ToInt32(reader["EventId"])
                        };

                        budgets.Add(budget);
                        Console.WriteLine(budget.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving budgets: {ex.Message}");
            }

            return budgets;
        }

        //public BudgetSummary GetSummary()
        //{
        //    // Simulated data — you can later replace with DB query
        //    return new BudgetSummary
        //    {
        //        TotalBudget = 45000,
        //        Spent = 42500,
        //        OverBudgetItems = 2
        //    };
        //}

        //Get Budget Summary by Event ID
        public async Task<BudgetSummary> GetSummaryByEventAsync(int eventId)
        {
            var db = DatabaseManager.Instance;
            var query = @"
                        SELECT 
                            SUM(Estimated) AS TotalBudget,
                            SUM(Actual) AS Spent,
                            SUM(CASE WHEN Actual > Estimated THEN 1 ELSE 0 END) AS OverBudgetItems,
                            (CASE WHEN SUM(Estimated) > 0 
                                  THEN (SUM(Actual) * 100.0 / SUM(Estimated)) 
                                  ELSE 0 END) AS PercentageOfSpent
                        FROM Budget
                        WHERE EventId = @EventId";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new BudgetSummary
                            {
                                TotalBudget = reader["TotalBudget"] != DBNull.Value ? Convert.ToDouble(reader["TotalBudget"]) : 0,
                                Spent = reader["Spent"] != DBNull.Value ? Convert.ToDouble(reader["Spent"]) : 0,
                                OverBudgetItems = reader["OverBudgetItems"] != DBNull.Value ? Convert.ToInt32(reader["OverBudgetItems"]) : 0,
                                //PercentageOfSpent = reader["PercentageOfSpent"] != DBNull.Value ? Convert.ToDouble(reader["PercentageOfSpent"]) : 0
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving budget summary: {ex.Message}");
            }

            return new BudgetSummary { TotalBudget = 0, Spent = 0, OverBudgetItems = 0};
        }

        //Get All Budget Summary
        public async Task<BudgetSummary> GetSummaryAsync()
        {
            var db = DatabaseManager.Instance;
            var query = @"
                    SELECT 
                        SUM(Estimated) AS TotalBudget,
                        SUM(Actual) AS Spent,
                        SUM(CASE WHEN Actual > Estimated THEN 1 ELSE 0 END) AS OverBudgetItems,
                        (CASE WHEN SUM(Estimated) > 0 
                              THEN (SUM(Actual) * 100.0 / SUM(Estimated)) 
                              ELSE 0 END) AS PercentageOfSpent
                    FROM Budget";

            try
            {
                using (var command = db.CreateCommand(query))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new BudgetSummary
                        {
                            TotalBudget = reader["TotalBudget"] != DBNull.Value ? Convert.ToDouble(reader["TotalBudget"]) : 0,
                            Spent = reader["Spent"] != DBNull.Value ? Convert.ToDouble(reader["Spent"]) : 0,
                            OverBudgetItems = reader["OverBudgetItems"] != DBNull.Value ? Convert.ToInt32(reader["OverBudgetItems"]) : 0,
                            //PercentageOfSpent = reader["PercentageOfSpent"] != DBNull.Value ? Convert.ToDouble(reader["PercentageOfSpent"]) : 0
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving budget summary: {ex.Message}");
            }

            return new BudgetSummary { TotalBudget = 0, Spent = 0, OverBudgetItems = 0 };
        }



        public async Task<bool> AddBudget(Budget budget)
        {
            var db = DatabaseManager.Instance;
            var query = "INSERT INTO Budget(Category, Estimated, Actual, Difference, Status, EventId) " +
                "VALUES(@Category, @Estimated, @Actual, @Difference, @Status, @EventId)";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@Category", budget.Category ?? "");
                    command.Parameters.AddWithValue("@Estimated", budget.Estimated);
                    command.Parameters.AddWithValue("@Actual", budget.Actual);
                    command.Parameters.AddWithValue("@Difference", budget.Difference);
                    command.Parameters.AddWithValue("@Status", budget.Status ?? "");
                    command.Parameters.AddWithValue("@EventId", budget.EventId);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error while adding budget: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteBudget(int budgetId)
        {
            var db = DatabaseManager.Instance;
            var query = "DELETE FROM Budget WHERE BudgetId = @BudgetId";

            try
            {
                using (var command = db.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@BudgetId", budgetId);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting budget: {ex.Message}");
                return false;
            }
        }
    }
}
