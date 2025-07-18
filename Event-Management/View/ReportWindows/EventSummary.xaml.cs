using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Event_Management.View.ReportWindows
{
    /// <summary>
    /// Interaction logic for EventSummary.xaml
    /// </summary>
    public partial class EventSummary : UserControl
    {
        public EventSummary()
        {
            InitializeComponent();
            eventGrid.ItemsSource = new List<dynamic>
            {
                new { EventName = "Tech Conference 2024", Status = "Upcoming", Guests = 500, Budget = "$75,000", Spent = "$54,000", Remaining = "$21,000" },
                new { EventName = "Product Launch", Status = "In Progress", Guests = 300, Budget = "$35,000", Spent = "$28,000", Remaining = "$7,000" },
                new { EventName = "Wedding Reception", Status = "Upcoming", Guests = 150, Budget = "$40,000", Spent = "$15,000", Remaining = "$25,000" },
                new { EventName = "Tech Conference 2024", Status = "Ongoing", Guests = 500, Budget = "$75,000", Spent = "$54,000", Remaining = "$21,000" },
                new { EventName = "Product Launch", Status = "Planning", Guests = 300, Budget = "$35,000", Spent = "$28,000", Remaining = "$7,000" },
                new { EventName = "Wedding Reception", Status = "Upcoming", Guests = 150, Budget = "$40,000", Spent = "$15,000", Remaining = "$25,000" }
            };
        }
    }
}
