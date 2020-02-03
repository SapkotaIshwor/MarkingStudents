using DataHandler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace ADCourseWork
{
    /// <summary>
    /// Interaction logic for WeeklyStudentReport.xaml
    /// </summary>
    public partial class WeeklyStudentReport : Page
    {
        public WeeklyStudentReport()
        {
            InitializeComponent();
             weeklyStudentList();
        }
        private void weeklyStudentList()
        {
            var dataSet = new DataSet();

            dataSet.ReadXml(@"file\StudentReport.xml");

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
                else if (column == "BEIT")
                {
                    Total_BEIT++;

                }
                else if (column == "BBS")
                {
                    Total_BBS++;

                }
            }
            Week.Rows.Add("BBA", Total_BBA);
            Week.Rows.Add("BEIT", Total_BEIT);
            Week.Rows.Add("BBS", Total_BBS);


            StudentReport.DataContext = Week.DefaultView;


        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StudentDetail());
        }
    }
}
