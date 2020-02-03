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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDevelopmentCW
{
    /// <summary>
    /// Interaction logic for pieChart.xaml
    /// </summary>
    public partial class pieChart : Page
    {
        public pieChart()
        {
            InitializeComponent();
            LoadPieChartData();
        }


        public void LoadPieChartData()
        {
            var dataSet = new DataSet();
            if (System.IO.File.Exists(@"Files/StudentReport.xml"))
            {
                dataSet.ReadXml(@"Files/StudentReport.xml");


                DataTable dtStdReport = dataSet.Tables[0];

                int Total_BBA = 0;
                int Total_BEIT = 0;
                int Total_BBS = 0;

                DataTable Week = new DataTable("WeekTable1");
                Week.Columns.Add("Courses Enrolled", typeof(String));
                Week.Columns.Add("Overall Student", typeof(int));


                for (int i = 0; i < dtStdReport.Rows.Count; i++)
                {

                    String column = dtStdReport.Rows[i]["CourseEnrol"].ToString();

                    if (column == "BBA")
                    {
                        Total_BBA++;

                    }
                    else if (column == "BE_IT")
                    {
                        Total_BEIT++;

                    }
                    else if (column == "BBS")
                    {
                        Total_BBS++;

                    }
                }
                Week.Rows.Add("BBA", Total_BBA);
                Week.Rows.Add("BE_IT", Total_BEIT);
                Week.Rows.Add("BBS", Total_BBS);

                ((PieSeries)chartEnroll).ItemsSource =
            new KeyValuePair<string, int>[]{
            new KeyValuePair<string,int>("BBA", Total_BBA),
            new KeyValuePair<string,int>("BE_IT", Total_BEIT),
            new KeyValuePair<string,int>("BBS", Total_BBS)};

            }
            else
            {
                MessageBox.Show("No data to show!");
            }

        }

        private void BackToRegistration(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StudentRegistration());
        }
    }
}
