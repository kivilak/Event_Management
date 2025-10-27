using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using Event_Management.Commands;

namespace Event_Management.ViewModel

{
    public class AddEventViewModel : INotifyPropertyChanged
    {
        // Basic Event Information
        private string eventName;
        public string EventName
        {
            get => eventName;
            set { eventName = value; OnPropertyChanged(nameof(EventName)); }
        }

        private string eventType;
        public string EventType
        {
            get => eventType;
            set { eventType = value; OnPropertyChanged(nameof(EventType)); }
        }

        private string category;
        public string Category
        {
            get => category;
            set { category = value; OnPropertyChanged(nameof(Category)); }
        }

        private string tags;
        public string Tags
        {
            get => tags;
            set { tags = value; OnPropertyChanged(nameof(Tags)); }
        }

        private string description;
        public string Description
        {
            get => description;
            set { description = value; OnPropertyChanged(nameof(Description)); }
        }

        // Date & Time
        private DateTime? eventDate = DateTime.Today;
        public DateTime? EventDate
        {
            get => eventDate;
            set { eventDate = value; OnPropertyChanged(nameof(EventDate)); }
        }

        private TimeSpan startTime;
        public TimeSpan StartTime
        {
            get => startTime;
            set { startTime = value; OnPropertyChanged(nameof(StartTime)); }
        }

        private TimeSpan endTime;
        public TimeSpan EndTime
        {
            get => endTime;
            set { endTime = value; OnPropertyChanged(nameof(EndTime)); }
        }

        // Venue
        private string venueName;
        public string VenueName
        {
            get => venueName;
            set { venueName = value; OnPropertyChanged(nameof(VenueName)); }
        }

        private string street;
        public string Street
        {
            get => street;
            set { street = value; OnPropertyChanged(nameof(Street)); }
        }

        private string city;
        public string City
        {
            get => city;
            set { city = value; OnPropertyChanged(nameof(City)); }
        }

        private string state;
        public string State
        {
            get => state;
            set { state = value; OnPropertyChanged(nameof(State)); }
        }

        // Capacity
        private int maximumCapacity;
        public int MaximumCapacity
        {
            get => maximumCapacity;
            set { maximumCapacity = value; OnPropertyChanged(nameof(MaximumCapacity)); }
        }

        private int currentRegistrations = 0;
        public int CurrentRegistrations
        {
            get => currentRegistrations;
            set { currentRegistrations = value; OnPropertyChanged(nameof(CurrentRegistrations)); }
        }

        private bool allowWaitlist;
        public bool AllowWaitlist
        {
            get => allowWaitlist;
            set { allowWaitlist = value; OnPropertyChanged(nameof(AllowWaitlist)); }
        }

        // Contact
        private string email;
        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }

        private string website;
        public string Website
        {
            get => website;
            set { website = value; OnPropertyChanged(nameof(Website)); }
        }

        private string phone;
        public string Phone
        {
            get => phone;
            set { phone = value; OnPropertyChanged(nameof(Phone)); }
        }

        // Pricing
        private decimal regularPrice;
        public decimal RegularPrice
        {
            get => regularPrice;
            set { regularPrice = value; OnPropertyChanged(nameof(RegularPrice)); }
        }

        private decimal earlyBirdPrice;
        public decimal EarlyBirdPrice
        {
            get => earlyBirdPrice;
            set { earlyBirdPrice = value; OnPropertyChanged(nameof(EarlyBirdPrice)); }
        }

        private decimal vipPrice;
        public decimal VipPrice
        {
            get => vipPrice;
            set { vipPrice = value; OnPropertyChanged(nameof(VipPrice)); }
        }

        private bool isFreeEvent;
        public bool IsFreeEvent
        {
            get => isFreeEvent;
            set { isFreeEvent = value; OnPropertyChanged(nameof(IsFreeEvent)); }
        }

        // Helper property to check if event has capacity
        public bool HasAvailableCapacity => CurrentRegistrations < MaximumCapacity;

        // Helper property to get remaining capacity
        public int RemainingCapacity => MaximumCapacity - CurrentRegistrations;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        // Commands
        public RelayCommand SaveCommand { get; }
        public RelayCommand ClearCommand { get; }


        public AddEventViewModel()
        {
            SaveCommand = new RelayCommand(_=>Save());
            ClearCommand = new RelayCommand(_=>Clear());
        }

        private static void Save()
        {
            //nedd to implement the logic to save the event details,call the method from EventManager class (addEvent mrthod)

            System.Windows.MessageBox.Show("Event Saved Successfully!", "Success");
        }

        public void Clear()
        {
            EventName = string.Empty;
            EventType = string.Empty;
            Category = string.Empty;
            Tags = string.Empty;
            Description = string.Empty;
            EventDate = null;
            StartTime = TimeSpan.Zero;
            EndTime = TimeSpan.Zero;
            VenueName = string.Empty;
            Street = string.Empty;
            City = string.Empty;
            State = string.Empty;
            MaximumCapacity = 0;
            CurrentRegistrations = 0;
            AllowWaitlist = false;
            Email = string.Empty;
            Website = string.Empty;
            Phone = string.Empty;
            RegularPrice = 0;
            EarlyBirdPrice = 0;
            VipPrice = 0;
            IsFreeEvent = false;
        }
    }
}
