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

namespace CourseworkAppDevelopment
{
    /// <summary>
    /// Interaction logic for WeeklyReport.xaml
    /// </summary>
    public partial class WeeklyReport : Window
    {
        public WeeklyReport()
        {
            InitializeComponent();
        }

        public DataTable studentDataTable;

        private void StudentCourse() {

            if (System.IO.File.Exists(@"StudentEnroll.xml")) {

                var ds = new DataSet();

                ds.ReadXml(@"StudentEnroll.xml");
                
                studentDataTable = ds.Tables[0];

                gridReport.DataContext = studentDataTable.DefaultView;
            }
        }
        private void btnTotal_Click(object sender, RoutedEventArgs e) {

            try {

                StudentCourse();
                
                int computing = 0;
                
                int network = 0;
                
                int multimedia = 0;

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("Course", typeof(String));

                dataTable.Columns.Add("Total", typeof(int));

                for (int i = 0; i < studentDataTable.Rows.Count; i++) {

                    String course = studentDataTable.Rows[i]["StudentCourseEnroll"].ToString();

                    if (course == "Computing") {

                        computing++;
                    }

                    else if (course == "Network and IT Security") {
                        
                        network++;
                    }

                    else if (course == "Multimedia Technologies") {

                        multimedia++;

                    }

                }

                dataTable.Rows.Add("Computing", computing);

                dataTable.Rows.Add("Network and IT Security", network);

                dataTable.Rows.Add("Multimedia Technologies", multimedia);

                gridReport.ItemsSource = dataTable.DefaultView;

                MessageBox.Show("Total Number of Students Enrolled in Each Course Generated.", "Student Information System");

            }

            catch(Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnWeeklyBack_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow hw = new HomeWindow();

            hw.Show();

            this.Close();
        }
    }
}