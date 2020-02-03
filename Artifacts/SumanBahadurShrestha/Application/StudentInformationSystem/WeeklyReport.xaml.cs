using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for WeeklyReport.xaml
    /// </summary>
    public partial class WeeklyReport : Window
    {
        public WeeklyReport()
        {
            InitializeComponent();

            var dataset = new DataSet();
            dataset.ReadXml(@"E:\StudentCWData.xml");
            DataTable dataTable = dataset.Tables[0];

            int total_computing = 0;
            int total_Multimedia_Technologies = 0;
            int total_Networks_and_IT_Security = 0;

            DataTable dt = new DataTable("newTable");
            dt.Columns.Add("ProgramEnroll", typeof(string));
            dt.Columns.Add("Total Student", typeof(int));

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string col = dataTable.Rows[i]["courseenroll"].ToString();
                if (col == "Computing")
                {
                    total_computing++;
                }
                else if (col == "Multimedia Technologies")
                {
                    total_Multimedia_Technologies++;
                }
                else
                {
                    total_Networks_and_IT_Security++;
                }
            }
            dt.Rows.Add("Computing", total_computing);
            dt.Rows.Add("Multimedia Technologies", total_Multimedia_Technologies);
            dt.Rows.Add("Networks and IT Security", total_Networks_and_IT_Security);
            weeklygrid.DataContext = dt.DefaultView;

            ((PieSeries)piechart).ItemsSource = new KeyValuePair<string, int>[]
            {
                new KeyValuePair<string, int>("Computing", total_computing),
                new KeyValuePair<string, int>("Multimedia Technologies", total_Multimedia_Technologies),
                new KeyValuePair<string, int>("Networks and IT Security", total_Networks_and_IT_Security)
            };
        }
    }
}
