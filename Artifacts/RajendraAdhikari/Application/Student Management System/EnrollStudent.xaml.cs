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

namespace Student_Management_System
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

        private void EnrollBtn_Click(object sender, RoutedEventArgs e)
        {
            error = false;

            Student student = new Student();
            student.studentID = txtID.Text.ToString();
            student.firstName = txtFirstName.Text.ToString();
            student.lastName = txtLastName.Text.ToString();
            student.address = txtAddress.Text.ToString();
            student.phoneNo = txtContact.Text.ToString();
            student.courseName = cbCourse.Text.ToString();


            if (student.studentID == "")
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

            if (student.phoneNo == "")
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
                        student.enrolledDate = dpRegister.SelectedDate.Value.Date.ToShortDateString();
                        dg1st.Items.Clear();
                        dg1st.Items.Add(student);
                        dg1st.SelectAllCells();
                        dg1st.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, dg1st);
                        dg1st.UnselectAllCells();
                        String result2 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                        File.AppendAllText("studentDetails.csv", result2, UnicodeEncoding.UTF8);
                    }
                    else
                    {
                        student.enrolledDate = dpRegister.SelectedDate.Value.Date.ToShortDateString();
                        dg1st.Items.Add(student);
                        dg1st.SelectAllCells();
                        dg1st.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, dg1st);
                        dg1st.UnselectAllCells();
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

       
    }
}