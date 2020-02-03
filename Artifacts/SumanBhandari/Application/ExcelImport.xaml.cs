using DataHandler;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentRegistration
{
    /// <summary>
    /// Interaction logic for ExcelImport.xaml
    /// </summary>
    public partial class ExcelImport : Window
    {
        private string CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\StudentCWData.xml";
        private string fileName;
        public ExcelImport()
        {
            InitializeComponent();
        }
        //this method opens file choser to select csv file 
        private void browseExcel_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".csv";
            openfile.Filter = "(.csv)|*.csv";
            openfile.ShowDialog();
            fileName = openfile.FileName;
            excelFilepath.Text = fileName;
            var student = ReadData();
            datagrid.ItemsSource = student;
        }
        //this method is used to read data from csv file
        public List<StudentInfo> ReadData()
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("Student Info file doesn't exist");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry! unexpected Error occured! try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            List<StudentInfo> students = new List<StudentInfo>();
            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    streamReader.ReadLine();
                    while (streamReader.Peek() != -1)
                    {
                        var studentString = streamReader.ReadLine();
                        var studentInfo = new StudentInfo(studentString);
                        students.Add(studentInfo);

                    }

                    streamReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry! unexpected Error occured! try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                ExcelImport excellImport = new ExcelImport();
                excellImport.Show();
            }
            return students;
        }

        //this method is used to save data from excel to xml
        private void saveExcel_Click(object sender, RoutedEventArgs e)
        {
            var dataHandler = new datahandler();
            var dataSet = dataHandler.CreateDataSet();
            SaveData(dataSet);
            if (File.Exists(CurrentPath))
            {
                dataSet.ReadXml(CurrentPath);
                dataSet.WriteXml(CurrentPath);
                System.Windows.MessageBox.Show("Enroled Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                dataSet.WriteXml(CurrentPath);
                System.Windows.MessageBox.Show("Enroled Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                if (MessageBoxResult.OK.Equals(1))
                {
                    this.Close();
                }

            }
        }

        private void SaveData(DataSet dataSet)
        {
            var stdData = ReadData();
            foreach (StudentInfo students in stdData)
            {
                var dr = dataSet.Tables["student"].NewRow();
                dr["stdId"] = students.stdId;
                dr["firstName"] = students.FirstName;
                dr["lastName"] = students.LastName;
                dr["gender"] = students.gender;
                dr["ContactNo"] = students.Phone;
                dr["email"] = students.Email;
                dr["CourseEnroll"] = students.CourseEnroll;
                dr["zone"] = students.Zone;
                dr["District"] = students.District;
                dr["Tole"] = students.Tole;
                dr["guardianNo"] = students.guardianNo;
                dr["RegistrationDate"] = DateTime.Today;
                dataSet.Tables["Student"].Rows.Add(dr);

            }
        }

    }
    //this class contains getter and setter for student data
    public class StudentInfo
    {
        public StudentInfo() { }

        public StudentInfo(string studentString)
        {
            this.ConvertToObject(studentString);
        }
        public string stdId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string gender { get; set; }
        public string Zone { get; set; }
        public string District { get; set; }
        public string Tole { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string guardianNo { get; set; }   
        public string CourseEnroll { get; set; }

       public override string ToString()
        {
            return $"{this.stdId}:{this.FirstName}:{this.LastName}:{this.gender}:{this.Zone}:{this.District}:{this.Tole}:{this.Phone}:{this.Email}:{this.guardianNo}:{this.CourseEnroll}";
        }
        //this method extract data from file by splliting data with certain symbol
        private void ConvertToObject(string studentString)
        {
            var splitedStrings = studentString.Split(',');
            this.stdId = splitedStrings[0];
            this.FirstName = splitedStrings[1];
            this.LastName = splitedStrings[2];
            this.gender = splitedStrings[3];
            this.Zone = splitedStrings[4];
            this.District = splitedStrings[5];
            this.Tole = splitedStrings[6];
            this.Phone = splitedStrings[7];
            this.Email = splitedStrings[8];
            this.guardianNo = splitedStrings[9];
            this.CourseEnroll = splitedStrings[10];
        }

    }
}

