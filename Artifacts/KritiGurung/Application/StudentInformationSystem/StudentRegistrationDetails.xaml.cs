using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for StudentRegistrationDetials.xaml
    /// </summary>
    public partial class StudentRegistrationDetails : Window
    {
        public StudentRegistrationDetails()
        {
            InitializeComponent();
        }

        readonly List<DataGridItems> items = new List<DataGridItems>();
        private void saveStdDetails(object sender, RoutedEventArgs e)
        {
            // Get the user input value from the textbox and initialize it
            String s_reg_id = std_registartion_id.Text;
            String s_reg_date = registration_date.Text;
            String s_id = std_id.Text;
            String s_name = std_name.Text;
            String s_address = std_address.Text;
            String s_email = std_email.Text;
            String s_contact = std_contact.Text;
            String s_course = std_course.Text;

            // Check for the empty values or inputs 
            if(s_reg_id == ""  || s_id == "" || s_name == "" || s_address == "" || s_email == "" || s_contact == "")
            {
                System.Windows.MessageBox.Show("Enter all values", "Invalid details", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                try
                {
                    RegistrationDetails details = new RegistrationDetails();
                    details.registrationID = s_reg_id;
                    details.registrationDate = registration_date.SelectedDate.Value.ToString("yyyy-MM-dd");
                    details.studentID = s_id;
                    details.name = s_name;
                    details.address = s_address;
                    details.email = s_email;
                    details.contact = s_contact;
                    details.course = s_course;

                    // Updates xml by user input
                    AppendData(details, "StudentDetails.xml");

                    // Displays Student details to DataGridView
                    items.Add(new DataGridItems() { RegistrationID = s_reg_id, RegistrationDate = details.registrationDate, StudentID = s_id, StudentName = s_name, StudentAddress = s_address, StudentEmail = s_email, StudentContact = s_contact, Course = s_course });
                    display_std.ItemsSource = items;
                    display_std.Items.Refresh();

                    System.Windows.MessageBox.Show("Student is successfully enroled.", "Enrol Sucessful!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }

            

        }

        static void AppendData(RegistrationDetails obj, string filename)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<RegistrationDetails>));
            List<RegistrationDetails> list = null;
            try
            {
                using (Stream s = File.OpenRead(filename))
                {
                    list = xmlser.Deserialize(s) as List<RegistrationDetails>;
                }
            }
            catch
            {
                list = new List<RegistrationDetails>();
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

        private void display_std_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void std_course_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomePage form2 = new HomePage();
            form2.ShowDialog();
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            std_registartion_id.Clear();
            std_id.Clear();
            std_name.Clear();
            std_address.Clear();
            std_email.Clear();
            std_contact.Clear();
        }
    }
}



