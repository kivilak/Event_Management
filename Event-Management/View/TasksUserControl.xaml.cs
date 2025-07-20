using Event_Management.ViewModel;
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
using Event_Management.TestingModel;

namespace Event_Management.View
{
    public partial class TasksUserControl : UserControl
    {
        public event Action<Event> EventSelected;

        public TasksUserControl()
        {
            InitializeComponent();
            TasksViewModel tasksViewModel = new TasksViewModel();
            this.DataContext = tasksViewModel;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is Event selectedEvent)
            {
                EventSelected?.Invoke(selectedEvent);
                dataGrid.SelectedItem = null;
            }
        }
    }
}
