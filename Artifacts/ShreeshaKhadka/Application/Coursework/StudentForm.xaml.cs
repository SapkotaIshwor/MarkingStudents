using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Win32;
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

namespace Coursework
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

        private void buttonsave(object sender, RoutedEventArgs e)
        {
            if (studentid.Text == "" || studentname.Text == "" || studentaddress.Text == "" ||
                studentcontact.Text == "" || studentcourse.Text == "" || studentdate.Text == "") 
            {
                MessageBox.Show("Please fill the student details.");

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

                    }
                    else
                    {
                        dataSet = handler.CreateDataSet();

                    }
                    AddStudentData(dataSet);
                    dataSet.WriteXml(@"D:\student.xml");
                    LoadGrid();

                    MessageBox.Show("Success");

                }
                catch(Exception)
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
                DataGridView1.ItemsSource = dataSet.Tables["Student"].DefaultView;
            }

        }

        private void AddStudentData(DataSet dataSet)
        {
            var newRow = dataSet.Tables["Student"].NewRow();
            newRow["ID"] = studentid.Text;
            newRow["Name"] = studentname.Text;
            newRow["Address"] = studentaddress.Text;
            newRow["Contact"] = studentcontact.Text;
            newRow["CourseEnroll"] = studentcourse.Text;
            newRow["RegistrationDate"] = studentdate.SelectedDate;
            dataSet.Tables["Student"].Rows.Add(newRow);
        }

        private void buttonimport(object sender, RoutedEventArgs e)
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
                        newRow["CourseEnroll"] = values[4];
                        newRow["RegistrationDate"] = values[5];
                        dataSet.Tables["Student"].Rows.Add(newRow);

                        dataSet.WriteXml(@"D:\student.xml");

                    }
                }
                DataGridView1.ItemsSource = dataSet.Tables["Student"].DefaultView;
            }
        }

        private void buttonreport(object sender, RoutedEventArgs e)
        {
            WeeklyReport weeklyReport = new WeeklyReport();
            weeklyReport.ShowDialog();

        }

        private void buttonbysort(object sender, RoutedEventArgs e)
        {
            SortingDetail sortingDetail = new SortingDetail();
            sortingDetail.ShowDialog();
        }

       
        private void buttonreportchart(object sender, RoutedEventArgs e)
        {
            ChartEnroll chartEnroll = new ChartEnroll();
            chartEnroll.ShowDialog();

        }
    }
}



