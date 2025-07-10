using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.TestingModel
{

    public class Guest
    {
        public int GuestId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Category { get; set; }
        public string? RsvpStatus { get; set; }
        public string? Dietary { get; set; }
        public bool? CheckedIn { get; set; }
        public int? EventId { get; set; }
        public Event? Event { get; set; }
    }

}
