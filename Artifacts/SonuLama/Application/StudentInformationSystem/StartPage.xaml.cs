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
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Window
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StudentEnrol startPage = new StudentEnrol();
            startPage.ShowDialog();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ImportCSV csv = new ImportCSV();
            csv.ShowDialog();
        }

        private void btnChart_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WeeklyChart chart = new WeeklyChart();
            chart.ShowDialog();
           
        }
    }
    
}
