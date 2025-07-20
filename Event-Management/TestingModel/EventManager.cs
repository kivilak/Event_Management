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
                      Id=1,
                      Name = "Tech Expo 2025",
                      DateTime = "2025-08-20 10:00:00",
                      Location = "Colombo City Center",
                      Type = "Conference",
                      Status = "Upcoming",
                      Guests = 120,
                      Tasks = 10, 
                      Capacity = 500
                  },
                  new Event
                  {
                      Id=2,
                      Name = "Corporate Meetup",
                      DateTime = "2025-07-15 14:00:00",
                      Location = "Hilton Hotel",
                      Type = "Corporate",
                      Status = "Upcoming",
                      Guests = 75,
                      Tasks = 10,
                      Capacity = 200
                  },
                  new Event
                  {
                      Id=3,
                      Name = "Planning Retreat",
                      DateTime = "2025-07-25 09:00:00",
                      Location = "Jetwing Blue",
                      Type = "Corporate",
                      Status = "Planning",
                      Guests = 60,
                      Tasks = 10,
                      Capacity = 100
                  },
                  new Event
                  {
                      Id=4,
                      Name = "Live Charity Stream",
                      DateTime = "2025-07-10 18:00:00",
                      Location = "Online",
                      Type = "Fundraiser",
                      Status = "Ongoing",
                      Guests = 320,
                      Tasks = 10,
                      Capacity = 1000
                  },
                  new Event
                  {
                      Id=5,
                      Name = "Fundraiser Night",
                      DateTime = "2025-06-30 19:00:00",
                      Location = "Galle Face Hotel",
                      Type = "Fundraiser",
                      Status = "Completed",
                      Guests = 180,
                      Tasks = 10,
                      Capacity = 250
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
            return 10000.00;
        }

    }
}
