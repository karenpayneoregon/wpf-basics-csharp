using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Example3.Classes;

namespace Example3
{
    /// <summary>
    /// Interaction logic for ListWindow1.xaml
    /// </summary>
    public partial class ListWindow1 : Window
    {
        
        public ObservableCollection<TaskItem> TaskItemsList { get; set; }

        public ListWindow1()
        {
            InitializeComponent();

            var taskOperations = new Tasks();
            TaskItemsList = taskOperations.List();

            DataContext = this;
        }
        /// <summary> 
        /// Ensure only int values are entered.
        /// A robust alternate is using Data Annotations  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
