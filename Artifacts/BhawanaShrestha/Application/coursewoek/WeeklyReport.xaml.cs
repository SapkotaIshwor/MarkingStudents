using System;
using System.Collections.Generic;
using System.Data;
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

namespace coursewoek
{
    /// <summary>
    /// Interaction logic for WeeklyReport.xaml
    /// </summary>
    public partial class WeeklyReport : Window
    {
        public WeeklyReport()
        {
            InitializeComponent();
            reportCall();
        }

        public void reportCall() {
            var dataset = new DataSet();
            dataset.ReadXml(@"C:\StudentCWData.xml");
            DataTable dtStdReport = dataset.Tables[0];
            int total_Comp = 0;
            int total_MM = 0;
            int total_Net = 0;

            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enrolled", typeof(String));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                String col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    total_Comp++;
                }
                else if (col == "Multimedia Technology")
                {
                    total_MM++;
                }
                else if (col == "Network")
                {
                    total_Net++;
                }
            }

            dt.Rows.Add("Computing", total_Comp);
            dt.Rows.Add("Multimedia Technologies", total_MM);
            dt.Rows.Add("Networks and IT Security", total_Net);

            
            gridWeeklyReport.DataContext = dt.DefaultView;
        }
    }
}
