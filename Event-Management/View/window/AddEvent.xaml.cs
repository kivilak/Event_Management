using System.Windows;
using Event_Management.ViewModel;
using Event_Management.TestingModel;



namespace Event_Management.View.window
{

    public partial class AddEvent : Window
    {
   
        public AddEvent()
        {
            InitializeComponent();
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            DataContext = addEventViewModel;
        }
  
    }
}
