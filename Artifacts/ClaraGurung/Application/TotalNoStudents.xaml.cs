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
using System.Xml.Serialization;



namespace Coursework
{
    /// <summary>
    /// Interaction logic for TotalNoStudents.xaml
    /// </summary>
    public partial class TotalNoStudents : Window
    {
        public TotalNoStudents()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void TotalStudents_Click(object sender, RoutedEventArgs e)
        {
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
                else if (col.Equals ("Multimedia Technology"))
                {
                    total_Multimedia++;
                }
            }

            dataTable.Rows.Add("Computing", total_Computing);
            dataTable.Rows.Add("Networks And IT Security", total_Network);
            dataTable.Rows.Add("Multimedia Technology", total_Multimedia);

            Console.WriteLine(dataTable.Rows.Count);

            StudentDataGrid.DataContext = dataTable.DefaultView;
        }
        }
    }


