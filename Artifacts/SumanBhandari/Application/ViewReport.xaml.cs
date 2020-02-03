using DataHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentRegistration
{
    /// <summary>
    /// Interaction logic for ViewReport.xaml
    /// </summary>
    public partial class ViewReport : Window
        
    {
        string CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\StudentCWData.xml";

        private int javaNum, pythonNum,hardwareNum,databaseNum,SENum,ADNum;//initialisation of daily student number in specific course
        private int WjavaNum, WpythonNum, WhardwareNum, WdatabaseNum, WSENum, WADNum;//initialisation of weekly student number in specific course
        private int TjavaNum, TpythonNum, ThardwareNum, TdatabaseNum, TSENum, TADNum;////initialisation of total student number in specific course

        private void WeeklyReport_Click(object sender, RoutedEventArgs e)
        {
            graphGrid.Visibility = Visibility.Hidden;
            dailyreportgrid.Visibility = Visibility.Visible;
            reportDataGrid.Visibility = Visibility.Hidden;
            javano.Content = WjavaNum;
            pythonNo.Content = WpythonNum;
            hardwareNo.Content = WhardwareNum;
            databaseNo.Content = WdatabaseNum;
            SENo.Content = WSENum;
            ADNo.Content = WADNum;
        }

        private DateTime todaysDate;
        public ViewReport()
        {
            InitializeComponent();
            var dataHandler = new datahandler();
            var dataSet = dataHandler.CreateDataSet();
            todaysDate = DateTime.UtcNow.Date;
            if (File.Exists(CurrentPath))
            {
                dataSet.ReadXml(CurrentPath);
                reportDataGrid .ItemsSource = new DataView(dataSet.Tables["Student"]);
                reportDataGrid.Visibility = Visibility.Visible;
            }
            DataTable studentTable = dataSet.Tables["student"];
            javaNum = studentTable.Select("CourseEnroll = 'java' AND RegistrationDate>='" + todaysDate + "'").Count<DataRow>();
            pythonNum = studentTable.Select("CourseEnroll = 'python' AND RegistrationDate >='" + todaysDate + "'").Count<DataRow>();
            hardwareNum = studentTable.Select("CourseEnroll = 'hardware' AND RegistrationDate >='" + todaysDate + "'").Count<DataRow>();
            databaseNum = studentTable.Select("CourseEnroll = 'Database' AND RegistrationDate >='" + todaysDate + "'").Count<DataRow>();
            SENum = studentTable.Select("CourseEnroll = 'Software Engineering' AND RegistrationDate >='" + todaysDate + "'").Count<DataRow>();
            ADNum = studentTable.Select("CourseEnroll = 'Application Development' AND RegistrationDate >='" + todaysDate + "'").Count<DataRow>();

            TjavaNum = studentTable.Select("CourseEnroll = 'java' ").Count<DataRow>();
            TpythonNum = studentTable.Select("CourseEnroll = 'python'").Count<DataRow>();
            ThardwareNum = studentTable.Select("CourseEnroll = 'hardware' ").Count<DataRow>();
            TdatabaseNum = studentTable.Select("CourseEnroll = 'Database' ").Count<DataRow>();
            TSENum = studentTable.Select("CourseEnroll = 'Software Engineering' ").Count<DataRow>();
            TADNum = studentTable.Select("CourseEnroll = 'Application Development' ").Count<DataRow>();

            WjavaNum = studentTable.Select("CourseEnroll = 'java' AND RegistrationDate>='" + todaysDate.AddDays(-7) + "'").Count<DataRow>();
            WpythonNum = studentTable.Select("CourseEnroll = 'python' AND RegistrationDate>='" + todaysDate.AddDays(-7) + "'").Count<DataRow>();
            WhardwareNum = studentTable.Select("CourseEnroll = 'hardware' AND RegistrationDate>='" + todaysDate.AddDays(-7) + "'").Count<DataRow>();
            WdatabaseNum = studentTable.Select("CourseEnroll = 'Database' AND RegistrationDate>='" + todaysDate.AddDays(-7) + "'").Count<DataRow>();
            WSENum = studentTable.Select("CourseEnroll = 'Software Engineering' AND RegistrationDate>='" + todaysDate.AddDays(-7) + "'").Count<DataRow>();
            WADNum = studentTable.Select("CourseEnroll = 'Application Development' AND RegistrationDate>='" + todaysDate.AddDays(-7) + "'").Count<DataRow>();
        }

        private void sortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dailyreportgrid.Visibility = Visibility.Collapsed;
            reportDataGrid.Visibility = Visibility.Visible;
            graphGrid.Visibility = Visibility.Hidden;
            weeklyReportGrid.Visibility = Visibility.Hidden;

            var sortby = sortBy.SelectedIndex;
            if (sortby == 0)
            {
                reportDataGrid.Items.SortDescriptions.Clear();
                reportDataGrid.Items.SortDescriptions.Add(new SortDescription("firstname", ListSortDirection.Ascending));
                reportDataGrid.Items.Refresh();

            }
            if (sortby == 1)
            {
                reportDataGrid.Items.SortDescriptions.Clear();
                reportDataGrid.Items.SortDescriptions.Add(new SortDescription("RegistrationDate", ListSortDirection.Descending));
                reportDataGrid.Items.Refresh();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dailyreportgrid.Visibility = Visibility.Visible;
            reportDataGrid.Visibility = Visibility.Hidden;
            graphGrid.Visibility = Visibility.Hidden;
            weeklyReportGrid.Visibility = Visibility.Hidden;

            javano.Content = javaNum;
            pythonNo.Content = pythonNum;
            hardwareNo.Content = hardwareNum;
            databaseNo.Content = databaseNum;
            SENo.Content = SENum;
            ADNo.Content = ADNum;
        }
        //this method is used to generate graoh
        private void LoadColumnChartData()
        {           
            ((ColumnSeries)mcChart.Series[0]).ItemsSource =
                new KeyValuePair<string, int>[]{
        new KeyValuePair<string, int>("Python", TpythonNum),
        new KeyValuePair<string, int>("JAVA", TjavaNum),
        new KeyValuePair<string, int>("Hardware", ThardwareNum),
        new KeyValuePair<string, int>("Database", TdatabaseNum),
        new KeyValuePair<string, int>("Software Engineering", TSENum),
        new KeyValuePair<string, int>("Application Development", TADNum) };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            graphGrid.Visibility=Visibility.Visible;
            dailyreportgrid.Visibility = Visibility.Collapsed;
            reportDataGrid.Visibility = Visibility.Hidden;
            weeklyReportGrid.Visibility = Visibility.Hidden;
            LoadColumnChartData();
        }

        private void GraphicalReport_Click(object sender, RoutedEventArgs e)
        {
            graphGrid.Visibility = Visibility.Visible;
            dailyreportgrid.Visibility = Visibility.Collapsed;
            reportDataGrid.Visibility = Visibility.Hidden;
            weeklyReportGrid.Visibility = Visibility.Hidden;
            LoadColumnChartData();
        }
       
    }
}
