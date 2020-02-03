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
    public partial class Chart : Window
    {
        public Chart()
        {
            InitializeComponent();

            var dataSet = new DataSet();

            dataSet.ReadXml(@"D:\StudentReport.xml");

            // DataTable dtStdReport = new DataTable();
            DataTable dtStdReport = dataSet.Tables[0];

            int bit_Total = 0;
            int bba_Total = 0;
            int marketing_Total = 0;
            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enroll", typeof(string));
            dt.Columns.Add("Total Students", typeof(int));
            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                String subject = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (subject == "BIT")
                {
                    bit_Total++;
                }
                else if (subject == "BBA")
                {
                    bba_Total++;
                }
                else if (subject == "Marketing")
                {
                    marketing_Total++;
                }
            }
            dt.Rows.Add("BIT", bit_Total);
            dt.Rows.Add("BBA", bba_Total);
            dt.Rows.Add("Marketing", marketing_Total);

            ((BarSeries)chart).ItemsSource =
        new KeyValuePair<string, int>[]{
        new KeyValuePair<string,int>("BIT", bit_Total),
            new KeyValuePair<string,int>("BBA", bba_Total),
        new KeyValuePair<string,int>("Marketing", marketing_Total)
         };

        }
    }
}
