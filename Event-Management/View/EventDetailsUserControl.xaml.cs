using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Event_Management.TestingModel;

namespace Event_Management.View
{
    public partial class EventDetailsUserControl : UserControl
    {
        private Event selectedEvent;

        public EventDetailsUserControl(Event selectedEvent)
        {
            InitializeComponent();
            this.DataContext = selectedEvent;
            this.selectedEvent = selectedEvent;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Get reference to the main window
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.NavigateToGuestsView();
            }
        }

    }
}
