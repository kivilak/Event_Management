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
using System.Windows.Shapes;

namespace Event_Management.View.window
{
    /// <summary>
    /// Interaction logic for AddBudgetItem.xaml
    /// </summary>
    public partial class AddBudgetItem : Window
    {
        public AddBudgetItem(TestingModel.Event selectedEvent)
        {
            InitializeComponent();
            DataContext =new  AddBudgetItemViewModel(selectedEvent);
        }

        public void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void AddItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Budget item saved successfully!");
            this.Close();
        }
    }
}
