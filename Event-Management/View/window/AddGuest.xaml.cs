using System;
using System.Collections.ObjectModel;
using System.Windows;
using Event_Management.TestingModel;
using Event = Event_Management.TestingModel.Event;
using Event_Management.ViewModel;

namespace Event_Management.View.window
{

    public partial class AddGuest : Window
    {
        public AddGuest(ObservableCollection<Guest> guests, Event eventParam, int? guestId = null)
        {
            InitializeComponent();
            var viewModel = new AddGuestViewModel(guests, eventParam, guestId);
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }
    }

}
