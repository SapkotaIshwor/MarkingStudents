using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ViewReport.xaml
    /// </summary>
    public partial class ViewReport : Window
    {
        List<StudentInfo> totalStudents = new List<StudentInfo>();
        private string CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\StudentRecords.xml";
        private string CurrentSchemaPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\StudentRecordsSchema.xml";
        public ViewReport()
        {
            InitializeComponent();
            var dataHandler = new DataHandler();
            var dataSet = dataHandler.CreateDataSet();
            if (File.Exists(CurrentPath) && File.Exists(CurrentSchemaPath))
            {
                dataSet.ReadXml(CurrentPath);
                reportGrid.ItemsSource = new DataView(dataSet.Tables["Student"]);
                weeklyReports();
            }
            else
            {
                MessageBox.Show("There are no students to show", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

            }


        }

        private void Reports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sortName = reports.SelectedIndex;
            if (sortName==1)
            {
                reportGrid.Items.SortDescriptions.Clear();
                reportGrid.Items.SortDescriptions.Add(new SortDescription("FirstName", ListSortDirection.Ascending));
                reportGrid.Items.Refresh();
            }
            else
            {
                reportGrid.Items.SortDescriptions.Clear();
                reportGrid.Items.SortDescriptions.Add(new SortDescription("RegistrationDate", ListSortDirection.Descending));
                reportGrid.Items.Refresh();
            }
            
        }
        private void weeklyReports()
        {
            
            var dataset = new DataSet();
            dataset.ReadXml(CurrentPath);
            DataTable stdReports = dataset.Tables[0];
            int total_Computing = 0;
            int total_Networking = 0;
            int multi_media = 0;
            int AI = 0;

            DataTable dt = new DataTable("WeeklyData");
            dt.Columns.Add("Course Enroll",typeof(string));
            dt.Columns.Add("Total Students",typeof(int));
            //dt.Columns.Add("Date", typeof(DateTime));
            for (int i = 0; i < stdReports.Rows.Count; i++)
            {
                string col = stdReports.Rows[i]["CourseEnroll"].ToString();
                string date = stdReports.Rows[i]["RegistrationDate"].ToString();
                DateTime myDate = DateTime.Parse(date);
                double thisWeek = (DateTime.Today - myDate).TotalDays;
                if (col=="Computing" && thisWeek<=7)
                {
                    total_Computing++;
                }
                else if(col== "Multimedia Technologies" && thisWeek <= 7)
                {
                    multi_media++;
                    
                }
                else if (col == "Networking" && thisWeek <= 7)
                {
                    total_Networking++;
                }
                else if (col == "Artificial Intelligence" && thisWeek <= 7)
                {
                    AI++;
                }
            }
            dt.Rows.Add("Multimedia Technologies", multi_media);
            dt.Rows.Add("Computing", total_Computing);
            dt.Rows.Add("Networking", total_Networking);
            dt.Rows.Add("Artificial Intelligence", AI);
            weeklyReport.ItemsSource = dt.DefaultView;
        }
    }
}
