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

namespace Student_Infromation_System
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StudentEnroll enrollStudent = new StudentEnroll();
            enrollStudent.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Import import = new Import();
            import.ShowDialog();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Report report = new Report();
            report.ShowDialog();
        }
        
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CourseChart chart = new CourseChart();
            chart.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WeeklyReport weeklyReport = new WeeklyReport();
            weeklyReport.ShowDialog();
        }
    }
}
