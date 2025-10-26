using System;
using System.Collections.Generic;
using System.Linq;
using Event_Management.Model;
using Event_Management.TestingModel;

namespace Event_Management.ModelManager
{
    public class BudgetManager
    {
        private readonly TestingModel.Event selectedEvent;

        //Default constructor (no specific event)
        public BudgetManager() { }

        //Constructor for a specific event
        public BudgetManager(TestingModel.Event selectedEvent)
        {
            this.selectedEvent = selectedEvent;
        }

        //Separate lists per event
        private readonly List<BudgetItem> techConferenceBudgets = new List<BudgetItem>
        {
            new BudgetItem { CategoryName = "Venue", Event = "Tech Expo 2025", Estimated = 15000, Actual = 14500 },
            new BudgetItem { CategoryName = "Catering", Event = "Tech Expo 2025", Estimated = 8000, Actual = 8500 },
            new BudgetItem { CategoryName = "Decorations", Event = "Tech Expo 2025", Estimated = 2500, Actual = 2500 }
        };

        private readonly List<BudgetItem> weddingBudgets = new List<BudgetItem>
        {
            new BudgetItem { CategoryName = "Venue", Event = "Wedding", Estimated = 12000, Actual = 11800 },
            new BudgetItem { CategoryName = "Catering", Event = "Wedding", Estimated = 10000, Actual = 10200 },
            new BudgetItem { CategoryName = "Decorations", Event = "Wedding", Estimated = 4000, Actual = 4200 }
        };

        private readonly List<BudgetItem> charityGalaBudgets = new List<BudgetItem>
        {
            new BudgetItem { CategoryName = "Venue", Event = "Charity Gala", Estimated = 9000, Actual = 8500 },
            new BudgetItem { CategoryName = "Entertainment", Event = "Charity Gala", Estimated = 4000, Actual = 3800 },
            new BudgetItem { CategoryName = "Logistics", Event = "Charity Gala", Estimated = 3000, Actual = 3100 }
        };

        //Combine all budgets into one list
        public List<BudgetItem> GetBudgetItems()
        {
            return techConferenceBudgets
                .Concat(weddingBudgets)
                .Concat(charityGalaBudgets)
                .ToList();
        }

        //Get budget items for specific event
        public List<BudgetItem> GetSpecificBudgetItems(string? eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName))
                return new List<BudgetItem>();

            return GetBudgetItems()
                .Where(item => string.Equals(item.Event, eventName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // get budget items for the selected event 
        public List<BudgetItem> GetSpecificBudgetItems()
        {
            if (selectedEvent == null)
                return new List<BudgetItem>();

            return GetBudgetItems()
                .Where(item => string.Equals(item.Event, selectedEvent.Name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        //Summary for a specific event (by event name)
        public BudgetSummary GetSummary(string eventName)
        {
            var items = GetSpecificBudgetItems(eventName);

            decimal total = items.Sum(i => i.Estimated);
            decimal spent = items.Sum(i => i.Actual);
            int overBudgetItems = items.Count(i => i.Actual > i.Estimated);

            return new BudgetSummary
            {
                TotalBudget = total,
                Spent = spent,
                OverBudgetItems = overBudgetItems
            };
        }

        // Summary for the selected event
        public BudgetSummary GetSummary()
        {
            if (selectedEvent == null)
                return GetOverallSummary(); 

            var items = GetSpecificBudgetItems();
            decimal total = items.Sum(i => i.Estimated);
            decimal spent = items.Sum(i => i.Actual);
            int overBudgetItems = items.Count(i => i.Actual > i.Estimated);

            return new BudgetSummary
            {
                TotalBudget = total,
                Spent = spent,
                OverBudgetItems = overBudgetItems
            };
        }

        // Overall summary
        public BudgetSummary GetOverallSummary()
        {
            var all = GetBudgetItems();
            decimal total = all.Sum(i => i.Estimated);
            decimal spent = all.Sum(i => i.Actual);
            int overBudgetItems = all.Count(i => i.Actual > i.Estimated);

            return new BudgetSummary
            {
                TotalBudget = total,
                Spent = spent,
                OverBudgetItems = overBudgetItems
            };
        }

        
        public List<string> GetEventNames()
        {
            return GetBudgetItems()
                .Select(b => b.Event)
                .Distinct()
                .OrderBy(name => name)
                .ToList();
        }
    }
}
