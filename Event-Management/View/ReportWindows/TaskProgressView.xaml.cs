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
    /// Interaction logic for TaskProgress.xaml
    /// </summary>
    public partial class TaskProgressView : UserControl
    {
        public TaskProgressView()
        {
            InitializeComponent();
            progressGrid.ItemsSource = new List<dynamic>
            {
                new { Category = "Venue Booking", Completed = 8, Pending = 2, Overdue = 1, Total = 11, CompletionRate = "72.7%" },
                new { Category = "Catering", Completed = 5, Pending = 3, Overdue = 0, Total = 8, CompletionRate = "62.5%" },
                new { Category = "Marketing", Completed = 12, Pending = 4, Overdue = 2, Total = 18, CompletionRate = "66.7%" },
                new { Category = "Equipment", Completed = 6, Pending = 1, Overdue = 0, Total = 7, CompletionRate = "85.7%" }
            };
        }
    }
}
