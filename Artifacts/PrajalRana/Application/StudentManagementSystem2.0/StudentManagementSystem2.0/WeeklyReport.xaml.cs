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

namespace StudentManagementSystem2._0 {
    /// <summary>
    /// Interaction logic for WeeklyReport.xaml
    /// </summary>
    public partial class WeeklyReport : Window {

        public WeeklyReport() {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e) {

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var dataset = new DataSet(); // declaring new data set
            dataset.ReadXml(@"E:\College\3rd Year\Application Development\StudentReport.xml");  // reading report
            DataTable stdReport = dataset.Tables[0];
            int total_Com = 0;   // assigning initial values of Course to 0
            int total_Mul = 0;
            int total_Net = 0;

            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enroll", typeof(String));  // creating two columns
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < stdReport.Rows.Count; i++)
            {


                String col = stdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    total_Com++;   // incrementing values of each course based on user input
                }
                else if (col == "Multimedia Technology")
                {
                    total_Mul++;
                }
                else if (col == "Networking")
                {
                    total_Net++;
                }
            }

            dt.Rows.Add("Computing", total_Com);          // assigning vlaues
            dt.Rows.Add("Multimedia Technology", total_Mul);
            dt.Rows.Add("Networking", total_Net);


            gridWeeklyReport.DataContext = dt.DefaultView; // view in data grid
        }
    
  
    }
}
