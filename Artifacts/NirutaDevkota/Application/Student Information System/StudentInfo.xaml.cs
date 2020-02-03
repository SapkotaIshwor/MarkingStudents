using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for StudentInfo.xaml
    /// </summary>
    public partial class StudentInfo : Window
    {
        public StudentInfo()
        {
            InitializeComponent();
            //LoadStudentData();
            LoadGrid();

        }


        //csv to DataTable


        private void BtnSave(object sender, RoutedEventArgs e)
        {
            var handler = new DataHandler();
            var dataSet = new DataSet();

            //var dataSet = new DataSet();
            //dataSet.ReadXmlSchema(@"D:\StudentCWSchema.xml");
            ////dataSet.ReadXml(@"D:\StudentCWData.xml");
            if (txtID.Text == "" || txtName.Text == "" || txtAddress.Text == "" || txtContact.Text == "" || cbCourseEnrol.Text == "" || txtDate.Text == "")
            {
                MessageBox.Show("Enter required information in all fields!");
            }
            else
            {
                try
                {
                    if (File.Exists(@"D:\student.xml"))
                    {
                        dataSet.ReadXml(@"D:\student.xml");
                        //dataSet.ReadXmlSchema(@"D:\StudentCWSchema.xml");

                    }
                    else
                    {
                        dataSet = handler.CreateDataSet();
                        //WriteXml(@"D:\student.xml");
                    }
                    AddStudentData(dataSet);
                    dataSet.WriteXml(@"D:\student.xml");
                    //dataSet.WriteXmlSchema(@"D:\StudentCWSchema.xml");
                    LoadGrid();
                    MessageBox.Show("Sucessfully added!");

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

        private void AddStudentData(DataSet dataSet)
        {
            var newRow = dataSet.Tables["Student"].NewRow();
            newRow["ID"] = txtID.Text;
            newRow["Name"] = txtName.Text;
            newRow["Address"] = txtAddress.Text;
            newRow["Contact"] = txtContact.Text;
            newRow["CourseEnroll"] = cbCourseEnrol.Text;
            newRow["RegistrationDate"] = txtDate.DisplayDate;
            dataSet.Tables["Student"].Rows.Add(newRow);
        }

        private void Btn_Report(object sender, RoutedEventArgs e)
        {

            StudentReport studentReport = new StudentReport();
            studentReport.ShowDialog();
            this.Hide();
        }

        private void Btn_Browse(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".csv";
            openfile.Filter = "(.csv)|*.csv";

            var browsefile = openfile.ShowDialog();

            if (browsefile == true)
            {
                txtFilePath.Text = openfile.FileName;
            }


        }

        private void Btn_ImportCVS(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"D:\student.xml");

            string filePath = txtFilePath.Text;
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
            DataGridXAML.ItemsSource = dataSet.Tables["Student"].DefaultView;
        }

        private void BtnClear(object sender, RoutedEventArgs e)
        {
            DataGridXAML.ItemsSource = null;
            txtFilePath.Text = "";
        }
    }
}


    