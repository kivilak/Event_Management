namespace Event_Management.Model
{
    public class BudgetItem
    {
        public string CategoryName { get; set; }
        public string Event { get; set; }
        public decimal Estimated { get; set; }
        public decimal Actual { get; set; }

        public decimal Difference => Actual - Estimated;

        public string Status
        {
            get
            {
                if (Actual > Estimated) return "Over Budget";
                if (Actual < Estimated) return "Under Budget";
                return "On Budget";
            }

        }

    }
}
