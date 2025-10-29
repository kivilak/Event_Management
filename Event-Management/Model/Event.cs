using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Model
{
    public class Event
    {
        // Basic Event Information
        public int event_id { get; set; }
        public string event_name { get; set; }
        public string event_type { get; set; }
        public string category { get; set; }
        public List<string> tags { get; set; }
        public string description { get; set; }

        // Date and Time
        public DateTime event_date { get; set; }
        public TimeSpan start_time { get; set; }
        public TimeSpan end_time { get; set; }

        // Venue Information
        public string venue_name { get; set; }
        public string street_address { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }

        // Capacity and Registration
        public int maximum_capacity { get; set; }
        public int current_registrations { get; set; }

        public string email { get; set; }
        public string event_web { get; set; }
        public string phone_number { get; set; }


        // Pricing Tiers
        public decimal regular_price { get; set; }
        public decimal early_bird_price { get; set; }
        public decimal vip_price { get; set; }
        public bool is_free_event { get; set; }

        public string status { get; set; }
        public int guests { get; set; }

        // Helper method to parse comma-separated tags
        public void SetTagsFromString(string tagsString)
        {
            if (!string.IsNullOrWhiteSpace(tagsString))
            {
                tags = new List<string>(tagsString.Split(',', StringSplitOptions.RemoveEmptyEntries));
                tags = tags.ConvertAll(tag => tag.Trim());
            }
        }

        // Helper method to get tags as comma-separated string
        public string GetTagsAsString()
        {
            return tags != null ? string.Join(", ", tags) : string.Empty;
        }

        // Check if event has capacity
        public bool HasAvailableCapacity()
        {
            return current_registrations < maximum_capacity;
        }

        // Get remaining capacity
        public int GetRemainingCapacity()
        {
            return maximum_capacity - current_registrations;
        }
    }
}
