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
        public string? EventName { get; set; }
        public double? Estimated { get; set; }
        public double? Actual { get; set; }
        public double? Difference => Actual - Estimated;
        public string? Status
        {
            get
            {
                if (Actual > Estimated) return "Over Budget";
                if (Actual < Estimated) return "Under Budget";
                return "On Budget";
            }
        }

        //[ForeignKey("EventId")]
        public int? EventId { get; set; }
    }
}
