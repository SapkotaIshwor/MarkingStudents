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
using System.Xml.Linq;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for WeeklyTabularReport.xaml
    /// </summary>
    public partial class WeeklyTabularReport : Window
    {
        public WeeklyTabularReport()
        {
            InitializeComponent();
        }

        private void Btn_Back_1(object sender, RoutedEventArgs e)
        {
            HomePage hp = new HomePage();
            MessageBox.Show("Going to the main window.");
            this.Close();
            hp.Show();
        }

        private void Btn_Weekly(object sender, RoutedEventArgs e)
        {
            
            var dataSet = new DataSet();
            dataSet.ReadXml(@"D:\StudentData.xml");
            DataTable dtStdReport = dataSet.Tables["Student"];

            int total_ADS = 0;
            int total_AI = 0;
            int total_AD = 0;

            DataTable dt = new DataTable("newTable");
            dt.Columns.Add("ProgramEnroll", typeof(string));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                string col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Application Development")
                {
                    total_AD++;
                }
                else if (col == "Advanced Database")
                {
                    total_ADS++;
                }
                else if (col == "Artifical Intelligence")
                {
                    total_AI++;
                }

            }
            dt.Rows.Add("Application Development", total_AD);
            dt.Rows.Add("Advanced Database", total_ADS);
            dt.Rows.Add("Artifical Intelligence", total_AI);
            grdWeeklyReport.DataContext = dt.DefaultView;
        }

        private void Btn_chart(object sender, RoutedEventArgs e)
        {
            DisplayChart dc = new DisplayChart();
            this.Close();
            dc.Show();
        }
    }
}
