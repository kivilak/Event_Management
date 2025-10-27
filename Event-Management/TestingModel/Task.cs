using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.TestingModel
{
    public class Task
    {
        public int TaskId { get; set; }
        public string? Title { get; set; }
        public string?  Category{ get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
        public bool? CheckedIn { get; set; }
        public int? EventId { get; set; }
        public Event? Event { get; set; }
    }
}
