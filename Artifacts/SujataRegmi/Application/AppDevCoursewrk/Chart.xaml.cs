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

namespace AppDevCoursewrk
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
            dataSet.ReadXml(@"C:\Appxml\StudentReport.xml");
            DataTable dtStdReport = dataSet.Tables[0];

            int total_Computing = 0;
            int total_MultimediaTechnologies = 0;
            int total_NetworksandITSecurity = 0;

            DataTable dt = new DataTable("newTable");
            dt.Columns.Add("ProgramEnroll", typeof(string));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                string col = dtStdReport.Rows[i]["ProgramEnroll"].ToString();
                if (col == "Computing")
                {
                    total_Computing++;
                }
                else if (col == "Multimedia Technologies")
                {
                    total_MultimediaTechnologies++;
                }

                else if (col == "Networks and IT Security")
                {
                    total_NetworksandITSecurity++;
                }

            }
            dt.Rows.Add("Computing", total_Computing);
            dt.Rows.Add("MultimediaTechnologies", total_MultimediaTechnologies);
            dt.Rows.Add("NetworksandITSecurity", total_NetworksandITSecurity);


            ((PieSeries)Piechart).ItemsSource = new KeyValuePair<string, int>[]{
        new KeyValuePair<string,int>("Computing", total_Computing),
        new KeyValuePair<string,int>("Networks And IT Security", total_NetworksandITSecurity),
        new KeyValuePair<string,int>("Multimedia Technology", total_MultimediaTechnologies++) };
        }

    

        private void btnClick_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            
            this.Close();
        }
    }
}
