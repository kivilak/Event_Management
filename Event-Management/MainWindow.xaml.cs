using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Event_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button _activeButton;
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("AAAA");
            _activeButton = DashboardNavigation;
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