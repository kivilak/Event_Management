using Event_Management.TestingModel;
using Event_Management.ViewModel;
using System.Windows.Controls;

namespace Event_Management.View
{
    /// <summary>
    /// Interaction logic for SpacificBudgetControl.xaml
    /// </summary>
    public partial class SpacificBudgetControl : UserControl
    {
        private TestingModel.Event selectedEvent;
        public SpacificBudgetControl(Event selectedEvent)
        {
            
            InitializeComponent();
            this.selectedEvent = selectedEvent ?? throw new ArgumentNullException(nameof(selectedEvent));
            DataContext = new BudgetViewModel(this.selectedEvent);
        }
    }
}
