using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace Student_Information_System
{
    /// <summary>
    /// Interaction logic for StudentReport.xaml
    /// </summary>
    public partial class StudentReport : Window
    {
        DataTable buffer;
        public StudentReport()
        {

            InitializeComponent();
        }
        private void DataShow()
        {
            string dataXMLFile = @"D:\student.xml";
            System.Data.DataSet dataset = new DataSet();
            dataset.ReadXml(dataXMLFile);

            buffer = new DataTable("dt");
            buffer.Columns.Add("ID", typeof(String));
            buffer.Columns.Add("Name", typeof(String));
            buffer.Columns.Add("Address", typeof(String));
            buffer.Columns.Add("Contact", typeof(String));
            buffer.Columns.Add("CourseEnrol", typeof(String));
            buffer.Columns.Add("RegistrationDate", typeof(DateTime));

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                string s = dataset.Tables[0].Rows[i][5].ToString();
                DateTime dtime = DateTime.Parse(s);
                buffer.Rows.Add(
                    dataset.Tables[0].Rows[i][0].ToString(),
                    dataset.Tables[0].Rows[i][1].ToString(),
                    dataset.Tables[0].Rows[i][2].ToString(),
                    dataset.Tables[0].Rows[i][3].ToString(),
                    dataset.Tables[0].Rows[i][4].ToString(),
                    dtime.ToShortDateString());

            }
            DataView dataView = new DataView(buffer);
            DataGrid2.ItemsSource = dataView;
        }

        private void Btn_Date(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(buffer)
            {
                Sort = "RegistrationDate ASC"
            };
            DataGrid2.ItemsSource = dataView;
        }

        private void Btn_SortName(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(buffer)
            {
                Sort = "Name ASC"
            };
            DataGrid2.ItemsSource = dataView;

        }

        private void Btn_Retrive(object sender, RoutedEventArgs e)
        {
            DataShow();
        }



        private void Btn_WeeklyReport_Click(object sender, RoutedEventArgs e)
        {
            DataSet dataset = new DataSet(); // declaring new data set
            dataset.ReadXml(@"D:\student.xml");  // reading main report
            DataTable StudentReport = dataset.Tables[0];
            int total_Com = 0;   // assigning initial values of Course to 
            int total_Mul = 0;
            int total_Net = 0;

            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enroll", typeof(String));  // creating two columns
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < StudentReport.Rows.Count; i++)
            {


                String col = StudentReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    total_Com++;   // incrementing values of each course based on user input
                }
                else if (col == "Multimedia Technologies")
                {
                    total_Mul++;
                }
                else if (col == "Networks and IT Security")
                {
                    total_Net++;
                }
            }

            dt.Rows.Add("Computing", total_Com);          // final assign
            dt.Rows.Add("Multimedia Technologies", total_Mul);
            dt.Rows.Add("Networks and IT Security", total_Net);


            DataGrid2.ItemsSource = dt.DefaultView; // is the name of data grid

        }

        private void BtnChart(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.ShowDialog();
            this.Hide();

        }
    }
}
