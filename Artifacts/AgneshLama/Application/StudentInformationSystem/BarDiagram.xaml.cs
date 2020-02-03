using System;
using System.Collections.Generic;
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
using System.Data;

using System.Windows.Controls.DataVisualization.Charting;


namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for BarDiagram.xaml
    /// </summary>
    public partial class BarDiagram : Window
    {
        public BarDiagram()
        {
            InitializeComponent();
            PieChart();
        }

        private void PieChart()
        {
            var dataSet = new DataSet();

            dataSet.ReadXml(@"C:\\Users\\Shristita Kunwar\\Documents\\Visual Studio 2013\\Projects\\StudentInformationSystem\\StudentInformationSystem\\bin\\Debug\\StudentDetails.xml");

            DataTable dataTable = dataSet.Tables[0];
            int total_Com = 0;
            int total_Net = 0;
            int total_Mul = 0;

            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enroll", typeof(String));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                String col = dataTable.Rows[i][6].ToString();

                if (col == "Computing")
                {
                    total_Com++;
                }
                else if (col.Equals("Network and It Security"))
                {
                    total_Net++;
                }
                else if (col.Equals("Multimedia Technologies"))
                {
                    total_Mul++;
                }


            }

            


            ((PieSeries)pieChart).ItemsSource =
                 new KeyValuePair<string, int>[]{  
                 new KeyValuePair<string,int>("Computing", total_Com),  
                 new KeyValuePair<string,int>("Network and It Security", total_Net),  
                 new KeyValuePair<string,int>("Multimedia Technology", total_Mul) }; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
    }
}
