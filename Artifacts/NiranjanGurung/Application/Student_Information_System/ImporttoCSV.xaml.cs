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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Student_Information_System
{
    /// <summary>
    /// Interaction logic for ImporttoCSV.xaml
    /// </summary>
    public partial class ImporttoCSV : Window
    {
        List<Student> _studentList = new List<Student>();
        List<Student> _studentList2 = new List<Student>();
        public ImporttoCSV()
        {
            InitializeComponent();
        }
        private void importtbn_click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "CSV files|*.csv";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                var csvData = System.IO.File.ReadAllText(dlg.FileName);
                ReadFromCSV(csvData);

            }
        }

        public List<Student> ReadFromCSV(string csvData)
        {
            List<Student> studentList = new List<Student>();
            try
            {
                //1st row contains property name so skipping the first row.
                var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    Student student = new Student();
                    student.ID = Convert.ToString(values[0]);
                    student.Fullname = Convert.ToString(values[1]);
                    student.Address = Convert.ToString(values[2]);
                    student.Contact = Convert.ToString(values[3]);
                    student.courseEnroll = Convert.ToString(values[4]);
                    student.RegistrationDate = Convert.ToString(values[5]);
                    studentList.Add(student);
                }
                _studentList = studentList;

                if (File.Exists("studentDetails.csv"))
                {
                    DGStudentDetailsImport.ItemsSource = _studentList2;
                    this.DGStudentDetailsImport.ItemsSource = _studentList;
                    MessageBox.Show("Successfully Imported and Saved to CSV", "Success");
                    ExportToCSV(studentList, "studentDetails.csv");

                }
                else
                {
                    this.DGStudentDetailsImport.ItemsSource = _studentList;
                    MessageBox.Show("Successfully Imported and Saved to CSV", "Success");
                    ExportToCSV(studentList, "studentDetails.csv");

                    
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
            catch (Exception ex)            {
                System.Windows.MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }
    }
}


