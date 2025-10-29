using Event_Management.Model;
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
    public partial class GuestAttendanceView : UserControl
    {
        public GuestAttendanceView(List<GuestAttendance> guestAttendance)
        {
            InitializeComponent();
            attendanceGrid.ItemsSource = guestAttendance;
            //attendanceGrid.ItemsSource = new List<GuestAttendance>
            //{
            //    new GuestAttendance { EventName = "Tech Conference 2024", Invited = 500, Confirmed = 425, Declined = 50, Pending = 25 },
            //    new GuestAttendance { EventName = "Product Launch", Invited = 300, Confirmed = 180, Declined = 50, Pending = 70 },
            //    new GuestAttendance { EventName = "Wedding Reception", Invited = 150, Confirmed = 120, Declined = 20, Pending = 10 }
            //};
        }
    }
}
