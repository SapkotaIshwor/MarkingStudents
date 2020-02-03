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

namespace Coursework
{
    /// <summary>
    /// Interaction logic for BarDiagram.xaml
    /// </summary>
    public partial class BarDiagram : Window
    {
        public BarDiagram()
        {
            InitializeComponent();
            var dataSet = new DataSet();
            dataSet.ReadXml(@"E:\\Coursework\\bin\\Debug\\StudentDetails.xml");

            DataTable studentDataReport = dataSet.Tables[0];


            int total_Computing = 0;
            int total_Network = 0;
            int total_Multimedia = 0;

            DataTable dataTable = new DataTable("table");
            dataTable.Columns.Add("Course Enroll", typeof(String));
            dataTable.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < studentDataReport.Rows.Count; i++)
            {
                String col = studentDataReport.Rows[i]["StudentCourse"].ToString();
                if (col == "Computing")
                {
                    total_Computing++;
                }
                else if (col.Equals("Networks And IT Security"))
                {
                    total_Network++;
                }
                else if (col.Equals("Multimedia Technology"))
                {
                    total_Multimedia++;
                }
            }

            dataTable.Rows.Add("Computing", total_Computing);
            dataTable.Rows.Add("Networks And IT Security", total_Network);
            dataTable.Rows.Add("Multimedia Technology", total_Multimedia);

            ((PieSeries)PieChart).ItemsSource =
            new KeyValuePair<string, int>[]{
        new KeyValuePair<string,int>("Computing", total_Computing),
        new KeyValuePair<string,int>("Networks And IT Security", total_Network),
        new KeyValuePair<string,int>("Multimedia Technology", total_Multimedia) };
        }

       

        private void Back_Click_1(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
    }
}
