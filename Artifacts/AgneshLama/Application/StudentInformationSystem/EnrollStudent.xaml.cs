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

namespace StudentInformationSystem
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

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        static void AddData(Data obj, string filename)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Data>));
            List<Data> list = null;
            try
            {
                using (Stream s = File.OpenRead(filename))
                {
                    list = ser.Deserialize(s) as List<Data>;
                }
            }
            catch
            {
                list = new List<Data>();
            }
            list.Add(obj);
            using (Stream s = File.OpenWrite(filename))
            {
                ser.Serialize(s, list);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(txtregistrationid.Text =="" || txtstudentname.Text == "" || txtstudentaddress.Text == "" || txtstudentid.Text == "" || txtstudentnumber.Text == "" || registrationdate.Text == "" || courseenroll.Text == "")
            {
                MessageBox.Show("All field should be filled.", "Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    Data details = new Data();
                    details.StudentRegistrationID = txtregistrationid.Text;
                    details.StudentRegistrationDate = registrationdate.SelectedDate.Value.ToString("yyyy-MM-dd");
                    details.StudentID = txtstudentid.Text;
                    details.StudentName = txtstudentname.Text;
                    details.StudentAddress = txtstudentaddress.Text;
                    details.StudentContact = txtstudentnumber.Text;
                    details.StudentCourse = courseenroll.Text;
                    AddData(details, "StudentDetails.xml");

                    MessageBox.Show("Successfully enrolled.", "Enroll Sucessful", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            clear();
        }

        private void clear()
        {
            txtregistrationid.Text = "";
            txtstudentaddress.Text = "";
            txtstudentname.Text = "";
            txtstudentnumber.Text = "";
            txtstudentid.Text = "";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

       
    }
}
