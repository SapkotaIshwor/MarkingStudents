using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for ImportCSV.xaml
    /// </summary>
    public partial class ImportCSV : Window
    {
        DataTable dataTable;
        public ImportCSV()
        {
            InitializeComponent();
        }

        private void DataGridShow()
        {
            string dataXMLFile = @"C:\DataHandler\StudentData.xml";
            System.Data.DataSet dataset = new DataSet();
            dataset.ReadXml(dataXMLFile);

            dataTable = new DataTable("dt");
            dataTable.Columns.Add("studentId", typeof(String));
            dataTable.Columns.Add("studentName", typeof(String));
            dataTable.Columns.Add("studentAddress", typeof(String));
            dataTable.Columns.Add("studentContact", typeof(String));
            dataTable.Columns.Add("courseEnrol", typeof(String));
            dataTable.Columns.Add("registrationDate", typeof(String));

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                string s = dataset.Tables[0].Rows[i][5].ToString();
                DateTime dtime = DateTime.Parse(s);
                dataTable.Rows.Add(
                    dataset.Tables[0].Rows[i][0].ToString(),
                    dataset.Tables[0].Rows[i][1].ToString(),
                    dataset.Tables[0].Rows[i][2].ToString(),
                    dataset.Tables[0].Rows[i][3].ToString(),
                    dataset.Tables[0].Rows[i][4].ToString(),
                    dtime.ToShortDateString());
            }
            DataView dataView = new DataView(dataTable);
            DataGridXAML2.ItemsSource = dataView;
        }

        private void btnRetrieve_click(object sender, RoutedEventArgs e)
        {
            DataGridShow();
        }
        private void btnImport_click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"C:\DataHandler\StudentData.xml");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
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
                        newRow["studentId"] = values[0];
                        newRow["studentName"] = values[1];
                        newRow["studentAddress"] = values[2];
                        newRow["studentContact"] = values[3];
                        newRow["courseEnrol"] = values[4];
                        newRow["registrationDate"] = values[5];
                        dataSet.Tables["Student"].Rows.Add(newRow);

                        dataSet.WriteXml(@"C:\DataHandler\StudentData.xml");
                    }
                }
                DataGridXAML2.ItemsSource = dataSet.Tables["Student"].DefaultView;
            }
        }


        private void btnName_Sort(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = "studentName";
            DataGridXAML2.ItemsSource = dataView;
        }

        private void btnRegDate_Sort(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = "registrationDate";
            DataGridXAML2.ItemsSource = dataView;


        }



        private void btnWeek_Report(object sender, RoutedEventArgs e)
        {
            // declaring new data set
            var dataset = new DataSet();

            // reading main report
            dataset.ReadXml(@"C:\DataHandler\StudentData.xml");
            DataTable stdReport = dataset.Tables[0];
            // assigning initial values of Course to 
            int computing = 0;
            int multimedia = 0;
            int networking = 0;

            DataTable dt = new DataTable("dt");
            dt.Columns.Add("Course Enroll", typeof(String));  // creating two columns
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < stdReport.Rows.Count; i++)
            {


                String col = stdReport.Rows[i]["courseEnrol"].ToString();
                if (col == "Computing")
                {
                    computing++;   // incrementing values of each course based on user input
                }
                else if (col == "Multimedia Technologies")
                {
                    multimedia++;
                }
                else if (col == "Networks and IT Security")
                {
                    networking++;
                }
            }

            dt.Rows.Add("Computing", computing);          // final assign
            dt.Rows.Add("Multimedia Technologies", multimedia);
            dt.Rows.Add("Networks and IT Security", networking);


            DataGridXAML2.ItemsSource = dt.DefaultView; // is the name of data grid

        }

 

        private void btnImportBack_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StartPage goBack = new StartPage();
            goBack.ShowDialog();
        }
    }
}
