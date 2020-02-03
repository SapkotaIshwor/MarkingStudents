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

namespace studentManagement
{
    /// <summary>
    /// Interaction logic for EnrollStudent.xaml
    /// </summary>
    public partial class EnrollStudent : Page
    {
        private List<Student> _studentList = new List<Student>();
        private Boolean error;
        public EnrollStudent()
        {
            InitializeComponent();
        }

        private void ButtonEnroll_Click(object sender, RoutedEventArgs e)
        {
            error = false;

            Student student = new Student();
            student.studentIdNumber = txtStudentID.Text.ToString();
            student.studentFullName = txtStudentName.Text.ToString();
            student.studentAddress = txtStudentAddress.Text.ToString();
            student.studentContact = txtStudentContact.Text.ToString();
            student.courseName = selectCourse.Text.ToString();


            if (student.studentIdNumber == "")
            {
                error = true;
            }

            if (student.studentFullName == "")
            {
                error = true;
            }


            if (student.studentAddress == "")
            {
                error = true;
            }

            if (student.studentContact == "")
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
                        student.registeredDate = registeredDate.SelectedDate.Value.Date.ToShortDateString();
                        datagridFirst.Items.Clear();
                        datagridFirst.Items.Add(student);
                        datagridFirst.SelectAllCells();
                        datagridFirst.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, datagridFirst);
                        datagridFirst.UnselectAllCells();
                        String result2 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                        File.AppendAllText("studentDetails.csv", result2, UnicodeEncoding.UTF8);
                    }
                    else
                    {
                        student.registeredDate = registeredDate.SelectedDate.Value.Date.ToShortDateString();
                        datagridFirst.Items.Add(student);
                        datagridFirst.SelectAllCells();
                        datagridFirst.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, datagridFirst);
                        datagridFirst.UnselectAllCells();
                        String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                        File.AppendAllText("studentDetails.csv", result, UnicodeEncoding.UTF8);

                    }


                   

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
                studentIdNumber = txtStudentID.Text.ToString(),
                studentFullName = txtStudentName.Text.ToString(),
                studentAddress = txtStudentAddress.Text.ToString(),
                studentContact = txtStudentContact.Text.ToString(),
                courseName = selectCourse.Text.ToString(),
                registeredDate = registeredDate.SelectedDate.Value.Date.ToShortDateString()
            };

            XmlSerializer xs = new XmlSerializer(typeof(Student));

            FileStream fsout = new FileStream("individual.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    xs.Serialize(fsout, student);
                    MessageBox.Show("Successfully Saved", "Info");
                    txtStudentID.Text = String.Empty;
                    txtStudentName.Text = String.Empty;
                    txtStudentAddress.Text = String.Empty;
                    txtStudentContact.Text = String.Empty;
                    selectCourse.Text = String.Empty;
                    registeredDate.Text = String.Empty;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }

    }
}