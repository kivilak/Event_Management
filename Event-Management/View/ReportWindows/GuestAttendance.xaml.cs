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
    /// Interaction logic for GuestAttendance.xaml
    /// </summary>
    public partial class GuestAttendance : UserControl
    {
        public GuestAttendance()
        {
            InitializeComponent();
            attendanceGrid.ItemsSource = new List<dynamic>
            {
                new { Event = "Tech Conference 2024", Invited = 500, Confirmed = 425, Declined = 50, Pending = 25, ResponseRate = "95.0%" },
                new { Event = "Product Launch", Invited = 300, Confirmed = 180, Declined = 50, Pending = 70, ResponseRate = "76.7%" },
                new { Event = "Wedding Reception", Invited = 150, Confirmed = 120, Declined = 20, Pending = 10, ResponseRate = "93.3%" }
            };
        }
    }
}
