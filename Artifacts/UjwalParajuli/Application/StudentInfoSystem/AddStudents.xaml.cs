using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Xml.Serialization;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for AddStudents.xaml
    /// </summary>
    public partial class AddStudents : Page
    {
        private List<Student> _studentList = new List<Student>();
        private Boolean error;
        public AddStudents()
        {
            InitializeComponent();
        }

        private void ButtonEnrol_Click(object sender, RoutedEventArgs e)
        {
            error = false;

            Student student = new Student();
            student.idNumber = txtID.Text.ToString();
            student.firstName = txtFirstName.Text.ToString();
            student.lastName = txtLastName.Text.ToString();
            student.address = txtAddress.Text.ToString();
            student.contactNo = txtContact.Text.ToString();
            student.courseName = cbCourse.Text.ToString();
            

            if (student.idNumber == "")
            {
                error = true;
            }

            if (student.firstName == "")
            {
                error = true; 
            }

            if (student.lastName == "")
            {
                error = true;
            }

            if (student.address == "")
            {
                error = true;
            }

            if (student.contactNo == "")
            {
                error = true;   
            }

            if (student.courseName == "")
            {
                error = true;   
            }

            if(error)
            {
                MessageBox.Show("All fields must be filled", "Error");
            }

            else
            {
                try
                {
                    if (File.Exists("studentDetails.csv"))
                    {
                        student.registerDate = dpRegister.SelectedDate.Value.Date.ToShortDateString();
                        _studentList.Add(student);
                        dgFirst.Items.Clear();
                        dgFirst.Items.Add(student);
                        MessageBox.Show("Successfully Enrolled and Saved to CSV", "Success");
                        ExportToCSV(_studentList, "studentDetails.csv");
                    }
                    else
                    {
                        student.registerDate = dpRegister.SelectedDate.Value.Date.ToShortDateString();
                        _studentList.Add(student);
                        dgFirst.Items.Add(student);
                        MessageBox.Show("Successfully Enrolled and Saved to CSV", "Success");
                        ExportToCSV(_studentList, "studentDetails.csv");
                    }
                  
                }
                catch(Exception er)
                {
                    MessageBox.Show(er.Message.ToString(), "Error");
                }
               
            }

            
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = new Student
                {
                    idNumber = txtID.Text.ToString(),
                    firstName = txtFirstName.Text.ToString(),
                    lastName = txtLastName.Text.ToString(),
                    address = txtAddress.Text.ToString(),
                    contactNo = txtContact.Text.ToString(),
                    courseName = cbCourse.Text.ToString(),
                    registerDate = dpRegister.SelectedDate.Value.Date.ToShortDateString()
                };

                XmlSerializer xs = new XmlSerializer(typeof(Student));

                FileStream fsout = new FileStream("individual.xml", FileMode.Create, FileAccess.Write, FileShare.None);
                try
                {
                    using (fsout)
                    {
                        xs.Serialize(fsout, student);
                        MessageBox.Show("Successfully Saved", "Info");
                        txtID.Text = String.Empty;
                        txtFirstName.Text = String.Empty;
                        txtLastName.Text = String.Empty;
                        txtAddress.Text = String.Empty;
                        txtContact.Text = String.Empty;
                        cbCourse.Text = String.Empty;
                        dpRegister.Text = String.Empty;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
           

        }

        private void ButtonRetrieve_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            XmlSerializer xs = new XmlSerializer(typeof(Student));

            FileStream fsin = new FileStream("individual.xml", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    student = (Student)xs.Deserialize(fsin);
                   
                    txtID.Text = student.idNumber;
                    txtFirstName.Text = student.firstName;
                    txtLastName.Text = student.lastName;
                    txtAddress.Text = student.address;
                    txtContact.Text = student.contactNo;
                    cbCourse.Text = student.courseName;
                    dpRegister.Text = student.registerDate;
                    MessageBox.Show("Successfully Retrieved", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
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
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }

       private void CheckNumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only numbers", "Error");
            }

        }

        private void CheckName(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);
            if(e.Handled == true)
            {
                MessageBox.Show("Please enter only alphabets", "Error");
            }
           
        }

       
    }

}
