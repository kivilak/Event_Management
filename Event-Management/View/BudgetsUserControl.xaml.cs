using System.Windows.Controls;
using Event_Management.ViewModel;

namespace Event_Management.View
{
    public partial class BudgetsUserControl : UserControl
    {
        public BudgetsUserControl()
        {
            InitializeComponent();
            DataContext = new BudgetViewModel();
        }
    }
}
