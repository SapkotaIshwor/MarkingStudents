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

namespace CourseWorkAD
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            LoadPieChartData();
            
        }
        private void LoadPieChartData()
        {
            int sum_computing = 1;
            int sum_mediatechnology = 2;
            int sum_networksanditsecurity = 2;


            DataTable dtable = new DataTable("tbl");
            dtable.Columns.Add("Course Enroll", typeof(String));
            dtable.Columns.Add("Sum Students", typeof(int));

            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                String lol = dtable.Rows[i]["CourseEnroll"].ToString();
                if (lol == "Computing")
                {
                    sum_computing++;
                }
                else if (lol == "Multimedia Technology")
                {
                    sum_mediatechnology++;
                }
                else if (lol == "Networks and IT Security")
                {
                    sum_networksanditsecurity++;
                }

            }

            dtable.Rows.Add("Computing", sum_computing);
            dtable.Rows.Add("Multimedia Technology", sum_mediatechnology);
            dtable.Rows.Add("Networks and IT Security", sum_networksanditsecurity);

            ((System.Windows.Controls.DataVisualization.Charting.PieSeries)Pie).ItemsSource =
                new KeyValuePair<string, int>[]{
        new KeyValuePair<string,int>("Computing", sum_computing),
        new KeyValuePair<string,int>("Multimedia Technology", sum_mediatechnology),
        new KeyValuePair<string,int>("Networks and IT Security", sum_networksanditsecurity) };
       
        }
    }
}
