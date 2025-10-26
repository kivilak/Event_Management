using System.Collections.Generic;
using Event_Management.Model;
using Event_Management.TestingModel;

namespace Event_Management.TestingModel
{
    public class BudgetManager
    {
        public BudgetSummary GetSummary()
        {
            // Simulated data — you can later replace with DB query
            return new BudgetSummary
            {
                TotalBudget = 45000,
                Spent = 42500,
                OverBudgetItems = 2
            };
        }

        public List<BudgetItem> GetBudgetItems()
        {
            return new List<BudgetItem>
            {
                new BudgetItem { CategoryName = "Venue", Event = "Tech Conference 2024", Estimated = 15000, Actual = 14500 },
                new BudgetItem { CategoryName = "Catering", Event = "Tech Conference 2024", Estimated = 8000, Actual = 8500 },
                new BudgetItem { CategoryName = "Decorations", Event = "Tech Conference 2024", Estimated = 2500, Actual = 2500 }
            };
        }
    }
}
