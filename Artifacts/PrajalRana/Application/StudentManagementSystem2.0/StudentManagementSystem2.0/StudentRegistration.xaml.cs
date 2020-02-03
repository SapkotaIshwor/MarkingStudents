using System;
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
using System.Windows.Shapes;
using DataHandler;
using System.IO;

namespace StudentManagementSystem2._0 {
    /// <summary>
    /// Interaction logic for StudentRegistration.xaml
    /// </summary>
    public partial class StudentRegistration : Window {
        public StudentRegistration() {
            InitializeComponent();
        }
        private void AddStudentDetails(DataSet dataset) {
            
                var dt_student = dataset.Tables["Student"].NewRow();
                dt_student["Name"] = txtName.Text;
                dt_student["Address"] = txtAddress.Text;
                dt_student["ContactNo"] = txtContactNo.Text;
                dt_student["EmailAddress"] = txtEmailAddress.Text;
                dt_student["CourseEnroll"] = cbCourseEnroll.Text;
                dt_student["RegistrationDate"] = dpRegistrationDate.SelectedDate.ToString();
                //MessageBox.Show("Date Added" + dpRegistrationDate.SelectedDate.ToString());
                dataset.Tables["Student"].Rows.Add(dt_student);
        }
        private void AppendStudentDetails(DataSet dataset) {

            if (File.Exists(@"E:\College\3rd Year\Application Development\StudentReport.xml"))
            {
                dataset.Tables["StudentReport"].ReadXml(@"E:\College\3rd Year\Application Development\StudentReport.xml");
                var dt_student = dataset.Tables["StudentReport"].NewRow();
                dt_student["Name"] = txtName.Text;
                dt_student["Address"] = txtAddress.Text;
                dt_student["ContactNo"] = txtContactNo.Text;
                dt_student["EmailAddress"] = txtEmailAddress.Text;
                dt_student["CourseEnroll"] = cbCourseEnroll.Text;
                dt_student["RegistrationDate"] = dpRegistrationDate.SelectedDate;
                dataset.Tables["StudentReport"].Rows.Add(dt_student);

                dataset.Tables["StudentReport"].WriteXml(@"E:\College\3rd Year\Application Development\StudentReport.xml");
            }
            else
            {
                dataset.Tables["StudentReport"].WriteXml(@"E:\College\3rd Year\Application Development\StudentReport.xml");
                AppendStudentDetails(dataset);
            }
            
        }

        private void View_Student_Details() {
            if (File.Exists(@"E:\College\3rd Year\Application Development\StudentReport.xml"))
            {
                var dataset = new DataSet();
                dataset.ReadXml(@"E:\College\3rd Year\Application Development\StudentReport.xml");
            }
            else
            {
                MessageBox.Show("Sorry, there's data. Please fill up the form to view data.");
            }
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            var handler = new Handler();
            var dataset = handler.CreateDataSet();
            AddStudentDetails(dataset);
            AppendStudentDetails(dataset);

            dataset.Tables["Student"].WriteXml(@"E:\College\3rd Year\Application Development\" + txtName.Text + "Data.xml");
            //Res_no_write(txtResNo.Text);
            //txtResNo.Text = Res_no_read();

            MessageBox.Show("Sudent Details saved successfully!");
            txtName.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtEmailAddress.Text = "";
            //cbCourseEnroll.SelectedIndex
            //dpRegistrationDate.SelectedDate
            StudentDetails stddetails = new StudentDetails();
            stddetails.Show();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void cbCourseEnroll_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }
}
