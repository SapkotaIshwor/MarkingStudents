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
    /// Interaction logic for DisplayChart.xaml
    /// </summary>
    public partial class DisplayChart : Window
    {
        public DisplayChart()
        {
            InitializeComponent();
            ChartLoader();
        }

        public object NavigationService { get; private set; }

        public void ChartLoader()
        {
            var dataSet = new DataSet();
            if (System.IO.File.Exists(@"D:\StudentData.xml"))
            {
                dataSet.ReadXml(@"D:\StudentData.xml");


                DataTable dtStdReport = dataSet.Tables[0];

                //setting the count value zero at the initial point
                int Total_AD = 0;
                int Total_ADS = 0;
                int Total_AI = 0;

                DataTable Chart = new DataTable("Chart");
                Chart.Columns.Add("Program Enrolled", typeof(String));
                Chart.Columns.Add("Total Student", typeof(int));


                for (int i = 0; i < dtStdReport.Rows.Count; i++)
                {

                    String column = dtStdReport.Rows[i]["CourseEnroll"].ToString();

                    if (column == "Application Development")
                    {
                        Total_AD++;

                    }
                    else if (column == "Advanced Database")
                    {
                        Total_ADS++;

                    }
                    else if (column == "Artifical Intelligence")
                    {
                        Total_AI++;

                    }
                }
                Chart.Rows.Add("Application Development", Total_AD);
                Chart.Rows.Add("Advanced Database", Total_ADS);
                Chart.Rows.Add("Artifical Intelligence", Total_AI);

                chartDisplay.ItemsSource =
            new KeyValuePair<string, int>[]{
            new KeyValuePair<string,int>("Application Development", Total_AD),
            new KeyValuePair<string,int>("Advanced Database", Total_ADS),
            new KeyValuePair<string,int>("Artifical Intelligence", Total_AI)};

            }
            else
            {
                MessageBox.Show("No data to show!");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WeeklyTabularReport wrp = new WeeklyTabularReport();
            this.Close();
            wrp.Show();
        }
    }
}
