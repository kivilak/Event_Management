using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Model
{
    class GuestManager
    {
        public ObservableCollection<Guest> Guests { get; set; }

        public GuestManager()
        {
            Guests = new ObservableCollection<Guest>
            {
                new Guest
                {
                    GuestId = 1,
                    Name = "Alice Johnson",
                    Email = "alice@techcorp.com",
                    Phone = "+1 (555) 123-4567",
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
                    Email = "bob@startup.io",
                    Phone = "+1 (555) 234-5678",
                    Category = "Attendee",
                    RsvpStatus = "Pending",
                    Dietary = "None",
                    CheckedIn = false,
                    EventId = 1
                },
                new Guest
                {
                    GuestId = 3,
                    Name = "Carol White",
                    Email = "carol@nonprofit.org",
                    Phone = "+1 (555) 555-1234",
                    Category = "Attendee",
                    RsvpStatus = "Confirmed",
                    Dietary = "Vegan",
                    CheckedIn = false,
                    EventId = 2
                },
                new Guest
                {
                    GuestId = 4,
                    Name = "David Wilson",
                    Email = "david@consulting.biz",
                    Phone = "+1 (555) 456-7890",
                    Category = "Attendee",
                    RsvpStatus = "Declined",
                    Dietary = "None",
                    CheckedIn = false,
                    EventId = 3
                },
                new Guest
                {
                    GuestId = 5,
                    Name = "Emily Davis",
                    Email = "emily@company.com",
                    Phone = "+1 (555) 789-1234",
                    Category = "Speaker",
                    RsvpStatus = "Confirmed",
                    Dietary = "Gluten-Free",
                    CheckedIn = true,
                    EventId = 3
                },
                new Guest
                {
                    GuestId = 6,
                    Name = "Frank Thomas",
                    Email = "frank@media.com",
                    Phone = "+1 (555) 678-9012",
                    Category = "Attendee",
                    RsvpStatus = "Pending",
                    Dietary = "None",
                    CheckedIn = false,
                    EventId = 2
                },
                new Guest
                {
                    GuestId = 7,
                    Name = "Grace Lee",
                    Email = "grace@organizers.org",
                    Phone = "+1 (555) 321-6540",
                    Category = "Organizer",
                    RsvpStatus = "Confirmed",
                    Dietary = "Vegetarian",
                    CheckedIn = true,
                    EventId = 1
                },
                new Guest
                {
                    GuestId = 8,
                    Name = "Henry Brown",
                    Email = "henry@enterprise.com",
                    Phone = "+1 (555) 876-5432",
                    Category = "Attendee",
                    RsvpStatus = "Confirmed",
                    Dietary = "Vegan",
                    CheckedIn = false,
                    EventId = 2
                },
                new Guest
                {
                    GuestId = 9,
                    Name = "Isabel Young",
                    Email = "isabel@startup.io",
                    Phone = "+1 (555) 112-2334",
                    Category = "Attendee",
                    RsvpStatus = "Pending",
                    Dietary = "None",
                    CheckedIn = false,
                    EventId = 3
                },
                new Guest
                {
                    GuestId = 10,
                    Name = "Jack Miller",
                    Email = "jack@consultants.com",
                    Phone = "+1 (555) 223-3445",
                    Category = "Speaker",
                    RsvpStatus = "Confirmed",
                    Dietary = "None",
                    CheckedIn = true,
                    EventId = 1
                }
            };
        }

        public ObservableCollection<Guest> getAllGyest()
        {
            return Guests;
        }
    }
}
