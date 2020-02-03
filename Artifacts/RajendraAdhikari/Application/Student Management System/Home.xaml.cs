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

namespace Student_Management_System
{

    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    /// 
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void EnrollStudent_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new EnrollStudent();
        }


        private void Import_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ImportFromCSV();
        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new StudentDetails();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ViewReport();
        }

        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ViewChart();
        }
    }
}
