using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Event_Management.TestingModel;
using Event_Management.View.window;
using Task = Event_Management.TestingModel.Task;

namespace Event_Management.View
{
    public partial class EventDetailsTaskUserControl : UserControl
    {
        private Event selectedEvent;
        private ObservableCollection<Task> tasks;
        public string SelectedStatus { get; set; } = "All Status";
        public string SelectedCategories { get; set; } = "All Categories";
        public string SearchQuery { get; set; } = string.Empty;

        private TaskManager taskManager;

        private bool isLoaded = false;

        public EventDetailsTaskUserControl(Event selectedEvent)
        {
            InitializeComponent();
            this.selectedEvent = selectedEvent;
            this.DataContext = selectedEvent;
            this.taskManager = new TaskManager();

            LoadTasks(); // Initial full load

            isLoaded = true;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.NavigateToTasksView();
            }
        }

        private void StatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isLoaded) return;

            if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                SelectedStatus = selectedItem.Content.ToString();
                LoadTasks(); // Reload with current filters
            }
        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isLoaded) return;

            if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                SelectedCategories = selectedItem.Content.ToString();
                LoadTasks(); // Reload with current filters
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!isLoaded) return;

            if (sender is TextBox textBox)
            {
                SearchQuery = textBox.Text.Trim();
                LoadTasks();
            }
        }


        private async void LoadTasks()
        {
            var allTasks = (await taskManager.GetAllTasks())
                .Where(g => g.EventId == selectedEvent.Id);

            if (SelectedStatus != "All Status")
                allTasks = allTasks.Where(g => g.Status == SelectedStatus);

            if (SelectedCategories != "All Categories")
                allTasks = allTasks.Where(g => g.Category == SelectedCategories);

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                string lowerSearch = SearchQuery.ToLower();
                allTasks = allTasks.Where(g =>
                    (!string.IsNullOrEmpty(g.Title) && g.Title.ToLower().Contains(lowerSearch)) //
                    
                );
            }

            tasks = new ObservableCollection<Task>(allTasks);
            TaskTable.ItemsSource = tasks;
        }

        //Window for add task
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddTask addTaskWindow = new AddTask(tasks, selectedEvent, null);
                addTaskWindow.ShowDialog();
                //LoadTasks(); // Refresh after closing
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        //Function for export data 
        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            var csv = string.Join(Environment.NewLine, tasks.Select(g =>
                $"{g.Title},{g.Category},{g.Status},{g.CheckedIn}"));

            File.WriteAllText("tasks_export.csv", csv);
            MessageBox.Show("Task list exported to tasks_export.csv");
        }

       //function for view task details
        public void ShowTaskDeteils_Click(object sender, RoutedEventArgs e)
        {
            int? CurrentTaskId = null;
            if (TaskTable.SelectedItem is Task selectedTask)
            {
                CurrentTaskId = selectedTask.TaskId;
            }
            try
            {
                AddTask addTaskWindow = new AddTask(tasks, selectedEvent, CurrentTaskId);
                addTaskWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


    }
}
