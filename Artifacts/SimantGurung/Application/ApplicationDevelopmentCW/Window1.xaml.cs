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

namespace ApplicationDevelopmentCW
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            var dataSet = new DataSet();

            //dataSet.ReadXml(@"C:\\Users\\Ceema\\Desktop\\ApplicationDevelopmentClass\\StudentReport.xml");
            dataSet.ReadXml(@"Files\\StudentReport.xml");

            DataTable dtStdReport = dataSet.Tables[0];

            int total_BIT = 0;
            int total_BBA = 0;

            DataTable dt = new DataTable("newTable");
            dt.Columns.Add("Course Enroll", typeof(String));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                String col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "BIT")
                {
                    total_BIT++;
                }
                else if (col == "BBA")
                {
                    total_BBA++;
                }

            }

            dt.Rows.Add("BBA", total_BBA);
            dt.Rows.Add("BIT", total_BIT);

            ((ColumnSeries)chartEnroll).ItemsSource =
        new KeyValuePair<string, int>[]{
        new KeyValuePair<string,int>("BBA", total_BBA),
        new KeyValuePair<string,int>("BIT", total_BIT)};


        }
    }
}
