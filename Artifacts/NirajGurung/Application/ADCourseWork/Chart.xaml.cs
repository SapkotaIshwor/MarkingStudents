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
            displayInChart();
        }

        public void displayInChart() {

            var dataSet = new DataSet();

            dataSet.ReadXml("Files/StudentReport.xml");

            DataTable dtStdReport = dataSet.Tables[0];

            int BBA = 0;
            int BHM = 0;
            int BIT = 0;

            DataTable dt = new DataTable("Report");

            dt.Columns.Add("CourseEnroll", typeof(String));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                String col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "BHM")
                {
                    BHM++;
                }
                else if (col == "BBA")
                {
                    BBA++;
                }
                else if (col == "BIT")
                {
                    BIT++;
                }
            }

            dt.Rows.Add("BIT", BIT);
            dt.Rows.Add("BHM", BHM); 
            dt.Rows.Add("BBA", BBA);

            var item = BHM.ToString();

            ((BarSeries)gridchart).ItemsSource =
            new KeyValuePair<string, int>[]{
                new KeyValuePair<string,int>("BHM", BHM),
                new KeyValuePair<string,int>("BBA", BBA),
                new KeyValuePair<string,int>("BIT", BIT)
            };
        }
    }
}
