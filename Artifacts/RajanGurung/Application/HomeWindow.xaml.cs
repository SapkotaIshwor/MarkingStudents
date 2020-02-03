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

namespace CourseworkAppDevelopment
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void btnStudentEnroll_Click(object sender, RoutedEventArgs e) {

            StudentEnroll studentEnroll = new StudentEnroll();
            
            studentEnroll.Show();
            
            this.Close();

        }

        private void btnWeeklyReport_Click(object sender, RoutedEventArgs e) {

            WeeklyReport weeklyReport = new WeeklyReport();
            
            weeklyReport.Show();
            
            this.Close();

        }

        private void btnImport_Click(object sender, RoutedEventArgs e) {

            Import import = new Import();
            
            import.Show();
            
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e) {


        }

        private void btnExitHomePage(object sender, RoutedEventArgs e){


        }


        private void btnGenerateReport_Click(object sender, RoutedEventArgs e) {

            GenerateReport generateReport = new GenerateReport();
            
            generateReport.Show();
            
            this.Close();

        }

        private void btnBarChart_Click(object sender, RoutedEventArgs e) {

            Chart chart = new Chart();
            
            chart.Show();
            
            this.Close();

        }
    }
}
