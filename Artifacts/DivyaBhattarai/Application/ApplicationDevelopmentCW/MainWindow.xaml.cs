using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Student student = new Student();

            DataGridXAML.Items.Add(student);
        }
        public class Student
        {
            public string ID { get; set; }

            public string Name { get; set; }

            public string Address { get; set; }

            public string Contact { get; set; }

            public string CourseEnroll { get; set; }

            public string RegDate { get; set; }
            public string Email { get; internal set; }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Checkedempty();
            var handler = new DataHandler();
            var dataSet = handler.CreateDataSet();
            AddSampleData(dataSet);
            MessageBox.Show("Data saved successfully !!!");
            if (File.Exists(@"D:\student.xml"))
            {
                dataSet.ReadXml(@"D:\student.xml");
                dataSet.WriteXml(@"D:\student.xml");
            }
            else
            {
                dataSet.WriteXml(@"D:\student.xml");
            }

        }
        private void AddSampleData(DataSet dataSet)
        {
            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["ID"] = textId.Text;
            dr1["Name"] = textName.Text;
            dr1["Address"] = textAddress.Text;
            dr1["Contact"] = textContact.Text;
            dr1["Email"] = textEmail.Text;
            dr1["CourseEnroll"] = textCourse.Text;
            string text = textDate.Text;
            dr1["RegDate"] = text;
            dataSet.Tables["Student"].Rows.Add(dr1);
         
        }

        private void Checkedempty()
        {
            var ID = textId.Text;
            var Name = textName.Text;
            var Address = textAddress.Text;
            var Contact = textContact.Text;
            var Email = textEmail.Text;
            var CourseEnroll = textCourse.Text;
            string text = textDate.Text;
            var RegDate = text;
            if (ID.Equals("") || Name.Equals("") || Address.Equals("") || Contact.Equals("") || Email.Equals("") || CourseEnroll.Equals("") || RegDate.Equals(""))
            {
                MessageBox.Show("You can't pass empty value", "Login Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            Checkedempty();
            Student dataStudent = new Student();
            dataStudent.ID = textId.Text;
            dataStudent.Name = textName.Text;
            dataStudent.Address = textAddress.Text;
            dataStudent.Contact = textContact.Text;
            dataStudent.Email = textEmail.Text;
            dataStudent.CourseEnroll = textCourse.Text;
            dataStudent.RegDate = textDate.Text;

            DataGridXAML.Items.Add(dataStudent);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            textId.Clear();
            textName.Clear();
            textAddress.Clear();
            textContact.Clear();
            textCourse.SelectedIndex = -1;
            textEmail.Clear();

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Window is being exited.");
            this.Close();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            DisplayReport displayReport = new DisplayReport();
            displayReport.Show();
        }

        
    }

}

