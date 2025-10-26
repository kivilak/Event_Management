using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Model
{
   public class BudgetSummary
    {
        public decimal TotalBudget { get; set; }
        public decimal Spent { get; set; }
        public decimal Remaining => TotalBudget - Spent;
        public int OverBudgetItems { get; set; }
        public decimal PracentationOfSpent => (TotalBudget == 0) ? 0 : (Spent / TotalBudget) * 100;
        public decimal PercentageOfSpent => (TotalBudget == 0) ? 0 : Math.Round((Spent / TotalBudget) * 100, 2);

    }
}
