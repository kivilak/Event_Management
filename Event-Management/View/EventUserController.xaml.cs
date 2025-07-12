using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Event_Management.ViewModel;
using Event_Management.TestingModel;

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

     

        
    }

}
