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

namespace Student_info
{
    /// <summary>
    /// Interaction logic for ChartWindow.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {
        string path = @"D:\Student_Management\StudentRegistrationData.xml";
        int ITData;
        int mgtData;
        int eduData;


        public List<Sales> Data { get; set; }
        public ChartWindow()
        {
            InitializeComponent();

            LoadColumnChartData();
        }
        private void LoadColumnChartData()
        {
            loadData();


            ((ColumnSeries)mcChart.Series[0]).ItemsSource =
                new KeyValuePair<string, int>[]{
        new KeyValuePair<string, int>("IT", ITData),
        new KeyValuePair<string, int>("Management", mgtData),
        new KeyValuePair<string, int>("Education", eduData)
         };

        }

        private void loadData()
        {
            var handler = new Handler();

            var dataSet = handler.CreateDataSet();

            try
            {

                if (System.IO.File.Exists(path))
                {

                    dataSet.ReadXml(path);

                    DataTable stdReportTbl = dataSet.Tables["Student"];
                    DataTable dv = stdReportTbl.Select("").CopyToDataTable();
                    //filtering date of one week
                    //filtering date of one week
                    //counting total number of student registered in a week
                    //counting total number of student registered in a week
                    ITData = stdReportTbl.Select("Department = 'IT' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    mgtData = stdReportTbl.Select("Department = 'Management' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    eduData = stdReportTbl.Select("Department = 'Education' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();



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
                ReportMainWindow rpw = new ReportMainWindow();
                rpw.Show();

            }
        }


        private void back_btn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ReportMainWindow rmw = new ReportMainWindow();
            rmw.Show();

        }
    }
}
