using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Xml.Serialization;

namespace Login2
{
    /// <summary>
    /// Interaction logic for Add_Student.xaml
    /// </summary>
    public partial class Add_Student : Page
    {
        private List<Student> _studentList = new List<Student>();
        public Boolean error;
        public Add_Student()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            error = false;

            Student student = new Student();
            student.ID = txtID.Text.ToString();
            student.FirstName = txtFirstName.Text.ToString();
            student.LastName = txtLastName.Text.ToString();
            student.Address = txtAddress.Text.ToString();
            student.ContactNo = txtContact.Text.ToString();
            student.CourseName = cbEnrol.Text.ToString();


            if (student.ID == "")
            {
                MessageBox.Show("Student ID Cannot Be Empty");
                
            }

           else if (student.FirstName == "")
            {
                MessageBox.Show("Student FirstName Cannot Be Empty");
            }

           else if (student.LastName == "")
            {
                MessageBox.Show("Student LastName Cannot Be Empty");
            }

          else  if (student.Address == "")
            {
                MessageBox.Show("Student Address Cannot Be Empty");
            }

           else if (student.ContactNo == "")
            {
                MessageBox.Show("Student Number Cannot Be Empty");
            }

           else if (student.CourseName == "")
            {
                MessageBox.Show("Course Name Cannot Be Empty");
            }

            else
            {
                try
                {
                    student.RegisterDate = dpDate.SelectedDate.Value.Date.ToShortDateString();
                    dgFirst.Items.Add(student);

                    List<Student> studentDetails = new List<Student>();
                    studentDetails.Add(new Student() { ID = student.ID, FirstName = student.FirstName, LastName = student.LastName, Address = student.Address, ContactNo = student.ContactNo, CourseName = student.CourseName, RegisterDate = student.RegisterDate });

                    XmlSerializer xmlser = new XmlSerializer(typeof(List<Student>));
                        List<Student> list = null;
                        try
                        {
                            using (Stream s = File.OpenRead("StudentDetails.xml"))
                            {
                                list = xmlser.Deserialize(s) as List<Student>;
                            }
                        }
                        catch
                        {
                            list = new List<Student>();
                        }
                        list.Add(student);
                        using (Stream s = File.OpenWrite("StudentDetails.xml"))
                        {
                            xmlser.Serialize(s, list);
                        }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message.ToString(), "Error");
                }

            }


        }

       
    }
}

