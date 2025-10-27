using System;
using System.Windows;
using System.Collections.ObjectModel;
using Event_Management.TestingModel;
using Event = Event_Management.TestingModel.Event;
using Event_Management.ViewModel;
using Task = Event_Management.TestingModel.Task;



namespace Event_Management.View.window
{

    public partial class AddTask : Window
    {
        public AddTask(ObservableCollection<Task> tasks, Event eventParam, int? taskId = null)
        {
            InitializeComponent();
            var viewModel = new AddTaskViewModel(tasks, eventParam, taskId);
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }
    }
}
