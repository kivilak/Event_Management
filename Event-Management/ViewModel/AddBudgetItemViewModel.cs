//using Event_Management.ModelManager;
using Event_Management.TestingModel;
using Event_Management.View.ReportWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.ViewModel
{
    internal class AddBudgetItemViewModel
    {
        public BudgetSummary Summary;
        public BudgetManager _budgetManager;
        public string EventName;
        public  AddBudgetItemViewModel(TestingModel.Event selectedEvent)
        {
            _budgetManager = new BudgetManager(selectedEvent);
            Summary = _budgetManager.GetSummary(selectedEvent.Name);
            EventName = selectedEvent.Name;
        }

    }
}
