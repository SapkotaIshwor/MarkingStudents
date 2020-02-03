using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace ApplicationDevelopmentCw1
{
    /// <summary>
    /// Interaction logic for Homeage.xaml
    /// </summary>
    public partial class Homeage : Window
    {
        
        public Homeage()
        {
            InitializeComponent();
        }

        public int Property
        {
            get => default;
            set
            {
            }
        }

        private void BtnEnrolStudent_Click(object sender, RoutedEventArgs e)
        {
            var myForm = new MainWindow();
            myForm.Show();
        }
        private void btnViewReport(object sender, RoutedEventArgs e)
        {
            var viewReport1 = new ViewReport();
            viewReport1.Show();
        }

        private void btnImportData(object sender, RoutedEventArgs e)
        {
            var importData = new ExcelData();
            importData.Show();
        }

        private void btnViewChart(object sender, RoutedEventArgs e)
        {
            var viewChart = new viewChart();
            viewChart.Show();
            
        }
    }
}
