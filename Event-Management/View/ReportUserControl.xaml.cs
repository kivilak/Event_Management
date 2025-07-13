using System.Windows;
using System.Windows.Controls;
using Event_Management.View.ReportWindows;



namespace Event_Management.View
{
    /// <summary>
    /// Interaction logic for ReportUserControl.xaml
    /// </summary>
    public partial class ReportUserControl : UserControl
    {
        public ReportUserControl()
        {
            InitializeComponent();
            MainContent.Content = new EventSummary();
        }

        private void EventSummary_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new EventSummary();
        }

        private void GuestAttendance_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new GuestAttendance();
        }

        private void TaskProgress_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TaskProgress();
        }

        private void BudgetAnalysis_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new BudgetAnalysis();
        }
    }
}
