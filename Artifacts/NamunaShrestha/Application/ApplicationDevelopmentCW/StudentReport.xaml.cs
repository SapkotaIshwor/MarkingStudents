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
    
    public partial class StudentReport : Window
    {
        DataTable buffer;
        public StudentReport()
        {
            InitializeComponent();
        }
        private void display_data()
        {
            string dataXMLFile = @"D:\studentData.xml";
            DataSet dataset = new DataSet();
            dataset.ReadXml(dataXMLFile);

            buffer = new DataTable("dt"); //creating data table dt and assigning to buffer
            buffer.Columns.Add("ID", typeof(String));
            buffer.Columns.Add("Name", typeof(String));
            buffer.Columns.Add("Address", typeof(String));
            buffer.Columns.Add("ContactNo", typeof(String));
            buffer.Columns.Add("Email", typeof(String));
            buffer.Columns.Add("CourseEnroll", typeof(String));
            buffer.Columns.Add("RegDate", typeof(String));

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++) // Changing GMt format to local time zone
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
            DataView dataView = new DataView(buffer); // setting the itemsource to table
            DataGridRp.ItemsSource = dataView;

        }
       private void BtnAdd_Click(object sender, RoutedEventArgs e)
       {
             MainWindow mainWindow = new MainWindow();
             mainWindow.Show();
       }

        private void BtnRetriveData_Click(object sender, RoutedEventArgs e)
        {
            display_data();
        }    

        private void BtnSortByDate_Click(object sender, RoutedEventArgs e)
        {
            DataView view = new DataView(buffer);
            view.Sort = "RegDate ASC";
            DataGridRp.ItemsSource = view;
        }

        private void BtnSortByName_Click(object sender, RoutedEventArgs e)
        {
            DataView view = new DataView(buffer);
            view.Sort = "Name ASC";
            DataGridRp.ItemsSource = view;
        }

        //private void BtnSortByName_Click(object sender, RoutedEventArgs e)
        //{
        //    var dataset = new DataSet();
        //    dataset.ReadXml(@"D:\studentData.xml");
        //    DataTable stdReport = dataset.Tables[0];
        //    int total_Mar = 0;
        //    int total_BBA = 0;
        //    int total_BIT = 0;

        //    DataTable dt = new DataTable("tbl");
        //    dt.Columns.Add("Course Enroll", typeof(String));
        //    dt.Columns.Add("Total Students", typeof(int));

        //    for (int i = 0; i < stdReport.Rows.Count; i++)
        //    {


        //        String col = stdReport.Rows[i]["CourseEnroll"].ToString();
        //        if (col == "Computing")
        //        {
        //            total_Mar++;
        //        }
        //        else if (col == "Multimedia Technology")
        //        {
        //            total_BBA++;
        //        }
        //        else if (col == "Networking")
        //        {
        //            total_BIT++;
        //        }
        //    }

        //    dt.Rows.Add("Computing", total_Mar);
        //    dt.Rows.Add("Multimedia Technology", total_BBA);
        //    dt.Rows.Add("Networking", total_BIT);


        //    DataGridRp.DataContext = dt.DefaultView;
        //}
    }
    
}
