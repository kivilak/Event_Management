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
        private readonly Guest _selectedGuest;
        private GuestManager guestManager;

        public AddGuestViewModel(ObservableCollection<Guest> guests, Event eventParam, int? guestId)
        {
            _guests = guests;
            _event = eventParam;
            _guestId = guestId;
            this.guestManager = new GuestManager();

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
                    //JobTitle = _selectedGuest.JobTitle;
                }
            }
        }

        public ObservableCollection<string> CategoryOptions { get; }
        public ObservableCollection<string> RsvpStatusOptions { get; }

        private string _firstName, _lastName, _email, _phone, _category, _rsvpStatus, _jobTitle;

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Phone
        {
            get => _phone;
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }

        public string Category
        {
            get => _category;
            set { _category = value; OnPropertyChanged(nameof(Category)); }
        }

        public string RsvpStatus
        {
            get => _rsvpStatus;
            set { _rsvpStatus = value; OnPropertyChanged(nameof(RsvpStatus)); }
        }

        public string JobTitle
        {
            get => _jobTitle;
            set { _jobTitle = value; OnPropertyChanged(nameof(JobTitle)); }
        }
        public string EventName => _event?.Name ?? "Unknown Event";
        public string EventDate => _event?.DateTime != null ? DateTime.Parse(_event.DateTime).ToString("M/d/yyyy") : "N/A";
        public string EventLocation => _event?.Location ?? "Unknown Location";

        public string EventType => _event?.Type ?? "Unknown Catagory";


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

            if (_guestId.HasValue)
                _guests.Remove(_selectedGuest);

            Guest guest = new Guest
            {
                GuestId = guestId,
                Name = $"{FirstName} {LastName}",
                Email = Email,
                Phone = Phone,
                Category = Category,
                RsvpStatus = RsvpStatus,
                //JobTitle = JobTitle,
                EventId = _event.Id,
                Dietary = "Vegetarian",
                CheckedIn = _guestId.HasValue ? _selectedGuest.CheckedIn : false
            };

            //_guests.Add(guest);
            bool check = await guestManager.AddGuest(guest);
            MessageBox.Show("Guest saved successfully. " + Category + " / " + RsvpStatus);
            CloseAction?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
