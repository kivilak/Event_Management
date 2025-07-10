using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Event_Management.Model;
using Event_Management.TestingModel;
using Guest = Event_Management.TestingModel.Guest;
using Event = Event_Management.TestingModel.Event;

namespace Event_Management.View.window
{
    public partial class AddGuest : Window
    {
        private ObservableCollection<Guest> guests;
        private Event @event;

        public AddGuest(ObservableCollection<Guest> guests, Event eventParam)
        {
            InitializeComponent();
            this.guests = guests;
            this.@event = eventParam; // Fixed: was assigning Event instead of eventParam
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Read input values
            string firstName = FirstNameTextBox.Text.Trim();
            string lastName = LastNameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();
            string category = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string rsvp = (RsvpComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Validation
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("First Name and Last Name are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Generate new guest ID 
            int newGuestId = guests.Count > 0 ? guests.Max(g => g.GuestId) + 1 : 1;

            // Create Guest object
            Guest newGuest = new Guest
            {
                GuestId = newGuestId,
                Name = $"{firstName} {lastName}",
                Email = email,
                Phone = phone,
                Category = category,
                RsvpStatus = rsvp,
                Dietary = "Vegetarian", 
                CheckedIn = false,
                EventId = @event.Id 
            };

            
            guests.Add(newGuest);

            // Confirmation and close
            MessageBox.Show("Guest saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}