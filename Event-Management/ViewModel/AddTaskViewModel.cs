using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Event_Management.Commands;
using Event_Management.TestingModel;
using Task = Event_Management.TestingModel.Task;

namespace Event_Management.ViewModel
{
    public class AddTaskViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<Task> _tasks;
        private readonly Event _event;
        private readonly int? _taskId;
        private Task _selectedTask;
        private TaskManager taskManager;

        public AddTaskViewModel(ObservableCollection<Task> tasks, Event eventParam, int? taskId)
        {
            _tasks = tasks;
            _event = eventParam;
            _taskId = taskId;
            taskManager = new TaskManager();

            SaveCommand = new RelayCommand(SaveTask);

            // Populate dropdowns
            CategoryOptions = new ObservableCollection<string>
            {
                "Venue & Location", "Catering & Food", "Entertainment", "Marketing", "Logistics", "Guest Management", "Technology", "Budget & Finance"
            };

            StatusOptions = new ObservableCollection<string>
            {
                "To Do", "In Progress", "Completed"
            };

            PriorityOptions = new ObservableCollection<string>
            {
                "Low", "Medium", "High"
            };

            // If editing existing guest
            if (_taskId.HasValue)
            {
                _selectedTask = _tasks.FirstOrDefault(g => g.TaskId == _taskId.Value);
                if (_selectedTask != null)
                {
                    Title = _selectedTask.Title;           
                    Category = _selectedTask.Category;
                    Description = _selectedTask.Description;
                    Status = _selectedTask.Status;
                    Priority = _selectedTask.Priority;
                }
            }
            else
            {
                // **Set default dropdown values for new guest**
                Category = CategoryOptions.FirstOrDefault();
                Status = StatusOptions.FirstOrDefault();
                Priority = PriorityOptions.FirstOrDefault();
            }
        }

        // Dropdown collections
        public ObservableCollection<string> CategoryOptions { get; }
        public ObservableCollection<string> StatusOptions { get; }
        public ObservableCollection<string> PriorityOptions { get; }

        // Task fields
        private string _title, _description, _category, _status, _priority;

       
        public string Title { get => _title; set { _title = value; OnPropertyChanged(nameof(Title)); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged(nameof(Description)); } }
        public string Category { get => _category; set { _category = value; OnPropertyChanged(nameof(Category)); } }
        public string Status { get => _status; set { _status = value; OnPropertyChanged(nameof(Status)); } }
        public string Priority { get => _priority; set { _priority = value; OnPropertyChanged(nameof(Priority)); } }

        // Event info
        public string EventName => _event?.Name ?? "Unknown Event";
        public string EventDate => _event?.DateTime != null ? DateTime.Parse(_event.DateTime).ToString("M/d/yyyy") : "N/A";
        public string EventLocation => _event?.Location ?? "Unknown Location";
        public string EventType => _event?.Type ?? "Unknown Category";

        public ICommand SaveCommand { get; }
        public Action CloseAction { get; set; }

        private async void SaveTask(object obj)
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                MessageBox.Show("Please enter Title.");
                return;
            }

            int taskId = _taskId ?? (_tasks.Any() ? _tasks.Max(g => g.TaskId) + 1 : 1);

            if (_taskId.HasValue && _selectedTask != null)
                _tasks.Remove(_selectedTask);

            Task task = new Task
            {
                TaskId = taskId,          
                Description = Description,
                Category = Category,
                Status = Status,
                Priority = Priority,
                EventId = _event.Id,
                CheckedIn = _taskId.HasValue ? _selectedTask?.CheckedIn ?? false : false
            };

            bool check = await taskManager.AddTask(task);
            MessageBox.Show("Task saved successfully. " + Category + " / " + Status);
            CloseAction?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
