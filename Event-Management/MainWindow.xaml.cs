using Event_Management.TestingModel;
//using Event_Management.Model;
using Event_Management.View;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Event_Management
{
    public partial class MainWindow : Window
    {
        private Button _activeButton;
        private ContentControl _mainContentArea;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize active navigation button and content area
            _activeButton = DashboardNavigation;
            _mainContentArea = MainContentArea ?? throw new NullReferenceException("MainContentArea not found in XAML.");

            // Load initial content (optional)
            // LoadGuestsView();

            var db = DatabaseManager.Instance;
            var query = "SELECT * FROM Guest";
            string text = string.Empty; 

            using (var command = db.CreateCommand(query))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                    Console.WriteLine(reader.GetString(1));
                    text = reader.GetString(1);
                }
            }

            
            testLabel.Content = text; 
        }

        // Handles sidebar button clicks
        public void NavigateToVeiw(object sender, RoutedEventArgs e)
        {
            if (sender is not Button clickedButton) return;

            SetActiveButton(clickedButton);

            switch (clickedButton.Name)
            {
                case "DashboardNavigation":
                    Console.WriteLine("Dashboard view clicked.");
                    // Add your dashboard loading logic here
                    break;

                case "EventsNavigation":
                    LoadEventsView();
                    break;

                case "GuestsNavigation":
                    LoadGuestsView();
                    break;

                case "BudgetsNavigation":
                    LoadBudgetView();
                    break;

                case "ReportsNavigation":
                    LoadReportView();
                    break;
            }
        }

        // Loads GuestsUserControl and subscribes to event selection
        private void LoadGuestsView()
        {
            var guestsControl = new GuestsUserControl();
            guestsControl.EventSelected += NavigateToEventDetails;
            _mainContentArea.Content = guestsControl;
        }

        // Loads EventUserControl
        private void LoadEventsView()
        {
            var eventControl = new EventUserController();
            _mainContentArea.Content = eventControl;
        }

        //Loads BudgetsUserContrl
        private void LoadBudgetView()
        {
            var budgetControl = new BudgetsUserControl();
            _mainContentArea.Content = budgetControl;
        }

        // Loads ReportUserControl
        private void LoadReportView()
        {
            var reportControl = new ReportUserControl();
            _mainContentArea.Content = reportControl;
        }

        // Called when a row is clicked in GuestsUserControl
        public void NavigateToEventDetails(Event selectedEvent)
        {
            var detailsControl = new EventDetailsUserControl(selectedEvent);
            _mainContentArea.Content = detailsControl;
        }

        // Handles button styling for active state
        private void SetActiveButton(Button newActiveButton)
        {
            if (_activeButton != null)
                _activeButton.Style = (Style)FindResource("NavigationButton");

            _activeButton = newActiveButton;
            _activeButton.Style = (Style)FindResource("ActiveNavigationButton");
        }

        // Navigate to the Guest window in many places
        public void NavigateToGuestsView()
        {
            var guestsControl = new GuestsUserControl();
            guestsControl.EventSelected += NavigateToEventDetails;
            _mainContentArea.Content = guestsControl;
        }
    }
}
