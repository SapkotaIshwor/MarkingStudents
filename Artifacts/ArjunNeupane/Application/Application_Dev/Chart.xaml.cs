using DataHandler;
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

namespace Application_Dev
{
    /// <summary>
    /// Interaction logic for ChartWindow.xaml
    /// </summary>
    public partial class Chart : Window
    {
        string xmlPath = System.IO.Path.Combine(Environment.CurrentDirectory, "studentCWData.xml");
        int computing;
        int mt;
        int nis;


        public Chart()
        {
            InitializeComponent();

            LoadColumnChartData();
        }
        private void LoadColumnChartData()
        {
            loadData();


            ((ColumnSeries)mcChart.Series[0]).ItemsSource =
                new KeyValuePair<string, int>[]{
        new KeyValuePair<string, int>("Computing", computing),
        new KeyValuePair<string, int>("Multimedia Technologies", mt),
        new KeyValuePair<string, int>("Networks and IT Security", nis)
         };

        }

        private void loadData()
        {
            var handler = new Handler();

            var dataSet = handler.CreateDataSet();

            try
            {

                if (System.IO.File.Exists(xmlPath))
                {

                    dataSet.ReadXml(xmlPath);

                    DataTable stdReportTbl = dataSet.Tables["Student"];
                    DataTable dv = stdReportTbl.Select("").CopyToDataTable();
                    //filtering date of one week
                    //filtering date of one week
                    //counting total number of student registered in a week
                    //counting total number of student registered in a week
                    computing = stdReportTbl.Select("CourseEnroll = 'Computing' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    mt = stdReportTbl.Select("CourseEnroll = 'Multimedia Technologies' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    nis = stdReportTbl.Select("CourseEnroll = 'Networks and IT Security' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();

                }
                else
                {
                    System.Windows.MessageBox.Show("Sorry! XML file is missing", "FIle Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Sorry! Error occured", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                Home rpw = new Home();
                rpw.Show();

            }
        }
    }
}