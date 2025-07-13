using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Event_Management.ViewModel;
using Event_Management.TestingModel;
using Event_Management.View.window; 

namespace Event_Management.View
{

    public partial class EventUserController : UserControl
    {
        private ObservableCollection<Event> allEvents; 
        private ObservableCollection<Event> filteredEvents;

        private string selectedStatus = "All Status";
        private string selectedType = "All Types";
        private string searchText = string.Empty;


        public EventUserController()
        {
            InitializeComponent();
            var eventViewModel = new EventViewModel();
            DataContext = eventViewModel;
        }

     
        public void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEvent addEventWindow = new AddEvent();
            addEventWindow.ShowDialog();
        }

    }

}
