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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart
    {
        public Chart()
        {
            InitializeComponent();
            var dataSet = new DataSet();

            dataSet.ReadXml(@"D:\studentData.xml");

            DataTable dtStdReport = dataSet.Tables[0];

            int total_Networking = 0;
            int total_Multimedia = 0;
            int total_Computing = 0;

            DataTable dt = new DataTable("newTable");
            dt.Columns.Add("Course Enroll", typeof(String));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                String col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Networking")
                {
                    total_Networking++;
                }
                else if (col == "Multimedia")
                {
                    total_Multimedia++;
                }
                else if (col == "Computing")
                {
                    total_Computing++;
                }

            }

            dt.Rows.Add("Networking", total_Networking);
            dt.Rows.Add("Multimedia", total_Multimedia);
            dt.Rows.Add("Computing", total_Computing);

            ((BarSeries)GridChart).ItemsSource =
                 new KeyValuePair<string, int>[]{
                 new KeyValuePair<string,int>("Networking", total_Networking),
                 new KeyValuePair<string,int>("Multimedia", total_Multimedia),
                 new KeyValuePair<string,int>("Computing", total_Computing)};
        }
    }
}
