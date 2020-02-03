using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace CWAD
{
    /// <summary>
    /// Interaction logic for WeeklyReport.xaml
    /// </summary>
    public partial class TotalStudents : Page
    {
        public TotalStudents()
        {
            InitializeComponent();
        }

        public DataTable studentTable;
        private void StudentData()
        {
            if (System.IO.File.Exists(@"StudentDetails.xml"))
            {

                var ds = new DataSet();
                ds.ReadXml(@"StudentDetails.xml");

                studentTable = ds.Tables[0];
                dataGridWeeklyReport.DataContext = studentTable.DefaultView;
            }
        }


        private void btnWeeklyReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StudentData();
                int application = 0;
                int artificial = 0;
                int database = 0;

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Course", typeof(String));
                dataTable.Columns.Add("Total", typeof(int));

                for (int i = 0; i < studentTable.Rows.Count; i++)
                {
                    String course = studentTable.Rows[i]["StudentCourse"].ToString();
                    if (course == "Application Development")
                    {
                        application++;
                    }
                    else if (course == "Artificial Intelligence")
                    {
                        artificial++;
                    }
                    else if (course == "Advanced Database")
                    {
                        database++;
                    }
                }

                dataTable.Rows.Add("Application Development", application);
                dataTable.Rows.Add("Artificial Intelligence", artificial);
                dataTable.Rows.Add("Advanced Database", database);

                dataGridWeeklyReport.ItemsSource = dataTable.DefaultView;

                MessageBox.Show("Report showing total number of Students enrolled in each course; is generated.", "Report Generated!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch
            {
                MessageBox.Show("No xml file is created to get and show data from.", "Xml file not created!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);   
            }
        }
    }
}
