using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Data;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            var dataset = new DataSet();
            dataset.ReadXml(@"StudentReport.xml");
            DataTable stdReport = dataset.Tables[0];
            int total_AD = 0;
            int total_AI = 0;
            int total_Database = 0;

            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enroll", typeof(string));
            dt.Columns.Add("Total Students", typeof(int));

            for (int a = 0; a < stdReport.Rows.Count; a++)
            {
                string col = stdReport.Rows[a]["CourseEnroll"].ToString();
                if (col == "Multimedia Technology")
                {
                    total_Database++;
                }
                else if (col == "Networks and IT Security")
                {
                    total_AD++;
                }
                else if (col == "Computing")
                {
                    total_AI++;
                }
            }
            dt.Rows.Add("Application Development: ", total_AD);
            dt.Rows.Add("Artificial Intelligence: ", total_AI);
            dt.Rows.Add("Advance Database: ", total_Database);

            ((PieSeries)display_pie_chart).ItemsSource =
                    new KeyValuePair<string, int>[]{
                new KeyValuePair<string,int>("Computing", total_AD),
                new KeyValuePair<string,int>("Network and IT Security", total_AI),
                new KeyValuePair<string,int>("Multimedia Technologies", total_Database) };





            }
    }
}
