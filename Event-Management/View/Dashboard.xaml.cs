using Event_Management.TestingModel;
using Event_Management.View.window;
using Event_Management.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Event_Management.View
{
    public partial class Dashboard : UserControl
    {
        // Optional callback to notify parent window when an event is selected
        internal Action<Event> EventSelected;

        public Dashboard()
        {
            InitializeComponent();
            DataContext = new EventViewModel();
        }

        public void AddEventBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEvent addEventWindow = new AddEvent();
            addEventWindow.ShowDialog();
        }
    }
}
