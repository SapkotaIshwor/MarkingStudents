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

namespace APPLICATION_DEVELOPMENT
{
    /// <summary>
    /// Interaction logic for Chart_Diagram.xaml
    /// </summary>
    public partial class Chart_Diagram : Window
    {
        public Chart_Diagram()
        {
            InitializeComponent();


            var dataSet = new DataSet();

            dataSet.ReadXml(@"F:\StudentReport.xml");

            DataTable dtStdReport = dataSet.Tables[0];

            int Total_BBA = 0;
            int Total_BEIT = 0;
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
                else if (column == "BE.IT")
                {
                    Total_BEIT++;

                }
                else if (column == "B.B.S")
                {
                    Total_BBS++;

                }
            }
            Week.Rows.Add("BBA", Total_BBA);
            Week.Rows.Add("BE.IT", Total_BEIT);
            Week.Rows.Add("BBS", Total_BBS);

            ((PieSeries)Chart_Diagram1).ItemsSource =
         new KeyValuePair<string, int>[]{
            new KeyValuePair<string,int>("BBA", Total_BBA),
            new KeyValuePair<string,int>("BE.IT", Total_BEIT),
            new KeyValuePair<string,int>("BBS", Total_BBS) };
           
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            RetriveWindow back = new RetriveWindow();
            back.Show();
            Close();
        }
    }
}
