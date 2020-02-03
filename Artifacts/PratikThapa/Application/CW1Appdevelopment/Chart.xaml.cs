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

namespace CW1Appdevelopment
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : Page

    {
        public Chart()
        {
            InitializeComponent();
            LoadPieChartData();
        }
        public void LoadPieChartData()
        {
            var dataSet = new DataSet();
            if (System.IO.File.Exists(@"files/StudentReport.xml"))
            {
                dataSet.ReadXml(@"files/StudentReport.xml");


                DataTable dtStdReport = dataSet.Tables[0];

                int Total_BBA = 0;
                int Total_BIT = 0;
                int Total_BBS = 0;

                DataTable Week = new DataTable("WeekTable1");
                Week.Columns.Add("Courses Enrolled", typeof(String));
                Week.Columns.Add("Overall Student", typeof(int));


                for (int i = 0; i < dtStdReport.Rows.Count; i++)
                {

                    String column = dtStdReport.Rows[i]["CourseEnroll"].ToString();

                    if (column == "BBA")
                    {
                        Total_BBA++;

                    }
                    else if (column == "BIT")
                    {
                        Total_BIT++;

                    }
                    else if (column == "BBS")
                    {
                        Total_BBS++;

                    }
                }
                Week.Rows.Add("BBA", Total_BBA);
                Week.Rows.Add("BIT", Total_BIT);
                Week.Rows.Add("BBS", Total_BBS);

                ((PieSeries)chartEnroll).ItemsSource =
            new KeyValuePair<string, int>[]{
            new KeyValuePair<string,int>("BBA", Total_BBA),
            new KeyValuePair<string,int>("BIT", Total_BIT),
            new KeyValuePair<string,int>("BBS", Total_BBS)};

            }
            else
            {
                MessageBox.Show("No data!");
            }

        }

        private void back(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new Studentdetails());
        }
    }
}
