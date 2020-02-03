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

namespace Student_Management_System.Forms
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : Window
    {
        List<StudentInfo> stdList1 = new List<StudentInfo>();
        List<StudentInfo> stdList2 = new List<StudentInfo>();
        public Import()
        {
            InitializeComponent();
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "CSV files|*.csv";

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                var csvData = System.IO.File.ReadAllText(dialog.FileName);
                ReadFromCSV(csvData);

            }
        }

        public List<StudentInfo> ReadFromCSV(string csvData)
        {
            List<StudentInfo> stdList = new List<StudentInfo>();
            try
            {
                //to skip the first row as it contains property name
                var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    StudentInfo stdobj = new StudentInfo();
                    stdobj.ID = Convert.ToString(values[0]);
                    stdobj.Student_Name = Convert.ToString(values[1]);
                    stdobj.Gender = Convert.ToString(values[2]);
                    stdobj.Address = Convert.ToString(values[3]);
                    stdobj.Contact = Convert.ToString(values[4]);
                    stdobj.Email = Convert.ToString(values[5]);
                    stdobj.Programme = Convert.ToString(values[6]);
                    stdobj.Registration_Date = Convert.ToString(values[7]);
                    stdList.Add(stdobj);
                }
                stdList1 = stdList;

                if (File.Exists("studentDetails.csv"))
                {
                    importDatagrid.ItemsSource = stdList2;
                    this.importDatagrid.ItemsSource = stdList1;
                    System.Windows.MessageBox.Show("Successfully Imported and Saved to CSV", "Success");
                    ExportToCSV(stdList, "studentDetails.csv");

                }
                else
                {
                    this.importDatagrid.ItemsSource = stdList1;
                    System.Windows.MessageBox.Show("Successfully Imported and Saved to CSV", "Success");
                    ExportToCSV(stdList, "studentDetails.csv");

                }
             
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message.ToString(), "Error");
            }
            return stdList;

        }

        public void ExportToCSV(List<StudentInfo> students, string filePath)
        {
            try
            {
                if (students.Count > 0)
                {
                    var propList = students[0].GetType().GetProperties().Select(prop => prop.Name).ToList();
                    //TextWriter for creating output and streamWriter for reading file location

                    using (TextWriter TW = new StreamWriter(filePath, append: true))
                    {
                        
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
                System.Windows.MessageBox.Show("Not able to save the data", "Error Saving data", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
