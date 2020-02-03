using System.Windows;

namespace CWAD
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

        private void btnEnroll_Click(object sender, RoutedEventArgs e)
        {
            page.Content = new Enroll();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            page.Content = new Import();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            page.Content = new Report();
        }

        private void btnWeeklyReport_Click(object sender, RoutedEventArgs e)
        {
            page.Content = new TotalStudents();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            page.Content = new HomePage();
        }

        private void btnPieChart_Click(object sender, RoutedEventArgs e)
        {
            page.Content = new PieChart();
        }
    }
}
