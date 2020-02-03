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

namespace StudentInformationSystem
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
                    // var csvData = System.IO.File.ReadAllText(dlg.FileName);

                    //1st row contains property name so skipping the first row.
                    // var lines = csvData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Skip(1);
                    var lines = File.ReadLines(dlg.FileName);



                    //foreach (var item in lines)
                    //{
                    //    var values = item.Split(',');
                    foreach (var line in lines)
                    {



                        var res = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Student student = new Student();
                        student.stdidNum = Convert.ToString(res[0]);
                        student.stdfullName = Convert.ToString(res[1]);
                        student.stdaddress = Convert.ToString(res[2]);
                        student.contactNum = Convert.ToString(res[3]);
                        student.courseName = Convert.ToString(res[4]);
                        student.registerDate = Convert.ToString(res[5]);
                        studentList.Add(student);
                    }
                    _studentList = studentList;

                    if (File.Exists("studentDetails.csv"))
                    {
                        datagrid2.ItemsSource = _studentList2;
                        this.datagrid2.ItemsSource = _studentList;
                        //ExportToCSV(studentList, "studentDetails.csv");

                        datagrid2.SelectAllCells();
                        datagrid2.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, datagrid2);
                        datagrid2.UnselectAllCells();
                        String result2 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                        File.AppendAllText("studentDetails.csv", result2, UnicodeEncoding.UTF8);



                    }
                    else
                    {

                        this.datagrid2.ItemsSource = _studentList;
                        //ExportToCSV(studentList, "studentDetails.csv");
                        datagrid2.SelectAllCells();
                        datagrid2.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                        ApplicationCommands.Copy.Execute(null, datagrid2);
                        datagrid2.UnselectAllCells();
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
