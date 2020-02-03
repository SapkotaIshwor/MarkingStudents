using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for ViewChart.xaml
    /// </summary>

    public partial class ViewChart : Window
    {
        int mt;
        int ns;
        int computing;


        public ViewChart()
        {
            InitializeComponent();

            LoadColumnChartData();
        }
        private void LoadColumnChartData()
        {
            loadData();


            ((ColumnSeries)mcChart.Series[0]).ItemsSource =
                new KeyValuePair<string, int>[]{
        new KeyValuePair<string, int>("computing", computing),
        new KeyValuePair<string, int>("Multemedia", mt),
        new KeyValuePair<string, int>("Networking", ns)
         };

        }

        private void loadData()
        {
            var handler = new Handler();

            var dataSet = handler.GenerateDataSet();


            if (System.IO.File.Exists(@"D:\StudentData.xml"))
            {



                dataSet.ReadXml(@"D:\StudentData.xml");

                DataTable weeklyReport = dataSet.Tables["StudentInfo"];
                //filtering date of one week

                //counting total number of student registered in a week

                computing = weeklyReport.Select("Program = 'Computing' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                mt = weeklyReport.Select("Program = 'Multimedia Technology' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                ns = weeklyReport.Select("Program = 'Networks and IT security' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();



            }
            else
            {
                System.Windows.MessageBox.Show("Sorry! XML file is missing", "FIle Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void back_btn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            baseWndo bw = new baseWndo();
            bw.Show();

        }
    }
}