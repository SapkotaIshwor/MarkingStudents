using System;
using DataHandler;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StudentInfo studentinfo = new StudentInfo();
            DataGrid.Items.Add(studentinfo);
        }

        public class StudentInfo
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string CourseEnroll { get; set; }
            public string RegistrationDate { get; set; }

        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            AddSampleData(dataSet);
            MessageBox.Show("Data saved successfully !!");
            if (File.Exists(@"D:\studentData.xml"))
            {
                dataSet.ReadXml(@"D:\studentData.xml");
                dataSet.WriteXml(@"D:\studentData.xml");
            }
            else
            {
                dataSet.WriteXml(@"D:\studentData.xml");
            }
        }
        private void AddSampleData(DataSet dataSet)
        {
            var dr1 = dataSet.Tables["StudentInfo"].NewRow();
            dr1["ID"] = std_id.Text;
            dr1["Name"] = std_name.Text;
            dr1["Address"] = std_address.Text;
            dr1["Phone"] = std_phone.Text;
            dr1["CourseEnroll"] = course_enroll.Text;
            dr1["RegistrationDate"] = std_regdate.Text;
            dataSet.Tables["StudentInfo"].Rows.Add(dr1);
        }


        private void import_report_Click(object sender, RoutedEventArgs e)
        {
            StudentInfo studentInfo = new StudentInfo();
            studentInfo.ID = std_id.Text;
            studentInfo.Name = std_name.Text;
            studentInfo.Address = std_address.Text;
            studentInfo.Phone = std_phone.Text;
            studentInfo.CourseEnroll = course_enroll.Text;
            studentInfo.RegistrationDate = std_regdate.Text;

            DataGrid.Items.Add(studentInfo);
        }

        private void display_report_Click(object sender, RoutedEventArgs e)
        {
            StudentReport studentReport = new StudentReport();
            studentReport.Show();
        }
    }
}
