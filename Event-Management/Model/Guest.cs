using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Model
{
    class Guest
    {
        //[Key]
        public int GuestId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Category { get; set; }

        public string? RsvpStatus { get; set; }

        public string? Dietary { get; set; }

        public bool? CheckedIn { get; set; }

        public int? EventId { get; set; }

        //[ForeignKey("EventId")]
        public Event? Event { get; set; }
    }
}
