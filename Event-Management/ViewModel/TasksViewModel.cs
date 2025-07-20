using Event_Management.TestingModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Event_Management.ViewModel
{
    public class TasksViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Event> Events { get; set; }
        public ICollectionView FilteredEvents { get; set; }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    FilteredEvents.Refresh();
                }
            }
        }

        private string _selectedType = "All Types";
        public string SelectedType
        {
            get => _selectedType;
            set
            {
                if (_selectedType != value)
                {
                    _selectedType = value;
                    OnPropertyChanged(nameof(SelectedType));
                    FilteredEvents.Refresh();
                }
            }
        }

        private string _selectedStatus = "All Status";
        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                if (_selectedStatus != value)
                {
                    _selectedStatus = value;
                    OnPropertyChanged(nameof(SelectedStatus));
                    FilteredEvents.Refresh();
                }
            }
        }

        public TasksViewModel()
        {
            Events = EventManager.GetEvents(); // Replace with your actual event source
            FilteredEvents = CollectionViewSource.GetDefaultView(Events);
            FilteredEvents.Filter = FilterEvents;
        }

        private bool FilterEvents(object obj)
        {
            if (obj is not Event evt)
                return false;

            // Search text filter
            bool matchesSearch = string.IsNullOrWhiteSpace(SearchQuery) ||
                                 evt.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                                 evt.Location.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase);

            // Type filter
            bool matchesType = SelectedType == "All Types" || evt.Type == SelectedType;

            // Status filter
            bool matchesStatus = SelectedStatus == "All Status" || evt.Status == SelectedStatus;

            return matchesSearch && matchesType && matchesStatus;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
