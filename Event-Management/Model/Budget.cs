using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Model
{
    public class Budget
    {
        //[Key]
        public int BudgetId { get; set; }
        public string? Category { get; set; }
        public string? Event { get; set; }
        public double? Estimated { get; set; }
        public double? Actual { get; set; }
        public double? Difference { get; set; }
        public string? Status { get; set; }

        //[ForeignKey("EventId")]
        public int? EventId { get; set; }
    }
}
