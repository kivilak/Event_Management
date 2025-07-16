
using System.Windows.Controls;


namespace Event_Management.View
{
    /// <summary>
    /// Interaction logic for BudgetsUserControl.xaml
    /// </summary>
    public partial class BudgetsUserControl : UserControl
    {
        public BudgetsUserControl()
        {
            InitializeComponent();
            BudgetItemsGrid.ItemsSource = new List<dynamic>
            {
                new { CategoryName = "Venue", Event = "Tech Conference 2024", Estimated = "$15,000", Actual = "$14,500", Difference = "$-500", Status = "Under Budget" },
                new { CategoryName = "Venue", Event = "Tech Conference 2024", Estimated = "$15,000", Actual = "$14,500", Difference = "$-500", Status = "Under Budget" },
                new { CategoryName = "Venue", Event = "Tech Conference 2024", Estimated = "$15,000", Actual = "$14,500", Difference = "$-500", Status = "Under Budget" },
                new { CategoryName = "Venue", Event = "Tech Conference 2024", Estimated = "$15,000", Actual = "$14,500", Difference = "$-500", Status = "Under Budget" }
                
            };
        }
    }
}
