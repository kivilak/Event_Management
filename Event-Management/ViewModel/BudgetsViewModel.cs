using Event_Management.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BudgetManager = Event_Management.Model.BudgetManager;
using BudgetSummary = Event_Management.Model.BudgetSummary;

namespace Event_Management.ViewModel
{
    public class BudgetViewModel : INotifyPropertyChanged
    {
        private readonly BudgetManager _budgetManager;

        public BudgetSummary Summary { get; set; }
        public ObservableCollection<Budget> BudgetItems { get; set; }

        public string EventName { get; set; }

        public BudgetViewModel()
        {
            _budgetManager = new BudgetManager();
            //LoadBudgetData();

            BudgetItems = new ObservableCollection<Budget>();
            LoadBudgetDataAsync();
        }

        private async void LoadBudgetDataAsync()
        {
            BudgetItems = await _budgetManager.GetAllBudgets();
            OnPropertyChanged(nameof(BudgetItems));
        }

        private void LoadBudgetData(TestingModel.Event selectedEvent)
        {
            Summary = _budgetManager.GetSummary(selectedEvent.Name);
            BudgetItems = new ObservableCollection<BudgetItem>(_budgetManager.GetSpecificBudgetItems());
            EventName = selectedEvent.Name;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsHighUtilization => Summary.PercentageOfSpent >= 90;

        public string WarningMessage =>
            Summary.PercentageOfSpent >= 100 ?
                "Critical: You have exceeded your total budget!" :
            Summary.PercentageOfSpent >= 90 ?
                "Warning: Budget utilization is high. Consider reviewing expenses." :
                string.Empty;

    }
}
