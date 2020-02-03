using DataHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Xml;
using System.Xml.Linq;

namespace Application_Dev
{
    /// <summary>
    /// Interaction logic for ImportCSV.xaml
    /// </summary>
    public partial class ImportCSV : Window
    {
        string fn;
        string xmlPath = System.IO.Path.Combine(Environment.CurrentDirectory, "studentCWData.xml");
        string schemaPath = System.IO.Path.Combine(Environment.CurrentDirectory, "StudentCWSchema.xml");

        public ImportCSV(string fileName)
        {
            InitializeComponent();
            fn = fileName;
            var data = ReadAll(fileName);
            datas.ItemsSource = data;
        }

        public List<StudentInfo> ReadAll(string fileName)

            
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Student Info file doesn't exist");
            }
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

        private void saveRecord(object sender, RoutedEventArgs e)
        {


            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            try
            {
                dataSet.ReadXml(xmlPath);
            }
            catch (Exception se) { 
            }
            AddSampleDataforStd(dataSet);

            dataSet.WriteXmlSchema(schemaPath);
            dataSet.WriteXml(xmlPath);

            MessageBox.Show("Student record saved successfully.");

            Home dashboard = new Home();
            dashboard.Show();
            this.Close();
        }

        private void AddSampleDataforStd(DataSet dataSet)
        {
            var studentData = ReadAll(fn);
            foreach (StudentInfo info in studentData)
            {
                var dr1 = dataSet.Tables["Student"].NewRow();
                dr1["RegistrationNo"] = info.RegistrationNo;
                dr1["FirstName"] = info.FirstName;
                dr1["LastName"] = info.LastName;
                dr1["Address"] = info.Address; 
                dr1["ContactNo"] = info.Contact;
                dr1["Email"] = info.Email;
                dr1["CourseEnroll"] = info.ProgramEnrolled;
                dr1["RegistrationDate"] = info.RegistrationDate;
                dataSet.Tables["Student"].Rows.Add(dr1);
            }

        }

        private void datas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
