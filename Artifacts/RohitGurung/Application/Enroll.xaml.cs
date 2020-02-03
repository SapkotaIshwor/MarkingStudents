using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using System.IO;

namespace CWAD
{
    /// <summary>
    /// Interaction logic for Enroll.xaml
    /// </summary>
    public partial class Enroll : Page
    {
        public Enroll()
        {
            InitializeComponent();
        }

        static void AppendData(Details obj, string filename)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Details>));
            List<Details> list = null;
            try
            {
                using (Stream s = File.OpenRead(filename))
                {
                    list = xmlser.Deserialize(s) as List<Details>;
                }
            }
            catch
            {
                list = new List<Details>();
            }
            list.Add(obj);
            using (Stream s = File.OpenWrite(filename))
            {
                xmlser.Serialize(s, list);
            }
        }

        public class DataGridItems
        {

            public string RegistrationID { get; set; }
            public string RegistrationDate { get; set; }
            public string StudentID { get; set; }
            public string StudentName { get; set; }
            public string StudentAddress { get; set; }
            public string StudentEmail { get; set; }
            public string StudentContact { get; set; }
            public string Course { get; set; }
        }

        List<DataGridItems> items = new List<DataGridItems>();
        private void BtnRecord_Click(object sender, RoutedEventArgs e)
        {
            String regID = txtRegistrationID.Text;
            String regDate = dateRegistration.Text;
            String stdID = txtStudentID.Text;
            String stdName = txtStudentName.Text;
            String stdAddress = txtStudentAddress.Text;
            String stdEmail = txtStudentEmail.Text;
            String stdContact = txtStudentContact.Text;
            String stdCourse = comboCourse.Text;

            if (regID == "" || stdID == "" || stdName == "" || stdAddress == "" || stdEmail == "" || stdContact == "")
            {
                MessageBox.Show("Please fill up all the fields.", "Invalid Input!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }

            else
            {
                try
                {
                    Details details = new Details();
                    details.StudentRegistrationID = regID;
                    details.StudentRegistrationDate = dateRegistration.SelectedDate.Value.ToString("yyyy-MM-dd");
                    details.StudentID = stdID;
                    details.StudentName = stdName;
                    details.StudentAddress = stdAddress;
                    details.StudentEmail = stdEmail;
                    details.StudentContact = stdContact;
                    details.StudentCourse = stdCourse;
                    AppendData(details, "StudentDetails.xml");

                    items.Add(new DataGridItems() { RegistrationID = regID, RegistrationDate = details.StudentRegistrationDate, StudentID = stdID, StudentName = stdName, StudentAddress = stdAddress, StudentEmail = stdEmail, StudentContact = stdContact, Course = stdCourse });
                    dataGridEnroll.Items.Refresh();
                    dataGridEnroll.ItemsSource = items;

                    MessageBox.Show("Student is successfully enroled.", "Enrol Sucessful!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }  
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtRegistrationID.Text = "";
            dateRegistration.Text = "";
            txtStudentID.Text = "";
            txtStudentName.Text = "";
            txtStudentAddress.Text = "";
            txtStudentEmail.Text = "";
            txtStudentContact.Text = "";
            comboCourse.Text = "";
        }

        private void DataGridEnroll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DateRegistration_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
