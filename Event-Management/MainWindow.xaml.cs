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
            Console.WriteLine("AAAA");

            _activeButton = DashboardNavigation;
            _mainContentArea = MainContentArea ?? throw new NullReferenceException("MainContentArea not found in XAML.");
        }

        public void NavigateToVeiw(object sender, RoutedEventArgs e)
        {
            Button? clickedButton = sender as Button;
            if (clickedButton == null) return;

            SetActiveButton(clickedButton);

            switch (clickedButton.Name)
            {
                case "DashboardNavigation":
                    Console.WriteLine("Dashboard");
                    break;
                case "EventsNavigation":
                    Console.WriteLine("Events");
                    break;
                case "GuestsNavigation":
                    _mainContentArea.Content = new GuestsUserControl();
                    break;
            }
        }

        private void SetActiveButton(Button newActiveButton)
        {
            if (_activeButton != null)
            {
                _activeButton.Style = (Style)FindResource("NavigationButton");
            }

            _activeButton = newActiveButton;
            _activeButton.Style = (Style)FindResource("ActiveNavigationButton");
        }
    }
}
