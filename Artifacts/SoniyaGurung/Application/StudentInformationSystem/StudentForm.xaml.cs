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
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        public StudentForm()
        {
            InitializeComponent();

            LoadGrid();
        }

        private void AddStudentData(DataSet dataSet)
        {
            var newRow = dataSet.Tables["Student"].NewRow();
            newRow["ID"] = txtID.Text;
            newRow["Name"] = txtName.Text;
            newRow["Address"] = txtAddress.Text;
            newRow["Contact"] = txtContact.Text;
            newRow["CourseEnroll"] = cEnroll.Text;
            newRow["RegistrationDate"] = rDate.SelectedDate;
            dataSet.Tables["Student"].Rows.Add(newRow);
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

        private void BtnImport(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"C:\XML\student.xml");
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

                        dataSet.WriteXml(@"C:\XML\student.xml");
                    }
                }
                DataGridXAML.ItemsSource = dataSet.Tables["Student"].DefaultView;
            }
        }

        public void LoadGrid()
        {
            var dataSet = new DataSet();
            if (File.Exists(@"C:\XML\student.xml"))
            {
                dataSet.ReadXml(@"C:\XML\student.xml");
                DataGridXAML.ItemsSource = dataSet.Tables["Student"].DefaultView;
            }
        }

        private void BtnSave(object sender, RoutedEventArgs e)
        {
            if (txtID.Text == "" || txtName.Text == "" || txtAddress.Text == "" || txtContact.Text == "" ||
                txtContact.Text == "" || cEnroll.Text == "" || rDate.Text == "")
            {
                MessageBox.Show("Fill all students details.");
            }
            else
            {
                try
                {
                    var handler = new DataHandler();
                    var dataSet = new DataSet();

                    if (File.Exists(@"C:\XML\student.xml"))
                    {
                        dataSet.ReadXml(@"C:\XML\student.xml");

                    }
                    else
                    {
                        dataSet = handler.CreateDataSet();
                    }

                    AddStudentData(dataSet);
                    dataSet.WriteXml(@"C:\XML\student.xml");
                    LoadGrid();


                    MessageBox.Show("Successfully Added!");
                }
                catch (Exception)
                {

                }

                }
            }
           
        private void BtnWeekly(object sender, RoutedEventArgs e)
        {

            WeeklyReport weeklyR = new WeeklyReport();
            weeklyR.ShowDialog();
        }

        private void BtnSort(object sender, RoutedEventArgs e)
        {
            Sorting sorting = new Sorting();
            sorting.ShowDialog();
        }    

        private void BtnChart(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.ShowDialog();
        }
    }
}
