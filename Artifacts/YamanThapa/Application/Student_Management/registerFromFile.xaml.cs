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

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for registerFromFile.xaml
    /// </summary>
    public partial class registerFromFile : Window
    {
        string file;
        private List<StudentRegData> bulkstudentDataList;

        public registerFromFile()
        {
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {

            var handler = new Handler();
            var dataSet = handler.GenerateDataSet();

            dataSet = new DataSet();
            if (File.Exists(@"D:\StudentData.xml"))
            {

                dataSet.ReadXml(@"D:\StudentData.xml");
                AddStudentInfo(dataSet);
                dataSet.WriteXmlSchema(@"D:\StudentSchema.xml");
                dataSet.WriteXml(@"D:\StudentData.xml");
                MessageBox.Show("Successfully Registered", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                handler = new Handler();
                dataSet = handler.GenerateDataSet();
                AddStudentInfo(dataSet);
                dataSet.WriteXmlSchema(@"D:\StudentSchema.xml");
                dataSet.WriteXml(@"D:\StudentData.xml");

                MessageBox.Show("Successfully Registered", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


            }
        }
        private void AddStudentInfo(DataSet dataSet)
        {
            var studentData = ReadAll();
            foreach (StudentRegData regdata in studentData)
            {
                var dr = dataSet.Tables["StudentInfo"].NewRow();
                dr["StudentID"] = regdata.StudentID;
                dr["Name"] = regdata.Name;
                dr["Program"] = regdata.Program;
                dr["ParentName"] = regdata.ParentName;
                dr["ParentPhone"] = regdata.ParentPhone;
                dr["StudentPhone"] = regdata.StudentPhone;
                dr["Email"] = regdata.Email;
                dr["Gender"] = regdata.Gender;
                dr["Address"] = regdata.Address;
                dr["RegistrationDate"] = DateTime.Today;
                dataSet.Tables["StudentInfo"].Rows.Add(dr);

            }


        }


        public List<StudentRegData> ReadAll()
        {
         
            List<StudentRegData> studentList = new List<StudentRegData>();

            using (StreamReader streamReader = new StreamReader(file))
            {
                streamReader.ReadLine();

                while (streamReader.Peek() != -1)
                {

                    var studentString = streamReader.ReadLine();
                    var studentInfo = new StudentRegData(studentString);
                    studentList.Add(studentInfo);

                }
                streamReader.Close();
            }
            return studentList;
        }

        private void ChooseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open csv File";
            theDialog.Filter = "CSV files|*.csv";
            theDialog.ShowDialog();
            file = theDialog.FileName;
            bulkstudentDataList = ReadAll();
            studentDataView.ItemsSource = bulkstudentDataList;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            baseWndo bw = new baseWndo();
            bw.Show();
        }
    }

    public class StudentRegData
    {

        public StudentRegData(string studentString)
        {
            this.ConvertToObject(studentString);
        }
        public string Name { get; set; }
        public string StudentID { get; set; }
    
        public string ParentName { get; set; }
        public string ParentPhone { get; set; }
        public string StudentPhone { get; set; }
        public string Email { get; set; }
        public string Program { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string RegistrationDate { get; set; }


        public override string ToString()
        {
            return $"{this.StudentID}:{this.Name}:{this.Program}:{this.ParentName}:{this.ParentPhone}:{this.StudentPhone}:{this.Email}:{this.Gender}:{this.Address}:{this.RegistrationDate}";
        }



        private void ConvertToObject(string studentString)
        {
            var splitedStrings = studentString.Split(',');
            this.StudentID = splitedStrings[0];
            this.Name = splitedStrings[1];
            this.Program = splitedStrings[2];
            this.ParentName = splitedStrings[3];
            this.ParentPhone = splitedStrings[4];
            this.StudentPhone = splitedStrings[5];
            this.Email = splitedStrings[6];
            this.Address = splitedStrings[8];
            this.Gender = splitedStrings[7];
            this.RegistrationDate = splitedStrings[9];
          
        }

    }
}


