using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Event_Management.TestingModel;

namespace Event_Management.ViewModel
{
  
    class EventViewModel
    {
        public ObservableCollection<Event> Events { get; set; }
        public int TotalEventCount { get; set; }
        public int UpcomingEventCount { get; set; }
        public int TotalGuests { get; set; }
        public double TotalBudget { get; set; }


        public EventViewModel()
        {
            
            Events = EventManager.GetEvents();
            TotalEventCount = EventManager.GetTotalEventCount();
            UpcomingEventCount = EventManager.GetTotalUpcomingEventCount();
            TotalGuests = EventManager.GetTotalGuest();
            TotalBudget = EventManager.getTotalBudget();
        }

    }
}
