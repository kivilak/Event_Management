using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Event_Management.Commands;
using Event_Management.TestingModel;
using Event_Management.View;

namespace Event_Management.ViewModel
{
    class EventViewModel : INotifyPropertyChanged
    {
        // Full event list
        private ObservableCollection<Event> allEvents;

        // Filtered event list bound to UI
        private ObservableCollection<Event> _events;
        public ObservableCollection<Event> Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

        // Summary data
        public int TotalEventCount { get; set; }
        public int UpcomingEventCount { get; set; }
        public int TotalGuests { get; set; }
        public double TotalBudget { get; set; }

        // Filter properties
        private string _selectedStatus = "All Status";
        public string[] StatusList { get; set; } = { "All Status", "Upcoming", "Planning", "Confirmed", "Completed" };

        public string[] TypeList { get; set; } = { "All Types", "Conference", "Launch", "Corporate", "Fundraiser", "Festival", "Social" };



        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                OnPropertyChanged(nameof(SelectedStatus));
                ApplyFilters();
            }
        }

        private string _selectedType = "All Types";
        public string SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
                ApplyFilters();
            }
        }

        private string _searchQuery = string.Empty;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                ApplyFilters();
            }
        }

        // Commands

        public ICommand ViewGuestsCommand { get; }
        public ICommand ViewTasksCommand { get; }

        // Constructor
        public EventViewModel()
        {
            allEvents = Event_Management.TestingModel.EventManager.GetEvents();
            Events = new ObservableCollection<Event>(allEvents);

            TotalEventCount = Event_Management.TestingModel.EventManager.GetTotalEventCount();
            UpcomingEventCount = Event_Management.TestingModel.EventManager.GetTotalUpcomingEventCount();
            TotalGuests = Event_Management.TestingModel.EventManager.GetTotalGuest();
            TotalBudget = Event_Management.TestingModel. EventManager.getTotalBudget();


            ViewGuestsCommand = new RelayCommand(OnViewGuests);
            ViewTasksCommand = new RelayCommand(OnViewTasks);

        }

        // Handle View Guests
        private void OnViewGuests(object parameter)
        {
            if (parameter is Event selectedEvent)
            {
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.NavigateToEventDetails(selectedEvent);
                }
            }
        }

        // Handle View Tasks
        private void OnViewTasks(object parameter)
        {
            if (parameter is Event selectedEvent)
            {
                MessageBox.Show($"{selectedEvent.Name} from Tasks button", "Task Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Filtering logic
        private void ApplyFilters()
        {
            var filtered = allEvents.AsEnumerable();

            if (SelectedStatus != "All Status") {
                filtered = filtered.Where(ev => ev.Status == SelectedStatus);
            }
                

            if (SelectedType != "All Types")
                filtered = filtered.Where(ev => ev.Type == SelectedType);

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                string query = SearchQuery.ToLower();
                filtered = filtered.Where(ev =>
                    (!string.IsNullOrEmpty(ev.Name) && ev.Name.ToLower().Contains(query)) ||
                    (!string.IsNullOrEmpty(ev.Location) && ev.Location.ToLower().Contains(query))
                );
            }

            Events.Clear();
            foreach (var ev in filtered)
                Events.Add(ev);
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
