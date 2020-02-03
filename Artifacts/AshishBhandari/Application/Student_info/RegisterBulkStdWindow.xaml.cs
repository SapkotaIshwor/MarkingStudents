using FileHelpers;
using Microsoft.Win32;
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

namespace Student_info
{
    /// <summary>
    /// Interaction logic for RegisterBulkStdWindow.xaml
    /// </summary>
    public partial class RegisterBulkStdWindow : Window
    {
        private string fileName;
        private List<StudentInfo> csvStudentList;
        public RegisterBulkStdWindow()
        {
            InitializeComponent();     

        }

       public void Save(StudentInfo studentInfo)
            {
                if (!File.Exists(fileName))
                {
                    var file = File.Create(fileName);
                    file.Close();
                }

                using (StreamWriter streamWriter = new StreamWriter(fileName, true))
                {
                    streamWriter.WriteLine(studentInfo.ToString());
                    streamWriter.Close();
                }
            }

        public List<StudentInfo> ReadAll()
        {
            try { 
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
                RegisterMainWindow registerMainWindow = new RegisterMainWindow();
                registerMainWindow.Show();
            }
            return students;
            }

        

        private void fileChooseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open csv File";
            theDialog.Filter = "CSV files|*.csv";
            theDialog.InitialDirectory = @"C:\";
            theDialog.ShowDialog();

            fileName = theDialog.FileName;

            csvStudentList = ReadAll();
            gridView.ItemsSource = csvStudentList;
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
             dataSet = new DataSet();
            if (File.Exists(@"D:\Student_Management\StudentRegistrationData.xml"))
            {
                dataSet.ReadXml(@"D:\Student_Management\StudentRegistrationData.xml");
                AddData(dataSet);
                dataSet.WriteXml(@"D:\Student_Management\StudentRegistrationData.xml");
            }

            else
            {
                handler = new Handler();
                dataSet = handler.CreateDataSet();
                AddData(dataSet);
                dataSet.WriteXmlSchema(@"D:\Student_Management\StudentRegistrationSchema.xml");
                dataSet.WriteXml(@"D:\Student_Management\StudentRegistrationData.xml");


            }
            MessageBox.Show("Successfully Registered");
            this.Close();
            RegisterMainWindow registerMainWindow = new RegisterMainWindow();
            registerMainWindow.Show();
            
        }
        private void AddData(DataSet dataSet)
        {
            var studentData = ReadAll();
            foreach (StudentInfo stdData in studentData)
            {
                var dr = dataSet.Tables["Student"].NewRow();
                dr["Name"] = stdData.Name;
                dr["StudentID"] = Convert.ToInt32(stdData.StudentID);
                dr["Department"] = stdData.Department;
                dr["Faculty"] = stdData.Faculty;
                dr["Program"] = stdData.Program; 
                dr["Phone"] = Convert.ToInt32(stdData.Phone);
                dr["Email"] = stdData.Email;
                dr["Gender"] = stdData.Gender;
                dr["CurrentAddress"] = stdData.CurrentAddress;
                dr["PermanentAddress"] = stdData.PermanentAddress;
                dr["Religion"] = stdData.Religion;
                dr["Nationality"] = stdData.Nationility; 
                dr["MaritalStatus"] = stdData.MarritalStatus;
                dr["RegistrationDate"] = stdData.RegistrationDate;
                dataSet.Tables["Student"].Rows.Add(dr);
            }
                      

        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure wanna cancel ?", "Cancel Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Hide();

                RegisterMainWindow RmWindow = new RegisterMainWindow();
                RmWindow.Show();
            }
            else
            {
                //
            }

         
        }

        private void gridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class StudentInfo
    {

        public StudentInfo(string studentString)
        {
            this.ConvertToObject(studentString);
        }
        public string Name { get; set; }
        public string StudentID { get; set; }
        public string Department { get; set; }
        public string Faculty { get; set; }
        public string Program { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Religion { get; set; }
        public string Nationility { get; set; }
        public string MarritalStatus { get; set; }
        public string RegistrationDate { get; set; }

        public override string ToString()
        {
            return $"{this.Name}:{this.StudentID}:{this.Department}:{this.Faculty}:{this.Program}:{this.Phone}:{this.Email}:{this.Gender}:{this.CurrentAddress}:{this.PermanentAddress}:{this.Religion}:{this.Nationility}:{this.RegistrationDate}";
        }

  

        private void ConvertToObject(string studentString)
        {
            var splitedStrings = studentString.Split(',');
            this.Name = splitedStrings[0];
            this.StudentID = splitedStrings[1];
            this.Department = splitedStrings[2];
            this.Faculty = splitedStrings[3];
            this.Program = splitedStrings[4];
            this.Phone = splitedStrings[5];
            this.Email = splitedStrings[6];
            this.Gender = splitedStrings[7];
            this.CurrentAddress = splitedStrings[8];
            this.PermanentAddress = splitedStrings[9];
            this.Religion= splitedStrings[10];
            this.Nationility = splitedStrings[11];
            this.MarritalStatus = splitedStrings[12];
            this.RegistrationDate = splitedStrings[13];

        }

    }
}
