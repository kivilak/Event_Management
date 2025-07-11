using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Event_Management.TestingModel;
using Event_Management.View.window;

namespace Event_Management.View
{
    public partial class EventDetailsUserControl : UserControl
    {
        private Event selectedEvent;
        private ObservableCollection<Guest> guests;
        public string SelectedRsvpStatus { get; set; } = "All Status";
        public string SelectedCategories { get; set; } = "All Categories";
        public string SearchQuery { get; set; } = string.Empty;

        private GuestManager guestManager;

        private bool isLoaded = false;

        public EventDetailsUserControl(Event selectedEvent)
        {
            InitializeComponent();
            this.selectedEvent = selectedEvent;
            this.DataContext = selectedEvent;
            this.guestManager = new GuestManager();

            LoadGuests(); // Initial full load

            isLoaded = true;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.NavigateToGuestsView();
            }
        }

        private void RsvpStatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isLoaded) return;

            if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                SelectedRsvpStatus = selectedItem.Content.ToString();
                LoadGuests(); // Reload with current filters
            }
        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isLoaded) return;

            if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                SelectedCategories = selectedItem.Content.ToString();
                LoadGuests(); // Reload with current filters
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!isLoaded) return;

            if (sender is TextBox textBox)
            {
                SearchQuery = textBox.Text.Trim();
                LoadGuests();
            }
        }


        private void LoadGuests()
        {
            var allGuests = guestManager.GetSampleGuests()
                .Where(g => g.EventId == selectedEvent.Id);

            if (SelectedRsvpStatus != "All Status")
                allGuests = allGuests.Where(g => g.RsvpStatus == SelectedRsvpStatus);

            if (SelectedCategories != "All Categories")
                allGuests = allGuests.Where(g => g.Category == SelectedCategories);

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                string lowerSearch = SearchQuery.ToLower();
                allGuests = allGuests.Where(g =>
                    (!string.IsNullOrEmpty(g.Name) && g.Name.ToLower().Contains(lowerSearch)) ||
                    (!string.IsNullOrEmpty(g.Email) && g.Email.ToLower().Contains(lowerSearch))
                );
            }

            guests = new ObservableCollection<Guest>(allGuests);
            GuestTable.ItemsSource = guests;
        }

        //Window for add guest
        private void AddGuestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddGuest addGuestWindow = new AddGuest(guests, selectedEvent, null);
                addGuestWindow.ShowDialog();
                //LoadGuests(); // Refresh after closing
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        //Function for export data 
        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            var csv = string.Join(Environment.NewLine, guests.Select(g =>
                $"{g.Name},{g.Email},{g.Phone},{g.Category},{g.RsvpStatus},{g.CheckedIn}"));

            File.WriteAllText("guests_export.csv", csv);
            MessageBox.Show("Guest list exported to guests_export.csv");
        }

       //function for view guest details
        public void ShowGuestDeteils_Click(object sender, RoutedEventArgs e)
        {
            int? CurrentGuestId = null;
            if (GuestTable.SelectedItem is Guest selectedGuest)
            {
                CurrentGuestId = selectedGuest.GuestId;
            }
            try
            {
                AddGuest addGuestWindow = new AddGuest(guests, selectedEvent, CurrentGuestId);
                addGuestWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


    }
}
