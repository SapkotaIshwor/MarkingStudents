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

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for baseWndo.xaml
    /// </summary>
    public partial class baseWndo : Window
    {
        public baseWndo()
        {
            InitializeComponent();
        }

        private void exit_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void logout_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void registerNewStd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            RegisterStd registerStd = new RegisterStd();
            registerStd.Show();
        }

        private void register_bulk_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            registerFromFile register_from_file = new registerFromFile();
            register_from_file.Show();

        }

        private void view_register_std_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            
            ViewRegisteredStd viewRegisteredStd = new ViewRegisteredStd();
            viewRegisteredStd.Show();
        }

        private void view_chart_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ViewChart viewChartWindow = new ViewChart();
            viewChartWindow.Show();
        }

        private void weekly_report_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WeeklyReport weeklyReport = new WeeklyReport();
            weeklyReport.Show();
        }
    }
}
