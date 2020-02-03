using System;
using System.Collections.Generic;
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
using System.Data;
using System.Xml.Serialization;
using System.IO;


namespace CourseworkAppDevelopment
{
    /// <summary>
    /// Interaction logic for StudentEnroll.xaml
    /// </summary>
    public partial class StudentEnroll : Window
    {

       
        public StudentEnroll()
        {
            InitializeComponent();

        }


        static void AddStudentData(StudentInformationClass obj, string RecordName) {

            XmlSerializer xmlserializer = new XmlSerializer(typeof(List<StudentInformationClass>));

            //XmlSerializer object is created and used.

            List<StudentInformationClass> list = null;

            try {

                using (Stream s = File.OpenRead(RecordName)) {

                    list = xmlserializer.Deserialize(s) as List<StudentInformationClass>;

                }
            }

            catch {

                list = new List<StudentInformationClass>();

            }
            list.Add(obj);

            using (Stream s = File.OpenWrite(RecordName)){

                xmlserializer.Serialize(s, list);
            }
        }

        private void btnBackHome_Click(object sender, RoutedEventArgs e) {

            //"Back" button created to go back to Home Window
            
            HomeWindow homeWindow = new HomeWindow();
            
            homeWindow.Show();
            
            this.Close();
            
        }      

        private void dtGridStudentEnroll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }

        private void btnSaveStudentEnroll_Click(object sender, RoutedEventArgs e) {
           
            //textbox x:{name} are used to enter, add and retrive data in StudentEnroll.xml file

                String StudentId = txtStudentId.Text;

                String StudentName = txtStudentName.Text;

                String StudentAddress = txtAddress.Text;

                String StudentContact = txtContactNo.Text;

                String StudentEmail = txtEmail.Text;    
            
                String StudentCourse = boxCourseEnroll.Text;

                String StudentRegistration_ID = txtRegId.Text;

                String registration_Date = pickerRegistrationDate.Text;


            if ( StudentId == " " && StudentName == " " && StudentAddress == " " &&  StudentContact == " " && StudentEmail == " " && StudentRegistration_ID == " " ) {

                    MessageBox.Show("Invalid Input Detected","Student Information System");

                }

                else {

                    try {

                        StudentInformationClass StudentInformation = new StudentInformationClass();

                        StudentInformation.StudentId = StudentId;

                        StudentInformation.StudentName = StudentName;
                    
                        StudentInformation.StudentAddress = StudentAddress;

                        StudentInformation.StudentContactNo = StudentContact;

                        StudentInformation.StudentEmail = StudentEmail;

                        StudentInformation.StudentCourseEnroll = StudentCourse;
                      
                        StudentInformation.StudentRegistrationId = StudentRegistration_ID;
                        
                        StudentInformation.StudentRegistrationDate = pickerRegistrationDate.SelectedDate.Value.ToString("yyyy-MM-dd");

                        // Date calender is customized in English(United Kingdom) based that is yyyy-MM-dd

                        AddStudentData(StudentInformation, "StudentEnroll.xml");

                    //Data are added i.e. appended in StudentEnroll.xml file. 

                    MessageBox.Show("Student data Enrolled and Saved", "Student Information System");

                    msglbl.Visibility = Visibility.Visible;
                    
                    }

                    catch (Exception ex) {

                        MessageBox.Show(ex.Message);

                    }
                }
        }

        private void btnClearForm_Click(object sender, RoutedEventArgs e)
        {
            txtRegId.Text = " ";

            txtStudentId.Text = " ";
            
            txtStudentName.Text = " ";
            
            txtAddress.Text = " ";
            
            txtContactNo.Text = " ";
            
            txtEmail.Text = " ";
            
            boxCourseEnroll.Text = " ";
            
            pickerRegistrationDate.Text = " ";
            
            msglbl.Visibility = Visibility.Hidden;

        }
    }
}
