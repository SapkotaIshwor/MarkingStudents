using System.Data;
using System.Windows;

namespace Login2
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();

        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Add_Student();
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Import_CSV();
        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Student_Details();   
        }

        private void viewReport_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new stdReports();
        }

        private void viewChart_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new viewChart();
        }
    }
}
