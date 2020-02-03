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

namespace CourseWorkSample
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

                //DataTable dtStdReport = new DataTable("dt");
               DataTable  dtStdReport = dataSet.Tables[0];
               
            


            int sum_computing = 0;
            int sum_mediatechnology = 0;
            int sum_networksanditsecurity = 0;
            int sum_cybersecurityandethicalhacking = 0;

            DataTable dtable = new DataTable("tbl");
            dtable.Columns.Add("Course Enroll", typeof(String));
            dtable.Columns.Add("Sum Students", typeof(int));


            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                String lol = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (lol == "Computing")
                {
                    sum_computing++;
                }
                else if (lol == "Multimedia Technology")
                {
                    sum_mediatechnology++;
                }
                else if (lol == "Networking and IT Security")
                {
                    sum_networksanditsecurity++;
                }
                else if (lol == "Cyber Security and Ethical Hacking")
                {
                    sum_cybersecurityandethicalhacking++;
                }

            }

            dtable.Rows.Add("Computing", sum_computing);
            dtable.Rows.Add("Multimedia Technology", sum_mediatechnology);
            dtable.Rows.Add("Networking and IT Security", sum_networksanditsecurity);
            dtable.Rows.Add("Cyber Security and Ethical Hacking", sum_cybersecurityandethicalhacking);
            {
                ((PieSeries)chartgrd).ItemsSource =
                new KeyValuePair<string, int>[]{
                new KeyValuePair<string,int>("Computing", sum_computing),
                new KeyValuePair<string,int>("Multimedia Technology", sum_mediatechnology),
                new KeyValuePair<string,int>("Networking and IT Security", sum_networksanditsecurity),
                new KeyValuePair<string,int>("Cyber Security and Ethical Hacking", sum_cybersecurityandethicalhacking) };
            }
        }
    }
}
