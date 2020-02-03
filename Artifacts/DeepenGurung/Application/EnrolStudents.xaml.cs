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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for EnrolStudents.xaml
    /// </summary>
    public partial class EnrolStudents : Page
    {
        private List<Student> _studentList = new List<Student>();
        private Boolean error;
        public EnrolStudents()
        {
            InitializeComponent();
        }
        private void ButtonEnroll_Click(object sender, RoutedEventArgs e)
        {
            error = false;

            Student student = new Student();
            student.stdidNum = txtStdID.Text.ToString();
            student.stdfullName = txtStdName.Text.ToString();
            student.stdaddress = txtStdAddress.Text.ToString();
            student.contactNum = txtStdContact.Text.ToString();
            student.courseName = enrollCourse.Text.ToString();


            if (student.stdidNum == "")
            {
                error = true;
            }

            if (student.stdfullName == "")
            {
                error = true;
            }

            

            if (student.stdaddress == "")
            {
                error = true;
            }

            if (student.contactNum == "")
            {
                error = true;
            }

            if (student.courseName == "")
            {
                error = true;
            }

            if (error)
            {
                MessageBox.Show("All fields must be filled", "Error");
            }

            else
            {
                try
                {
                    if (File.Exists("studentDetails.csv"))
                    {
                        student.registerDate = dateRegister.SelectedDate.Value.Date.ToShortDateString();
                        datagrid1.Items.Clear();
                        datagrid1.Items.Add(student);
                        datagrid1.SelectAllCells();
                        datagrid1.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, datagrid1);
                        datagrid1.UnselectAllCells();
                        String result2 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                        File.AppendAllText("studentDetails.csv", result2, UnicodeEncoding.UTF8);
                    }
                    else
                    {
                        student.registerDate = dateRegister.SelectedDate.Value.Date.ToShortDateString();
                        datagrid1.Items.Add(student);
                        datagrid1.SelectAllCells();
                        datagrid1.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, datagrid1);
                        datagrid1.UnselectAllCells();
                        String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                        File.AppendAllText("studentDetails.csv", result, UnicodeEncoding.UTF8);

                    }


                    //List<Student> studentDetails = new List<Student>();
                    //studentDetails.Add(new Student() { idNumber = student.idNumber, firstName = student.firstName, lastName = student.lastName, address = student.address, contactNo = student.contactNo, courseName = student.courseName, registerDate = student.registerDate });
                    //XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                    //if (File.Exists("studentDetails.xml"))
                    //{

                    //}
                    //else
                    //{
                    //    using (FileStream fileStream = new FileStream("studentDetails.xml", FileMode.Append, FileAccess.Write))
                    //    {
                    //        serializer.Serialize(fileStream, studentDetails);
                    //        MessageBox.Show("Successfully Enrolled and Saved to XML", "Info");

                    //    }
                    //}

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message.ToString(), "Error");
                }

            }


        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student
            {
                stdidNum = txtStdID.Text.ToString(),
                stdfullName = txtStdName.Text.ToString(),
                stdaddress = txtStdAddress.Text.ToString(),
                contactNum = txtStdContact.Text.ToString(),
                courseName = enrollCourse.Text.ToString(),
                registerDate = dateRegister.SelectedDate.Value.Date.ToShortDateString()
            };

            XmlSerializer xs = new XmlSerializer(typeof(Student));

            FileStream fsout = new FileStream("individual.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    xs.Serialize(fsout, student);
                    MessageBox.Show("Successfully Saved", "Info");
                    txtStdID.Text = String.Empty;
                    txtStdName.Text = String.Empty;
                    txtStdAddress.Text = String.Empty;
                    txtStdContact.Text = String.Empty;
                    enrollCourse.Text = String.Empty;
                    dateRegister.Text = String.Empty;

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


                    txtStdID.Text = student.stdidNum;
                    txtStdName.Text = student.stdfullName;
                    txtStdAddress.Text = student.stdaddress;
                    txtStdContact.Text = student.contactNum;
                    enrollCourse.Text = student.courseName;
                    dateRegister.Text = student.registerDate;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
    }
}

