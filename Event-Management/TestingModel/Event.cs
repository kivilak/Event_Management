using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.TestingModel
{
    public class Event
    {
        // Basic Event Information
        public string EventName { get; set; }
        public string EventType { get; set; }
        public string Category { get; set; }
        public List<string> Tags { get; set; }
        public string Description { get; set; }

        // Date and Time
        public DateTime EventDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // Venue Information
        public string VenueName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }

        // Capacity and Registration
        public int MaximumCapacity { get; set; }
        public int CurrentRegistrations { get; set; }

        public string OrgEmail { get; set; }
        public string OrgWeb { get; set; }
        public string OrgContact { get; set; }


        // Pricing Tiers
        public decimal RegularPrice { get; set; }
        public decimal EarlyBirdPrice { get; set; }
        public decimal VipPrice { get; set; }
        public bool IsFreeEvent { get; set; }

        public string Status { get; set; }
        public int Guests { get; set; }

        public int Id { get; set; }
        // Constructor
        public Event()
        {
            Tags = new List<string>();
            CurrentRegistrations = 0;
            Status = EventDate > DateTime.Today ? "Upcomming": "Past";
            Guests = 0;
            Id = 0;

        }

        // Helper method to parse comma-separated tags
        public void SetTagsFromString(string tagsString)
        {
            if (!string.IsNullOrWhiteSpace(tagsString))
            {
                Tags = new List<string>(tagsString.Split(',', StringSplitOptions.RemoveEmptyEntries));
                Tags = Tags.ConvertAll(tag => tag.Trim());
            }
        }

        // Helper method to get tags as comma-separated string
        public string GetTagsAsString()
        {
            return Tags != null ? string.Join(", ", Tags) : string.Empty;
        }

        // Check if event has capacity
        public bool HasAvailableCapacity()
        {
            return CurrentRegistrations < MaximumCapacity;
        }

        // Get remaining capacity
        public int GetRemainingCapacity()
        {
            return MaximumCapacity - CurrentRegistrations;
        }
        //public string GuestSummary => $"{Guests} / {Capacity}";
    }
}
