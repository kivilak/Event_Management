using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.TestingModel
{
   public class BudgetSummary
    {
        public double TotalBudget { get; set; }
        public double Spent { get; set; }
        public double Remaining => TotalBudget - Spent;
        public int OverBudgetItems { get; set; }
        public double PracentationOfSpent => (TotalBudget == 0) ? 0 : (Spent / TotalBudget) * 100;
        public double PercentageOfSpent => (TotalBudget == 0) ? 0 : Math.Round((Spent / TotalBudget) * 100, 2);

    }
}
