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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for WeeklyChart.xaml
    /// </summary>
    public partial class WeeklyChart : Window
    {
        public WeeklyChart()
        {
            InitializeComponent();
            LoadPieChartData();
        }
        private void LoadPieChartData()
        {
            // declaring new data set
            var dataset = new DataSet();

            // reading main report
            dataset.ReadXml(@"C:\DataHandler\StudentData.xml");
            DataTable stdReport = dataset.Tables[0];
            // assigning initial values of Course to 
            int computing = 0;
            int multimedia = 0;
            int networking = 0;

            DataTable dt = new DataTable("dt");
            dt.Columns.Add("Course Enroll", typeof(String));  // creating two columns
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < stdReport.Rows.Count; i++)
            {


                String col = stdReport.Rows[i]["courseEnrol"].ToString();
                if (col == "Computing")
                {
                    computing++;   // incrementing values of each course based on user input
                }
                else if (col == "Multimedia Technologies")
                {
                    multimedia++;
                }
                else if (col == "Networks and IT Security")
                {
                    networking++;
                }
            }

            dt.Rows.Add("Computing", computing);          // final assign
            dt.Rows.Add("Multimedia Technologies", multimedia);
            dt.Rows.Add("Networks and IT Security", networking);
            ((System.Windows.Controls.DataVisualization.Charting.PieSeries)weeklychart).ItemsSource =
                new KeyValuePair<string, int>[]{
        new KeyValuePair<string,int>("Computing", computing),
        new KeyValuePair<string,int>("Multimedia Technologies", multimedia),
        new KeyValuePair<string,int>("Networks and IT Security", networking) };
       
        }
    }
}
