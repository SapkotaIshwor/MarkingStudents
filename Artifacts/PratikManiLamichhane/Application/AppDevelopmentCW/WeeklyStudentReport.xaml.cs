using DataHandler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDevelopmentCW
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
            if (System.IO.File.Exists(@"Files/StudentReport.xml"))
            {
                var dataset = new DataSet();

                dataset.ReadXml(@"Files/StudentReport.Xml");


                DataTable dtStdReport = dataset.Tables[0];

                int Total_BBA = 0;
                int Total_BEIT = 0;
                int Total_BBS = 0;

                DataTable week = new DataTable("WeekTable");
                week.Columns.Add("Course Enrol");
                week.Columns.Add("OverAll Student");

                for (int i = 0; i < dtStdReport.Rows.Count; i++)
                {
                    String column = dtStdReport.Rows[i]["CourseEnrol"].ToString();
                    if (column == "BBA")
                    {
                        Total_BBA++;

                    }
                    else if (column == "BE_IT")
                    {
                        Total_BEIT++;
                    }
                    else if (column == "BBS")
                    {
                        Total_BBS++;
                    }
                }

                week.Rows.Add("BBA", Total_BBA);
                week.Rows.Add("BE.IT", Total_BEIT);
                week.Rows.Add("BBS", Total_BBS);

                StdWeeklyReport.DataContext = week.DefaultView;
            }
            else
            {
                MessageBox.Show("There is no data to show report");
            }
        }


        private void BackToRegisterPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StudentRegistration());

        }

    }
}
