using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace ApplicationDevelopmentCw1
{
    /// <summary>
    /// Interaction logic for ExcelData.xaml
    /// </summary>
    public partial class ExcelData : Window
    {
        private string CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\StudentRecords.xml";
        private string CurrentSchemaPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\StudentRecordsSchema.xml";
        private string fileName;
        public ExcelData()
        {
            InitializeComponent();
        }

        private void BtnImportData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            //open.ShowDialog();
            // Set filter for file extension and default file extension 
            open.DefaultExt = ".csv";
            open.Filter = "CSV files|*.csv";



            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = open.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
               fileName = open.FileName;
               
                var studenData = ReadAll();
                excelDataGrid.ItemsSource = studenData;
            }
        }
        public List<StudentInfo> ReadAll()
        {
            

                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("Student Info file doesn't exist");
                }
                else
                {

                List<StudentInfo> students = new List<StudentInfo>();
                using (StreamReader streamReader = new StreamReader(fileName))
                {

                    while (!streamReader.EndOfStream)
                    {

                        var studentString = streamReader.ReadLine();
                        var studentInfo = new StudentInfo(studentString);
                        students.Add(studentInfo);
                    }
                    streamReader.Close();
                }
                return students;
            }

            
            
        }
        private void AddCsvData(DataSet dataSet)
        {
            var students = ReadAll();
            foreach (StudentInfo student in students)
            {
                var dr = dataSet.Tables["Student"].NewRow();
                dr["Id"] = student.id;
                dr["FirstName"] = student.FirstName;
                dr["LastName"] = student.LastName;
                dr["Gender"] = student.Gender;
                dr["ContactNumber"] = student.Phone;
                dr["Email"] = student.Email;
                dr["CourseEnroll"] = student.CourseEnroll;
                dr["Zone"] = student.Zone;
                dr["District"] = student.District;
                dr["RegistrationDate"] = student.EnrollDate;
                dataSet.Tables["Student"].Rows.Add(dr);
            }
        }

        private void saveDataToXml(object sender, RoutedEventArgs e)
        {
            var data = new DataHandler();
            var dataSet = data.CreateDataSet();
            AddCsvData(dataSet);

            if (File.Exists(CurrentPath) && File.Exists(CurrentSchemaPath))
            {
                dataSet.ReadXmlSchema(CurrentSchemaPath);
                dataSet.ReadXml(CurrentPath);
                dataSet.WriteXmlSchema(CurrentSchemaPath);
                dataSet.WriteXml(CurrentPath);
                MessageBox.Show("Students Added Succsfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                

            }
            else
            {
                dataSet.WriteXmlSchema(CurrentSchemaPath);
                dataSet.WriteXml(CurrentPath);
                MessageBox.Show("Students Added Succsfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }
        public string CreateStudentId()
        {
            var bytes = new byte[4];
            var randomNumber = RandomNumberGenerator.Create();
            randomNumber.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }
    }
}
