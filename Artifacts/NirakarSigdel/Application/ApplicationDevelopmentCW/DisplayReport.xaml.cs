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

namespace ApplicationDevelopmentCW
{
    /// <summary>
    /// Interaction logic for DisplayReport.xaml
    /// </summary>
    public partial class DisplayReport : Window
    {
        DataTable buffer;

        public DisplayReport()
        {
            InitializeComponent();
        }

        private void show_data()
        {
            String dataXML = @"D:\student.xml";
            DataSet dataset = new DataSet();
            dataset.ReadXml(dataXML);

            buffer = new DataTable("dt");
            buffer.Columns.Add("ID", typeof(String));
            buffer.Columns.Add("Name", typeof(String));
            buffer.Columns.Add("Address", typeof(String));
            buffer.Columns.Add("ContactNo", typeof(String));
            buffer.Columns.Add("Email", typeof(String));
            buffer.Columns.Add("CourseEnroll", typeof(String));
            buffer.Columns.Add("RegDate", typeof(String));

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                string s = dataset.Tables[0].Rows[i][6].ToString();
                DateTime dtime = DateTime.Parse(s);
                buffer.Rows.Add(
                    dataset.Tables[0].Rows[i][0].ToString(),
                    dataset.Tables[0].Rows[i][1].ToString(),
                    dataset.Tables[0].Rows[i][2].ToString(),
                    dataset.Tables[0].Rows[i][3].ToString(),
                    dataset.Tables[0].Rows[i][4].ToString(),
                    dataset.Tables[0].Rows[i][5].ToString(),
                    dtime.ToShortDateString());
            }
            DataView dataV = new DataView(buffer);
            DataGridReport.ItemsSource = dataV;
        }

        private void buttonRetrive_Click(object sender, RoutedEventArgs e)
        {
            show_data();
            //var dataSet = new DataSet();
            //dataSet.ReadXml(@"D:\student.xml");
            //DataTable dtStdReport = dataSet.Tables[0];

            //int total_Com = 0;
            //int total_Net = 0;
            //int total_Mul = 0;

            //DataTable dt = new DataTable("newTable");
            //dt.Columns.Add("CourseEnroll", typeof(string));
            //dt.Columns.Add("Total Students", typeof(int));

            //for (int i = 0; i < dtStdReport.Rows.Count; i++)
            //{
            //    string col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
            //    if (col == "Computing")
            //    {
            //        total_Com++;
            //    }
            //    else if (col == "Networking")
            //    {
            //        total_Net++;
            //    }
            //    else if (col == "Multimedia")
            //    {
            //        total_Mul++;
            //    }

            //}
            //dt.Rows.Add("Networking", total_Net);
            //dt.Rows.Add("Computing", total_Com);
            //dt.Rows.Add("Multimedia", total_Mul);
            //grdreport.DataContext = dt.DefaultView;

        }

        private void buttonSName_Click(object sender, RoutedEventArgs e)
        {
            DataView dataV = new DataView(buffer);
            dataV.Sort = "Name ASC";
            DataGridReport.ItemsSource = dataV;
        }

        private void buttonSD_Click(object sender, RoutedEventArgs e)
        {
            DataView dataV = new DataView(buffer);
            dataV.Sort = "RegDate ASC";
            DataGridReport.ItemsSource = dataV;
        }



        private void DataGridReport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
        private void buttonWeekly_Click_1(object sender, RoutedEventArgs e)
        {
            
                var dataSet = new DataSet();
                dataSet.ReadXml(@"D:\student.xml");
                DataTable dtStudentReport = dataSet.Tables[0];

                int total_Computing = 0;
                int total_Networking = 0;
                int total_Multimedia = 0;

                DataTable dt = new DataTable("newTable");
                dt.Columns.Add("Course Enroll", typeof(String));
                dt.Columns.Add("Total Students", typeof(int));

                for (int i = 0; i < dtStudentReport.Rows.Count; i++)
                {
                    String col = dtStudentReport.Rows[i]["CourseEnroll"].ToString();
                    if (col == "Computing")
                    {
                        total_Computing++;
                    }
                    else if (col == "Networking")
                    {
                        total_Networking++;
                    }
                    else if (col == "Multimedia")
                    {
                        total_Multimedia++;
                    }
                }
                dt.Rows.Add("Computing", total_Computing);
                dt.Rows.Add("Networking", total_Networking);
                dt.Rows.Add("Multimedia", total_Multimedia);

                DataGridReport.DataContext = dt.DefaultView;
            
        }



        private void buttonChart_Click_1(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();

        }
    }
}
