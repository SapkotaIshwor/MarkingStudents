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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for StudentRegistrationDetail.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void navigate_to_registration(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StudentRegistrationDetails studentRegistrationDetails = new StudentRegistrationDetails();
            studentRegistrationDetails.ShowDialog();
        }

        private void import_bulk_record(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ImportBulkRecord importBulkRecord = new ImportBulkRecord();
            importBulkRecord.ShowDialog();
        }

        private void generate_report(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GenerateReport generateReport = new GenerateReport();
            generateReport.ShowDialog();
        }

        private void generate_weekly_report(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WeeklyReport weeklyReport = new WeeklyReport();
            weeklyReport.ShowDialog();
        }

        private void generate_bar_diagram(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChartDiagram diagram = new ChartDiagram();
            diagram.ShowDialog();
        }
    }
}
