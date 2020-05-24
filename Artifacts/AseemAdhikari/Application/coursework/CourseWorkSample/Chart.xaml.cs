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

namespace CourseWorkSample
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : Window
    {
        public Chart()
        {
            InitializeComponent();
        }
        private void LoadPieChartData()
        {
            //    ((PieSeries)mcChart.Series[0]).ItemsSource =
            //        new KeyValuePair<string, int>[]{
            //newKeyValuePair<string,int>("Computing", 12),
            //newKeyValuePair<string,int>("Multimedia Technology", 25),
            //newKeyValuePair<string,int>("Network", 5),
            //}
        }
    }
}
