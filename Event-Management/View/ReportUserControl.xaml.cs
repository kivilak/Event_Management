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
        ReportsManager reportManager;
        public List<EventSummary> eventSummary = new List<EventSummary>();
        public List<GuestAttendance> guestAttendances = new List<GuestAttendance>();
        //{
        //    new EventSummary { EventName = "Tech Conference 2024", Status = "Upcoming", Guests = 500, Budget = 75000, Spent = 54000 },
        //    new EventSummary { EventName = "Product Launch", Status = "In Progress", Guests = 300, Budget = 35000, Spent = 28000 },
        //    new EventSummary { EventName = "Wedding Reception", Status = "Upcoming", Guests = 150, Budget = 40000, Spent = 15000 },
        //    new EventSummary { EventName = "Tech Conference 2024", Status = "Ongoing", Guests = 500, Budget = 75000, Spent = 54000 },
        //    new EventSummary { EventName = "Product Launch", Status = "Planning", Guests = 300, Budget = 35000, Spent = 28000 },
        //    new EventSummary { EventName = "Wedding Reception", Status = "Upcoming", Guests = 150, Budget = 40000, Spent = 15000 }
        //};
public ReportUserControl()
        {
            InitializeComponent();
            reportManager = new ReportsManager();
            
            Loaded += async (s, e) =>
            {
                eventSummary = await GetEventsSummary();
                guestAttendances = await GetGuestAttendances();
                MainContent.Content = new EventSummaryView(eventSummary);
            };
        }

        private void EventSummary_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new EventSummaryView(eventSummary);
        }

        private void GuestAttendance_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new GuestAttendanceView(guestAttendances);
        }

        private void TaskProgress_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TaskProgressView();
        }

        private void BudgetAnalysis_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new BudgetAnalysisView();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ExportPDF_Click(object sender, RoutedEventArgs e)
        {
            ExportToPdf();
        }

        
        public void ExportToPdf()
        {
            var generator = new PDFGenerator();
            string filePath = "C:\\Users\\User\\Desktop\\People.pdf";

            generator.Generate(filePath, eventSummary, guestAttendances);

            Console.WriteLine($"PDF created at: {filePath}");
        }

        private async Task<List<EventSummary>> GetEventsSummary()
        {
            var result = await reportManager.GetAllEventSummary();
            return [.. result];
        }

        private async Task<List<GuestAttendance>> GetGuestAttendances()
        {
            var result = await reportManager.GetAllGuestAttendance();
            return [.. result];
        }
    }
}
