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

namespace studentManagement
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : Window
    {
        public home()
        {
            InitializeComponent();
        }
        private void enrollStudent_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new EnrollStudent();
        }

        private void importCSV_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ImportCSV();
        }

        private void studentDetails_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new StudentDetails();
        }
        
        private void weeklyReport_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new weeklyReport();
        }
        
        private void chart_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new chart();
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
