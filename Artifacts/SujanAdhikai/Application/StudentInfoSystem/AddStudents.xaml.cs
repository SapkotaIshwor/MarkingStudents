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
                        dgFirst.Items.Clear();
                        dgFirst.Items.Add(student);
                        dgFirst.SelectAllCells();
                        dgFirst.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, dgFirst);
                        dgFirst.UnselectAllCells();
                        String result2 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                        File.AppendAllText("studentDetails.csv", result2, UnicodeEncoding.UTF8);
                    }
                    else
                    {
                        student.registerDate = dpRegister.SelectedDate.Value.Date.ToShortDateString();
                        dgFirst.Items.Add(student);
                        dgFirst.SelectAllCells();
                        dgFirst.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, dgFirst);
                        dgFirst.UnselectAllCells();
                        String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                        File.AppendAllText("studentDetails.csv", result, UnicodeEncoding.UTF8);
                        
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
            catch(Exception ex)
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

      


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked");
        }
    }
}
