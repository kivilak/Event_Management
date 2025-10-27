using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Event_Management.Commands;
using Event_Management.TestingModel;

namespace Event_Management.ViewModel
{
    public class AddGuestViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<Guest> _guests;
        private readonly Event _event;
        private readonly int? _guestId;
        private Guest _selectedGuest;
        private GuestManager guestManager;

        public AddGuestViewModel(ObservableCollection<Guest> guests, Event eventParam, int? guestId)
        {
            _guests = guests;
            _event = eventParam;
            _guestId = guestId;
            guestManager = new GuestManager();

            SaveCommand = new RelayCommand(SaveGuest);

            // Populate dropdowns
            CategoryOptions = new ObservableCollection<string>
            {
                "VIP", "Speaker", "Sponsor", "Media", "Staff", "General Attendee", "Family", "Plus One"
            };

            RsvpStatusOptions = new ObservableCollection<string>
            {
                "Pending", "Accepted", "Declined"
            };

            DietaryOption = new ObservableCollection<string>
            {
                "Vegetarian", "Non-Vegetarian"
            };

            // If editing existing guest
            if (_guestId.HasValue)
            {
                _selectedGuest = _guests.FirstOrDefault(g => g.GuestId == _guestId.Value);
                if (_selectedGuest != null)
                {
                    var names = _selectedGuest.Name.Split(' ');
                    FirstName = names.FirstOrDefault();
                    LastName = string.Join(" ", names.Skip(1));
                    Email = _selectedGuest.Email;
                    Phone = _selectedGuest.Phone;
                    Category = _selectedGuest.Category;
                    RsvpStatus = _selectedGuest.RsvpStatus;
                    Dietary = _selectedGuest.Dietary;
                }
            }
            else
            {
                // **Set default dropdown values for new guest**
                Category = CategoryOptions.FirstOrDefault();
                RsvpStatus = RsvpStatusOptions.FirstOrDefault();
                Dietary = DietaryOption.FirstOrDefault();
            }
        }

        // Dropdown collections
        public ObservableCollection<string> CategoryOptions { get; }
        public ObservableCollection<string> RsvpStatusOptions { get; }
        public ObservableCollection<string> DietaryOption { get; }

        // Guest fields
        private string _firstName, _lastName, _email, _phone, _category, _rsvpStatus, _dietary;

        public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(nameof(FirstName)); } }
        public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(nameof(LastName)); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); } }
        public string Phone { get => _phone; set { _phone = value; OnPropertyChanged(nameof(Phone)); } }
        public string Category { get => _category; set { _category = value; OnPropertyChanged(nameof(Category)); } }
        public string RsvpStatus { get => _rsvpStatus; set { _rsvpStatus = value; OnPropertyChanged(nameof(RsvpStatus)); } }
        public string Dietary { get => _dietary; set { _dietary = value; OnPropertyChanged(nameof(Dietary)); } }

        // Event info
        public string EventName => _event?.EventName ?? "Unknown Event";
        public string EventDate => _event?.EventDate != default(DateTime)
           ? _event.EventDate.ToString("M/d/yyyy")
           : "N/A";
        public string EventLocation => _event?.VenueName ?? "Unknown Location";
        public string EventType => _event?.EventType ?? "Unknown Category";

        public ICommand SaveCommand { get; }
        public Action CloseAction { get; set; }

        private async void SaveGuest(object obj)
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
            {
                MessageBox.Show("Please enter First Name and Last Name.");
                return;
            }

            int guestId = _guestId ?? (_guests.Any() ? _guests.Max(g => g.GuestId) + 1 : 1);

            if (_guestId.HasValue && _selectedGuest != null)
                _guests.Remove(_selectedGuest);

            Guest guest = new Guest
            {
                GuestId = guestId,
                Name = $"{FirstName} {LastName}",
                Email = Email,
                Phone = Phone,
                Category = Category,
                RsvpStatus = RsvpStatus,
                Dietary = Dietary,
                EventId = _event.Id,
                CheckedIn = _guestId.HasValue ? _selectedGuest?.CheckedIn ?? false : false
            };

            bool check = await guestManager.AddGuest(guest);
            MessageBox.Show("Guest saved successfully. " + Category + " / " + RsvpStatus);
            CloseAction?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
