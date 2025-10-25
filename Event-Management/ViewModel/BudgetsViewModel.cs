using System.Collections.ObjectModel;
using System.ComponentModel;
using Event_Management.Model;
using Event_Management.ModelManager;
using Event_Management.TestingModel;

namespace Event_Management.ViewModel
{
    public class BudgetViewModel : INotifyPropertyChanged
    {
        private readonly BudgetManager _budgetManager;

        public BudgetSummary Summary { get; set; }
        public ObservableCollection<BudgetItem> BudgetItems { get; set; }

        public BudgetViewModel()
        {
            _budgetManager = new BudgetManager();
            LoadBudgetData();
        }

        private void LoadBudgetData()
        {
            Summary = _budgetManager.GetSummary();
            BudgetItems = new ObservableCollection<BudgetItem>(_budgetManager.GetBudgetItems());
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
