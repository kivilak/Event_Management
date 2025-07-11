using Event_Management.TestingModel;
using Event_Management.View;
using System;
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

            // Load initial content
           // LoadGuestsView();
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
            }
        }

        // Loads GuestsUserControl and subscribes to event selection
        private void LoadGuestsView()
        {
            var guestsControl = new GuestsUserControl();
            guestsControl.EventSelected += NavigateToEventDetails;
            _mainContentArea.Content = guestsControl;
        }

        private void LoadEventsView()
        {

            var eventControl = new EventUserController();
            //guestsControl.EventSelected += NavigateToEventDetails;
            _mainContentArea.Content = eventControl;
        }

        // Called when a row is clicked in GuestsUserControl
        private void NavigateToEventDetails(Event selectedEvent)
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

        //Navigate to the Guest window in many places
        public void NavigateToGuestsView()
        {
            var guestsControl = new GuestsUserControl();
            guestsControl.EventSelected += NavigateToEventDetails;
            _mainContentArea.Content = guestsControl;
        }

    }
}
