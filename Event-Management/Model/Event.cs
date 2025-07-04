using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Model
{
    class Event
    {
       // [Key]
        public int? EventId { get; set; }

       // [Required]
        public string? EventName { get; set; }

       // [Required]
        public string? Type { get; set; }

        public DateTime DateTime { get; set; }

        public string? Location { get; set; }

        public string? Status { get; set; }

        public int GuestCount { get; set; }

 
        public ICollection<Task>? Tasks { get; set; }
        public ICollection<Guest>? Guests { get; set; }
    }
}
