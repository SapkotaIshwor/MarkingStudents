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

namespace Student_info
{
    /// <summary>
    /// Interaction logic for ReportMainWindow.xaml
    /// </summary>
    public partial class ReportMainWindow : Window
    {
        public ReportMainWindow()
        {
            InitializeComponent();
        }

        private void back_btn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void weeklyReport_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WeeklyReportWindow weeklyReportWindow = new WeeklyReportWindow();
            weeklyReportWindow.Show();
        }

        private void chart_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChartWindow chartWindow = new ChartWindow();
            chartWindow.Show();
        }

        private void studentReport_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AllStudentWindow allStudentWindow = new AllStudentWindow();
            allStudentWindow.Show();
        }
    }
}
