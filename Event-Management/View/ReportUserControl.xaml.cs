using System.Windows;
using System.Windows.Controls;
using Event_Management.Model;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ExportPDF_Click(object sender, RoutedEventArgs e)
        {
            //ExportToPdf();
        }

        // In your controller or main method
        public void ExportToPdf()
        {
            var generator = new PDFGenerator();
            string filePath = "C:\\Users\\User\\Desktop\\People.pdf";

            //generator.Generate(filePath);

            Console.WriteLine($"PDF created at: {filePath}");
        }
    }
}
