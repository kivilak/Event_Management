using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.TestingModel
{
    internal class GuestManager
    {
        public static ObservableCollection<Guest> Guests { get; set; } = new ObservableCollection<Guest>
           {
               new Guest
               {
                   GuestId = 1,
                   Name = "Alice Johnson",
                   Email = "alice.johnson@example.com",
                   Phone = "123-456-7890",
                   Category = "Speaker",
                   RsvpStatus = "Confirmed",
                   Dietary = "Vegetarian",
                   CheckedIn = true,
                   EventId = 1
               },
               new Guest
               {
                   GuestId = 2,
                   Name = "Bob Smith",
                   Email = "bob.smith@example.com",
                   Phone = "987-654-3210",
                   Category = "Attendee",
                   RsvpStatus = "Pending",
                   Dietary = "None",
                   CheckedIn = false,
                   EventId = 1
               },
               new Guest
               {
                   GuestId = 3,
                   Name = "Carol Lee",
                   Email = "carol.lee@example.com",
                   Phone = "555-123-4567",
                   Category = "Attendee",
                   RsvpStatus = "Declined",
                   Dietary = "Gluten-Free",
                   CheckedIn = false,
                   EventId = 2
               },
               new Guest
               {
                   GuestId = 4,
                   Name = "David Kim",
                   Email = "david.kim@example.com",
                   Phone = "444-321-9876",
                   Category = "Speaker",
                   RsvpStatus = "Confirmed",
                   Dietary = "Vegan",
                   CheckedIn = true,
                   EventId = 3
               },
               new Guest
               {
                   GuestId = 5,
                   Name = "Emily Davis",
                   Email = "emily.davis@example.com",
                   Phone = "111-222-3333",
                   Category = "Attendee",
                   RsvpStatus = "Confirmed",
                   Dietary = "None",
                   CheckedIn = false,
                   EventId = 3
               }

           };

       public ObservableCollection<Guest> GetSampleGuests()
        {
            return Guests;
        }

        public void addGuest(Guest guest)
        {
            Guests.Add(guest);
        }
    }
}
