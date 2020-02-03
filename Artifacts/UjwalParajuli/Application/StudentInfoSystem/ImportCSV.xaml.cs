using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace StudentInfoSystem
{

    /// <summary>
    /// Interaction logic for ImportCSV.xaml
    /// </summary>
    public partial class ImportCSV : Page
    {
        List<Student> _studentList = new List<Student>();
        List<Student> _studentList2 = new List<Student>();
        public ImportCSV()
        {
            InitializeComponent();
        }

        private void ButtonImport_Click(object sender, RoutedEventArgs e)
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
                    student.idNumber = Convert.ToString(values[0]);
                    student.firstName = Convert.ToString(values[1]);
                    student.lastName = Convert.ToString(values[2]);
                    student.address = Convert.ToString(values[3]);
                    student.contactNo = Convert.ToString(values[4]);
                    student.courseName = Convert.ToString(values[5]);
                    student.registerDate = Convert.ToString(values[6]);
                    studentList.Add(student);
                }
                _studentList = studentList;

                if (File.Exists("studentDetails.csv"))
                {
                    dgSecond.ItemsSource = _studentList2;
                    this.dgSecond.ItemsSource = _studentList;
                    MessageBox.Show("Successfully Imported and Saved to CSV", "Success");
                    ExportToCSV(studentList, "studentDetails.csv");
                }
                else
                {
                    this.dgSecond.ItemsSource = _studentList;
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

        public void f()
        {
            throw new System.NotImplementedException();
        }
    }
}
