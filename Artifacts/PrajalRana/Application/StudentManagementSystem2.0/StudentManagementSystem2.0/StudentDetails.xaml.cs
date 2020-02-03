using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
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
using System.Windows.Shapes;
using DataHandler;
using Microsoft.Win32;

namespace StudentManagementSystem2._0 {
    /// <summary>
    /// Interaction logic for StudentDetails.xaml
    /// </summary>
    public partial class StudentDetails : Window {
        
        public StudentDetails() {
            InitializeComponent();
            //display_Report();
        }

        

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            StudentRegistration stdRegistration = new StudentRegistration();
            stdRegistration.Show();
        }
        
        private void gridStudentDetails_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            
        }
        private void display_Report() {
            string sampleXmlFile = @"E:\College\3rd Year\Application Development\StudentReport.xml"; // assiging path to sting variable sampleXmlFile
            DataSet dataset = new DataSet(); // declaring new DataSet dataset
            dataset.ReadXml(sampleXmlFile); // sampleXMlFile is read as an XML file.
 
            DataTable buffer = new DataTable("dt");
            buffer.Columns.Add("ID", typeof(String));
            buffer.Columns.Add("Name", typeof(String));
            buffer.Columns.Add("Address", typeof(String));
            buffer.Columns.Add("ContactNo", typeof(String));
            buffer.Columns.Add("EmailAddress", typeof(String));
            buffer.Columns.Add("CourseEnroll", typeof(String));
            buffer.Columns.Add("Date", typeof(String));
           
            for(int i=0;i< dataset.Tables[0].Rows.Count; i++)
            {
                string s = dataset.Tables[0].Rows[i][6].ToString();
                DateTime dtime = DateTime.Parse(s);
                buffer.Rows.Add(
                    dataset.Tables[0].Rows[i][0].ToString(),
                    dataset.Tables[0].Rows[i][1].ToString(),
                    dataset.Tables[0].Rows[i][2].ToString(),
                    dataset.Tables[0].Rows[i][3].ToString(),
                    dataset.Tables[0].Rows[i][4].ToString(),
                    dataset.Tables[0].Rows[i][5].ToString(),
                    dtime.ToShortDateString());
                
            }

            DataView dataView = new DataView(buffer); // setting the itemsource to table 
            gridStudentDetails.ItemsSource = dataView;  // viewing table to data grid
        }


        private void btnRetrive_Click(object sender, RoutedEventArgs e) {
            display_Report();
        }

        private void btnImportFromCSV_Click(object sender, RoutedEventArgs e) {
            

            try
            {
                var dataSet = new DataSet();  //declaring new DataSet dataSet
                dataSet.ReadXml(@"E:\College\3rd Year\Application Development\StudentReport.xml"); // xml file is read and set as dataSet
                Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog(); // for opening folder
                if (dialog.ShowDialog() == true)  // if folder is accesed
                {
                    string filename = dialog.FileName;
                    using (var read = new StreamReader(filename)) {
                        read.ReadLine();
                        while (!read.EndOfStream)
                        {
                            var line = read.ReadLine();
                            var values = line.Split(',');
                            var newRow = dataSet.Tables["StudentReport"].NewRow();

                            newRow["ID"] = values[0];
                            newRow["Name"] = values[1];
                            newRow["Address"] = values[2];
                            newRow["ContactNo"] = values[3];
                            newRow["EmailAddress"] = values[4];
                            newRow["CourseEnroll"] = values[5];
                            newRow["RegistrationDate"] = values[6];
                            dataSet.Tables["StudentReport"].Rows.Add(newRow);

                            dataSet.WriteXml(@"E:\College\3rd Year\Application Development\StudentReport.xml"); // data is appeded to the xml file
                        }
                    }
                    MessageBox.Show("Student record sucessfully imported");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
    }
}
