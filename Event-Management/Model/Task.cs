using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Model
{
    class Task
    {
        //[Key]
        public int TaskId { get; set; }

        public string? TaskName { get; set; }

        public string? AssignedTo { get; set; }

        public DateTime Deadline { get; set; }

        public string? Priority { get; set; }

        public string? Status { get; set; }

       
        public int EventId { get; set; }

       // [ForeignKey("EventId")]
        public Event? Event { get; set; }
    }
}
