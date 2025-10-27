using Event_Management.Model;
using System;
using System.Collections.ObjectModel;

namespace Event_Management.TestingModel
{
    public class EventManager
    {
        public static ObservableCollection<Event> Events { get; set; } = new()
        { 
                    new Event
                    {
                        EventName = "Tech Expo 2025",
                        EventType = "Conference",
                        Category = "Technology",
                        Tags = new List<string> { "tech", "innovation", "networking" },
                        Description = "Annual technology exposition featuring latest innovations and industry leaders",
                        EventDate = new DateTime(2025, 8, 20),
                        StartTime = TimeSpan.Parse("10:00:00"),
                        EndTime = TimeSpan.Parse("18:00:00"),
                        VenueName = "Colombo City Center",
                        StreetAddress = "123 Main Street",
                        City = "Colombo",
                        StateProvince = "Western Province",
                        MaximumCapacity = 500,
                        CurrentRegistrations = 120,
                        OrgContact = "0123456789",
                        OrgEmail = "",
                        OrgWeb = "www.techexpo2025.com",
                        RegularPrice = 5000.00m,
                        EarlyBirdPrice = 3500.00m,
                        VipPrice = 8000.00m,
                        IsFreeEvent = false
                    },
                    new Event
                    {
                        EventName = "Corporate Meetup",
                        EventType = "Corporate",
                        Category = "Business",
                        Tags = new List<string> { "corporate", "networking", "professional" },
                        Description = "Quarterly corporate networking event for business professionals",
                        EventDate = new DateTime(2025, 7, 15),
                        StartTime = TimeSpan.Parse("14:00:00"),
                        EndTime = TimeSpan.Parse("17:00:00"),
                        VenueName = "Hilton Hotel",
                        StreetAddress = "456 Galle Road",
                        City = "Colombo",
                        StateProvince = "Western Province",
                        MaximumCapacity = 200,
                        CurrentRegistrations = 75,
                        OrgContact = "0987654321",
                        OrgEmail = "",
                        OrgWeb = "www.corporatemeetup.com",
                        RegularPrice = 3000.00m,
                        EarlyBirdPrice = 2000.00m,
                        VipPrice = 5000.00m,
                        IsFreeEvent = false
                    },
                    new Event
                    {
                        EventName = "Planning Retreat",
                        EventType = "Corporate",
                        Category = "Team Building",
                        Tags = new List<string> { "retreat", "planning", "strategy" },
                        Description = "Strategic planning retreat for senior management",
                        EventDate = new DateTime(2025, 7, 25),
                        StartTime = TimeSpan.Parse("09:00:00"),
                        EndTime = TimeSpan.Parse("16:00:00"),
                        VenueName = "Jetwing Blue",
                        StreetAddress = "789 Beach Road",
                        City = "Negombo",
                        StateProvince = "Western Province",
                        MaximumCapacity = 100,
                        CurrentRegistrations = 60,
                        OrgContact = "0112233445",
                        OrgEmail = "",
                        OrgWeb = "www.planningretreat.com",
                        RegularPrice = 7500.00m,
                        EarlyBirdPrice = 6000.00m,
                        VipPrice = 10000.00m,
                        IsFreeEvent = false
                    },
                    new Event
                    {
                        EventName = "Live Charity Stream",
                        EventType = "Fundraiser",
                        Category = "Charity",
                        Tags = new List<string> { "charity", "online", "fundraising" },
                        Description = "24-hour live streaming event to raise funds for local charities",
                        EventDate = new DateTime(2025, 7, 10),
                        StartTime = TimeSpan.Parse("18:00:00"),
                        EndTime = TimeSpan.Parse("18:00:00"),
                        VenueName = "Online",
                        StreetAddress = "Virtual Event",
                        City = "Online",
                        StateProvince = "N/A",
                        MaximumCapacity = 1000,
                        CurrentRegistrations = 320,
                        OrgContact = "0119988776",
                        OrgEmail = "",
                        OrgWeb = "www.livecharitystream.com",
                        RegularPrice = 0.00m,
                        EarlyBirdPrice = 0.00m,
                        VipPrice = 0.00m,
                        IsFreeEvent = true
                    },
                    new Event
                    {
                        EventName = "Fundraiser Night",
                        EventType = "Fundraiser",
                        Category = "Charity",
                        Tags = new List<string> { "charity", "gala", "fundraising" },
                        Description = "Elegant charity gala dinner with live entertainment and auction",
                        EventDate = new DateTime(2025, 6, 30),
                        StartTime = TimeSpan.Parse("19:00:00"),
                        EndTime = TimeSpan.Parse("23:00:00"),
                        VenueName = "Galle Face Hotel",
                        StreetAddress = "2 Galle Road",
                        City = "Colombo",
                        StateProvince = "Western Province",
                        MaximumCapacity = 250,
                        CurrentRegistrations = 180,
                        OrgContact = "0115566778",
                        OrgEmail = "",
                        OrgWeb = "www.fundraisernight.com",
                        RegularPrice = 10000.00m,
                        EarlyBirdPrice = 8000.00m,
                        VipPrice = 15000.00m,
                        IsFreeEvent = false
                    }
                };

        public static ObservableCollection<Event> GetEvents()
        {
            return Events;
        }

        public static void AddEvent(Event e) 
        {
            Events.Add(e);
        }

        public static Event GetEventById(int Id)
        {
            return Events[Id];
        }

        //methods for events summary

        public static int GetTotalEventCount()
        {
            return Events.Count;
        }

        public static int GetTotalUpcomingEventCount()
        {
            return Events.Count(e => e.Status == "Upcoming");

        }

        public static int GetTotalGuest()
        {
            int tGuest = 0; ;
            foreach (Event e in Events)
            {
                tGuest = tGuest + e.Guests;
            }
            return tGuest;
        }

        public static double getTotalBudget()
        {
            return 12000.00;
        }

    }
}
