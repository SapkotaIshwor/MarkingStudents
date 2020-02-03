using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Student_Information_System
{
    /// <summary>
    /// Interaction logic for AddStudents.xaml
    /// </summary>
    public partial class AddStudents : Window
    {


        private List<Student> _studentList = new List<Student>();
        private Boolean error;
        public AddStudents()
        {
            InitializeComponent();
        }

        private void SubmitRegistrationForm(object sender, RoutedEventArgs e)
        {
            error = false;


            Student student = new Student();
            student.ID = txtId.Text.ToString();
            student.Fullname = txtfullname.Text.ToString();
            student.Address = txtAddress.Text.ToString();
            student.Contact = txtContact.Text.ToString();
            student.courseEnroll = cbcourseEnroll.Text.ToString();
            student.RegistrationDate = dpRegistrationDate.Text.ToString();
            


            if (student.ID == "")
            {
                error = true;
            }

            if (student.Fullname == "")
            {
                error = true;
            }

            if (student.Address == "")
            {
                error = true;
            }

            if (student.Contact == "")
            {
                error = true;
            }

            if (student.courseEnroll == "")
            {
                error = true;
            }

            if (student.RegistrationDate == "")
            {
                error = true;
            }

            if (error)
            {
                System.Windows.MessageBox.Show("All fields must be filled", "Error");
            }

            else
            {
                try
                {
                    if (File.Exists("studentDetails.csv"))
                    {
                        student.RegistrationDate = dpRegistrationDate.SelectedDate.Value.Date.ToShortDateString();
                        _studentList.Add(student);
                        DGStudentDetails.Items.Clear();
                        DGStudentDetails.Items.Add(student);
                        System.Windows.MessageBox.Show("Successfully Enrolled and Saved to CSV", "Success");
                        ExportToCSV(_studentList, "studentDetails.csv");

                        

                    }
                    else
                    {
                        student.RegistrationDate = dpRegistrationDate.SelectedDate.Value.Date.ToShortDateString();
                        _studentList.Add(student);
                        DGStudentDetails.Items.Add(student);
                        System.Windows.MessageBox.Show("Successfully Enrolled and Saved to CSV", "Success");
                        ExportToCSV(_studentList, "studentDetails.csv");


                       


                    }


                   

                }
                catch (Exception er)
                {
                    System.Windows.MessageBox.Show(er.Message.ToString(), "Error");
                }

            }


        }

        private void Savebtnclick(object sender, RoutedEventArgs e)
        {


            Student student = new Student
            {
                ID = txtId.Text.ToString(),
                Fullname = txtfullname.Text.ToString(),
                Address = txtAddress.Text.ToString(),
                Contact = txtContact.Text.ToString(),
                courseEnroll = cbcourseEnroll.Text.ToString(),
                RegistrationDate = dpRegistrationDate.SelectedDate.Value.Date.ToShortDateString()
            };

            XmlSerializer xs = new XmlSerializer(typeof(Student));

            FileStream fsout = new FileStream("individual.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    xs.Serialize(fsout, student);
                    System.Windows.MessageBox.Show("Successfully Saved", "Info");
                    txtId.Text = String.Empty;
                    txtfullname.Text = String.Empty;
                    txtAddress.Text = String.Empty;
                    txtContact.Text = String.Empty;
                    cbcourseEnroll.Text = String.Empty;
                    dpRegistrationDate.Text = String.Empty;

                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }

        private void Retrievetnclick(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            XmlSerializer xs = new XmlSerializer(typeof(Student));

            FileStream fsin = new FileStream("individual.xml", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    student = (Student)xs.Deserialize(fsin);


                    txtId.Text = student.ID;
                    txtfullname.Text = student.Fullname;
                    txtAddress.Text = student.Address;
                    txtContact.Text = student.Contact;
                    cbcourseEnroll.Text = student.courseEnroll;
                    dpRegistrationDate.Text = student.RegistrationDate;


                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        public void ExportToCSV(List<Student> students, string filePath)
        {
            try
            {
                if (students.Count > 0)
                {
                    var propList = students[0].GetType().GetProperties().Select(prop => prop.Name).ToList();
                    //TextWriter is used to create outputand streamWriter is used to read file location

                    using (TextWriter TW = new StreamWriter(filePath, append: true))
                    {
                        //writes header


                        //writes values
                        foreach (var val in students)
                        {
                            foreach (PropertyInfo prop in val.GetType().GetProperties())
                            {
                                TW.Write(prop.GetValue(val, null).ToString() + ",");
                            }
                            TW.WriteLine();

                        }
                    }
                   
                    Process.Start(filePath);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message.ToString(), "Error");
               
            }

        }

       
    }
}

   