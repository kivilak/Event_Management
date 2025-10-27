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
    /// Interaction logic for EventSummary.xaml
    /// </summary>
    public partial class EventSummaryView : UserControl
    {
        

        public EventSummaryView(List<EventSummary> eventSummary)
        {
            InitializeComponent();
            eventGrid.ItemsSource = eventSummary;    
        }
    }
}
