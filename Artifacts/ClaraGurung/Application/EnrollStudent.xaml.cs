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
using System.Xml.Serialization;
using System.IO;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for EnrollStudent.xaml
    /// </summary>
    public partial class EnrollStudent : Window
    {
        public EnrollStudent()
        {
            InitializeComponent();
        }

        static void RecordData(Information obj, string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Information>));
            List<Information> list = null;
            try
            {
                using (Stream s = File.OpenRead(filename))
                {
                    list = xmlSerializer.Deserialize(s) as List<Information>;
                }
            }
            catch
            {
                list = new List<Information>();
            }
            list.Add(obj);
            using (Stream s = File.OpenWrite(filename))
            {
                xmlSerializer.Serialize(s, list);
            }
        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (StudentId.Text == "" || StudentName.Text == "" || Address.Text == "" || Contact.Text == "" || CourseEnroll.Text == "" || Date.Text == "")
            {
                MessageBox.Show("Enter a valid input field.", "Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    Information information = new Information();
                    information.StudentID = StudentId.Text;
                    information.StudentRegistrationDate = Date.SelectedDate.Value.ToString("yyyy-MM-dd");
                    information.StudentName = StudentName.Text;
                    information.StudentAddress = Address.Text;
                    information.StudentContact = Contact.Text;
                    information.StudentCourse = CourseEnroll.Text;
                    RecordData(information, "StudentDetails.xml");



                    MessageBox.Show("Student is successfully enrolled.", "Enroll Sucessfull!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

           
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            StudentId.Text = "";
            StudentName.Text = "";
            Contact.Text = "";
            Address.Text = "";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
