using DataHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml;

namespace Application_Dev
{
    /// <summary>
    /// Interaction logic for SortData.xaml
    /// </summary>
    public partial class SortData : Window
    {
        string xmlPath = System.IO.Path.Combine(Environment.CurrentDirectory, "studentCWData.xml");


        public SortData()
        {
            InitializeComponent();


            var data = readData();
            studentData.ItemsSource = data;
        }

        public List<StudentInfo> readData()
        {
            string fileName = xmlPath;
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Student Info file doesn't exist");
            }
            List<StudentInfo> students = new List<StudentInfo>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/NewDataSet/Student");
            foreach (XmlNode node in nodeList)
            {
                var studentInfo = new StudentInfo(node);
                students.Add(studentInfo);
            }

            return students;

        }


        private void studentData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();

        }

        private void btnSortName_Click(object sender, RoutedEventArgs e)
        {
            studentData.ItemsSource = null;
            var dataSet = new DataSet();

            dataSet.ReadXml(xmlPath);

            DataTable dtStdReport = new DataTable();
            dtStdReport = dataSet.Tables[0];
            studentData.ItemsSource = dtStdReport.DefaultView;


            studentData.Items.SortDescriptions.Add(new SortDescription("firstname", ListSortDirection.Ascending));
        }

        private void btnSortDate_Click(object sender, RoutedEventArgs e)
        {

            studentData.ItemsSource = null;
            var dataSet = new DataSet();

            dataSet.ReadXml(xmlPath);

            DataTable dtStdReport = new DataTable();
            dtStdReport = dataSet.Tables[0];
            studentData.ItemsSource = dtStdReport.DefaultView;
            studentData.Items.SortDescriptions.Add(new SortDescription("RegistrationDate", ListSortDirection.Ascending));
        }

  
    }
}
