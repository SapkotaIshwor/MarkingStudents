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
using System.IO;
using Microsoft.Win32;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for StudentDetailForm.xaml
    /// </summary>
    public partial class StudentDetailForm : Window
    {
        public StudentDetailForm()
        {
            InitializeComponent();

            //add new student

            LoadGrid();
        }

        public class Student
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Contact { get; set; }
            public string CourseEnrol { get; set; }
            public string RegistrationDate { get; set; }
        }

        private void AddStudentData(DataSet dataSet)
        {
            var newRow = dataSet.Tables["Student"].NewRow();
            newRow["ID"] = txtStdID.Text;
            newRow["Name"] = txtStdName.Text;
            newRow["Address"] = txtStdAdd.Text;
            newRow["Contact"] = txtStdCont.Text;
            newRow["CourseEnrol"] = courseEnrol.Text;
            newRow["RegistrationDate"] = registrationDate.SelectedDate;
            dataSet.Tables["Student"].Rows.Add(newRow);
        }


        private void btn_Save(object sender, RoutedEventArgs e)
        {
            if (txtStdID.Text == "" || txtStdName.Text == "" || txtStdAdd.Text == "" || txtStdCont.Text == "" || courseEnrol.Text == "" || registrationDate.Text == "")
            {
                MessageBox.Show("Please, fill the box.");
            }
            else
            {
                try
                {
                    var handler = new DataHandler();
                    var dataSet = new DataSet();

                    if (File.Exists(@"D:\student.xml"))
                    {
                        dataSet.ReadXml(@"D:\student.xml");
                        //dataSet.WriteXml(@"D:\Data\student.xml");
                    }
                    else
                    {
                        dataSet = handler.CreateDataSet();
                    }
                    AddStudentData(dataSet);
                    dataSet.WriteXml(@"D:\student.xml");
                    LoadGrid();

                    MessageBox.Show("Student Added Succcessfully");
                }
                catch (Exception)
                {

                }
            }



        }

        public void LoadGrid()
        {
            var dataSet = new DataSet();

            if (File.Exists(@"D:\student.xml"))
            {
                dataSet.ReadXml(@"D:\student.xml");
                DataGridXAML.ItemsSource = dataSet.Tables["Student"].DefaultView;
            }
        }

        private void btn_Import(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"D:\student.xml");
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
                        newRow["CourseEnrol"] = values[4];
                        newRow["RegistrationDate"] = values[5];
                        dataSet.Tables["Student"].Rows.Add(newRow);

                        dataSet.WriteXml(@"D:\student.xml");

                    }
                }
                DataGridXAML.ItemsSource = dataSet.Tables["Student"].DefaultView;
            }
        }

        private void btn_Sorting(object sender, RoutedEventArgs e)
        {
            Sorting sorting = new Sorting();
            sorting.ShowDialog();
        }

        private void btnWeeklyReport_Click(object sender, RoutedEventArgs e)
        {
            WeeklyReport weelkyReport = new WeeklyReport();
            weelkyReport.ShowDialog();
        }

        private void btn_Chart(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }
    }
}
