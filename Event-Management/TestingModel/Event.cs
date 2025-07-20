using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.TestingModel
{
    public class Event
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DateTime { get; set; }
        public string? Location { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public int Guests { get; set; }
        public int Tasks { get; set; }
        public int Capacity { get; set; }
        public string GuestSummary => $"{Guests} / {Capacity}";
    }
}
