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
using DataHandler;
using Microsoft.Win32;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        DataTable dataTable;
        public StudentForm()
        {
            InitializeComponent();
            loadGrid();
        }
        public void loadGrid()
        {
            if (File.Exists(@"E:\student.xml"))
            {


                var dataSet = new DataSet();
                dataSet.ReadXml(@"E:\student.xml");
                dataTable = dataSet.Tables["Student"];
                DataGridXAML.ItemsSource = dataSet.Tables["Student"].DefaultView;

            }
        }




        public class Student
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }

            public string Contact { get; set; }
            public string CourseEnroll { get; set; }
            public string RegistrationDate { get; set; }
        }



        private void buttonclick(object sender, RoutedEventArgs e)
        {

            var handler = new Handler();
            var dataSet = new DataSet();

            if (File.Exists(@"E:\student.xml"))
            {

                dataSet.ReadXml(@"E:\student.xml");
            }
            else
            {
                dataSet = handler.CreateDataSet();

            }
            AddSampleData(dataSet);
            dataSet.WriteXml(@"E:\student.xml");
            loadGrid();
        }





        private void AddSampleData(DataSet dataSet)
        {
            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["ID"] = Studentid.Text;
            dr1["Name"] = Studentname.Text;
            dr1["Address"] = StudentAddress.Text;
            dr1["Contact"] = Studentcontact.Text;
            dr1["CourseEnroll"] = Courseenroll.Text;
            dr1["RegistrationDate"] = Regdate.Text;
            dataSet.Tables["Student"].Rows.Add(dr1);
        }

        private void import_click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"E:\student.xml");
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
                        newRow["ID"] = values[0];
                        newRow["Name"] = values[1];
                        newRow["Address"] = values[2];
                        newRow["Contact"] = values[3];
                        newRow["CourseEnroll"] = values[4];
                        newRow["RegistrationDate"] = values[5];
                        dataSet.Tables["Student"].Rows.Add(newRow);

                        dataSet.WriteXml(@"E:\student.xml");
                    }
                }
            }
        }

        private void sort_name(object sender, RoutedEventArgs e)
        {
            dataTable.DefaultView.Sort = "Name ASC";
            DataGridXAML.DataContext = dataTable.DefaultView;
        }

        private void sortdate(object sender, RoutedEventArgs e)
        {
            dataTable.DefaultView.Sort = "RegistrationDate ASC";
            DataGridXAML.DataContext = dataTable.DefaultView;
        }

        private void weekreport(object sender, RoutedEventArgs e)
        {
            Weekreport weekreport = new Weekreport();
            weekreport.ShowDialog();
        }

        private void chartclick(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }


        
    }
}

        
  

        
    











        
        
               


