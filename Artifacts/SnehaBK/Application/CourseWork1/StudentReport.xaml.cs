using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
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

namespace CourseWork1
{

    public partial class StudentReport : Window
    {
        private DataTable buffer;
     

        public StudentReport()
        {
            InitializeComponent();
        }


        private void DataShow()
        {
            string dataXMLFile = @"D:\studentData.xml";
            System.Data.DataSet dataset = new DataSet();
            dataset.ReadXml(dataXMLFile);
            buffer = dataset.Tables[0];
            //buffer = new DataTable("dt"); 

            //buffer.Columns.Add("Reg No", typeof(String));
            //buffer.Columns.Add("Name", typeof(String));
            //buffer.Columns.Add("Address", typeof(String));
            //buffer.Columns.Add("Contact", typeof(String));
            //buffer.Columns.Add("CourseEnrol", typeof(String));
            //buffer.Columns.Add("RegistrationDate", typeof(String));

            //for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            //{
            //    string s = dataset.Tables[0].Rows[i][5].ToString();
            //    DateTime dtime = DateTime.Today;
            //    buffer.Rows.Add(
            //        dataset.Tables[0].Rows[i][0].ToString(),
            //        dataset.Tables[0].Rows[i][1].ToString(),
            //        dataset.Tables[0].Rows[i][2].ToString(),
            //        dataset.Tables[0].Rows[i][3].ToString(),
            //        dataset.Tables[0].Rows[i][4].ToString(),
            //        dtime.ToShortDateString());
            //}
            DataView dataView = new DataView(buffer);
            DataGrid2.ItemsSource = dataView;
        }
        private void BtnDate_Click(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(buffer);
            dataView.Sort = "RegistrationDate ASC";
            DataGrid2.ItemsSource = dataView;
        }

        private void BtnSortName_Click(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(buffer);
            dataView.Sort = "Name ASC";
            DataGrid2.ItemsSource = dataView;
        }

        private void BtnRetrive_Click(object sender, RoutedEventArgs e)
        {
            DataShow();
        }

        private void BtnWeekReport_Click(object sender, RoutedEventArgs e)
        {

            var dataset = new DataSet(); // declaring new data set
            dataset.ReadXml(@"D:\studentData.xml");  // reading main report
            DataTable stdReport = dataset.Tables[0];
            int total_Com = 0;   // assigning initial values of Course to 
            int total_Mul = 0;
            int total_Net = 0;

            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enroll", typeof(String));  // creating two columns
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < stdReport.Rows.Count; i++)
            {


                String col = stdReport.Rows[i]["CourseEnrol"].ToString();
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




        private void BtnCsv_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"D:\studentData.xml");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files|*.csv";
            bool? fileselect = openFileDialog.ShowDialog();
            if (fileselect == true)
            {
                string filePath = openFileDialog.FileName;
                //read all std from file code copy  

                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        var newRow = dataSet.Tables["Student"].NewRow();
                        //newRow["Reg No"] = values[0];
                        newRow["Name"] = values[1];
                        newRow["Address"] = values[2];
                        newRow["Contact"] = values[3];
                        newRow["CourseEnrol"] = values[4];
                        newRow["RegistrationDate"] = values[5];
                        dataSet.Tables["Student"].Rows.Add(newRow);

                    }
                    dataSet.WriteXml(@"D:\studentData.xml");
                    DataGrid2.ItemsSource = dataSet.Tables["Student"].DefaultView;
                }

            }
        }
    }
}

