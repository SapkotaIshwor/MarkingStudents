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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationDevelopmentCW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Student student = new Student();
            //student details
            student.ID = "";
            student.Name = "";
            student.Address = "";
            student.Contact = "";
            student.CourseEnroll = "";
            student.RegDate = "";

            DataGridX.Items.Add(student);
        }
        public class Student
        {
            public string ID { get; set; }

            public string Name { get; set; }

            public string Address { get; set; }

            public string Contact { get; set; }

            public string CourseEnroll { get; set; }

            public string RegDate { get; set; }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var handler = new DataHandler();
            var dataSet = handler.CreateDataSet();
            AddSampleData(dataSet);
            MessageBox.Show("Data saved successfully !!!");
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
            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["ID"] = txtId.Text;
            dr1["Name"] = txtName.Text;
            dr1["Address"] = txtAddress.Text;
            dr1["Contact"] = txtContact.Text;
            dr1["CourseEnroll"] = txtCourseEnrl.Text;
            dr1["RegDate"] = txtRegDate.Text;
            dataSet.Tables["Student"].Rows.Add(dr1);
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            Student dataStudent = new Student();
            dataStudent.ID = txtId.Text;
            dataStudent.Name = txtName.Text;
            dataStudent.Address = txtAddress.Text;
            dataStudent.Contact = txtContact.Text;
            dataStudent.CourseEnroll = txtCourseEnrl.Text;
            dataStudent.RegDate = txtRegDate.Text;

            DataGridX.Items.Add(dataStudent);
        }
    }
}
