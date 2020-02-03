using System;
using System.Collections;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Management_System
{
    /// <summary>
    /// Interaction logic for ImportFromCSV.xaml
    /// </summary>
    public partial class ImportFromCSV : Page
    {
        List<Student> _studentList = new List<Student>();
        List<Student> _studentList2 = new List<Student>();
        public ImportFromCSV()
        {
            InitializeComponent();
        }

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {

            ReadFromCSV();


        }

        public List<Student> ReadFromCSV()
        {
            List<Student> studentList = new List<Student>();
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "CSV files|*.csv";

                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    var lines = File.ReadLines(dlg.FileName);

                    foreach (var line in lines)
                    {



                        var res = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Student student = new Student();
                        student.studentID = Convert.ToString(res[0]);
                        student.firstName = Convert.ToString(res[1]);
                        student.firstName = Convert.ToString(res[2]);
                        student.address = Convert.ToString(res[3]);
                        student.phoneNo = Convert.ToString(res[4]);
                        student.courseName = Convert.ToString(res[5]);
                        student.enrolledDate = Convert.ToString(res[6]);
                        studentList.Add(student);
                    }
                    _studentList = studentList;

                    if (File.Exists("studentDetails.csv"))
                    {
                        dg2nd.ItemsSource = _studentList2;
                        this.dg2nd.ItemsSource = _studentList;
                        //ExportToCSV(studentList, "studentDetails.csv");

                        dg2nd.SelectAllCells();
                        dg2nd.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, dg2nd);
                        dg2nd.UnselectAllCells();
                        String result2 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                        File.AppendAllText("studentDetails.csv", result2, UnicodeEncoding.UTF8);



                    }
                    else
                    {

                        this.dg2nd.ItemsSource = _studentList;
                        //ExportToCSV(studentList, "studentDetails.csv");
                        dg2nd.SelectAllCells();
                        dg2nd.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, dg2nd);
                        dg2nd.UnselectAllCells();
                        String result3 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                        File.AppendAllText("studentDetails.csv", result3, UnicodeEncoding.UTF8);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

            return studentList;


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
            catch (Exception)
            {

            }

        }
    }
}