using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using Event_Management.Model;
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

        private string startTime;
        public string StartTime
        {
            get => startTime;
            set { startTime = value; OnPropertyChanged(nameof(StartTime)); }
        }

        private string endTime;
        public string EndTime
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

            // Populate dropdowns
            EventTypeOptions = new ObservableCollection<string>
            {
                "Conference", "Workshop", "Webinar", "Seminar", "Training", "Meeting", "Fundraiser"
            };

            EventType = EventTypeOptions[0];

        }

        // Task fields
        

        public ObservableCollection<string> EventTypeOptions { get; }

        private async void Save()
        {
            try
            {
                if (!TimeSpan.TryParse(StartTime, out TimeSpan parsedStartTime))
                {
                    System.Windows.MessageBox.Show("Invalid start time format. Please use hh:mm.", "Error");
                    return;
                }
                if (!TimeSpan.TryParse(EndTime, out TimeSpan parsedEndTime))
                {
                    System.Windows.MessageBox.Show("Invalid end time format. Please use hh:mm.", "Error");
                    return;
                }

                EventManager eventmananger = new EventManager();
                Event newEvent = new Event
                {
                    event_name = EventName,
                    event_type = EventType,
                    category = Category,
                    description = Description,
                    event_date = EventDate ?? DateTime.Today,
                    start_time = parsedStartTime,
                    end_time = parsedEndTime,
                    venue_name = VenueName,
                    street_address = Street,
                    city = City,
                    state_province = State,
                    maximum_capacity = MaximumCapacity,
                    current_registrations = CurrentRegistrations,
                    email = Email,
                    event_web = Website,
                    phone_number = Phone,
                    regular_price = RegularPrice,
                    early_bird_price = EarlyBirdPrice,
                    vip_price = VipPrice,
                    is_free_event = IsFreeEvent
                };

                newEvent.SetTagsFromString(Tags);

                bool check = await eventmananger.AddEvent(newEvent);
                if (check)
                {
                    System.Windows.MessageBox.Show("Event Saved Successfully!", "Success");
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to save the event.", "Error");
                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        private void Clear()
        {
            EventName = string.Empty;
            EventType = string.Empty;
            Category = string.Empty;
            Tags = string.Empty;
            Description = string.Empty;
            EventDate = null;
            StartTime = string.Empty;
            EndTime = string.Empty;
            VenueName = string.Empty;
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
            System.Windows.MessageBox.Show("Clear the form", "Success");
        }
    }
}
