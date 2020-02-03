using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;


namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for ImportReport.xaml
    /// </summary>
    public partial class ImportReport : Window
    {
        string CurrentPath = AppDomain.CurrentDomain.BaseDirectory;
        private string fileName;
        public ImportReport()
        {
            InitializeComponent();
        }

        public void loadDataGridView()
        {
            var dataSet = new DataSet();
            dataSet.ReadXmlSchema(CurrentPath + "\\StudentCWSchema.xml");
            dataSet.ReadXml(@CurrentPath + "\\StudentCWData.xml");
            dataGrid.ItemsSource = new DataView(dataSet.Tables["Student"]);
        }

        private void Btn_Import_File(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Select file";

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            openFileDialog.FileName = txtFileName.Text;

            // Set filter for file extension and default file extension 

            // openFileDialog.Filter = "Text and CSV Files(*.txt, *.csv)|*.txt;*.csv|Text Files(*.txt)|*.txt|CSV Files(*.csv)|*.csv|All Files(*.*)|*.*";
            openFileDialog.Filter = "(.csv)|*.csv";
            openFileDialog.FilterIndex = 1;

            openFileDialog.RestoreDirectory = true;
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = openFileDialog.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                fileName = openFileDialog.FileName;
                txtFileName.Text = fileName;

                var studentInfo = ReadAll();
                dataGrid.ItemsSource = studentInfo;
            }
        }
        
        private void Btn_LoadCSV(object sender, RoutedEventArgs e)
        {
            loadDataGridView();
        }

        public List<StudentInfo> ReadAll()
        {
            if (!File.Exists(fileName))
            {
                MessageBox.Show("Student Info file doesn't exist", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new FileNotFoundException("Student Info file doesn't exist");
            }
            List<StudentInfo> students = new List<StudentInfo>();
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    var studentString = streamReader.ReadLine();
                    var studentInfo = new StudentInfo(studentString);
                    students.Add(studentInfo);
                }
                streamReader.Close();
            }
            return students;
        }

        private void Btn_Register(object sender, RoutedEventArgs e)
        {
            var dataHandler = new DataHandler();
            var dataSet = new DataSet();
            if (File.Exists(@CurrentPath + "\\StudentCWData.xml"))
            {
                dataSet.ReadXmlSchema(@CurrentPath + "\\StudentCWSchema.xml");
                dataSet.ReadXml(@CurrentPath + "\\StudentCWData.xml");
                AddCsvData(dataSet);
                dataSet.WriteXml(@CurrentPath + "\\StudentCWData.xml");
            }
            else
            {
                dataSet = dataHandler.CreateDataSet();
                AddCsvData(dataSet);
                if (!File.Exists(@CurrentPath + "\\StudentCWSchema.xml"))
                {
                    dataSet.WriteXmlSchema(@CurrentPath + "\\StudentCWSchema.xml");
                }

                dataSet.WriteXml(@CurrentPath + "\\StudentCWData.xml");
            }
            MessageBox.Show("Student Enrolled Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddCsvData(DataSet dataSet)
        {
            var stdData = ReadAll();
            foreach (StudentInfo students in stdData)
            {
                var dr = dataSet.Tables["Student"].NewRow();
                dr["RegID"] = students.RegID;
                dr["FirstName"] = students.FirstName;
                dr["LastName"] = students.LastName;
                dr["Address"] = students.Address;
                dr["ContactNo"] = students.ContactNo;
                dr["CourseEnroll"] = students.CourseEnroll;
                dr["RegistrationDate"] = DateTime.Today;
                //dr["RegistrationDate"] = Convert.ToDateTime(students.RegistrationDate);
                //dr["RegistrationDate"] = DateTime.Now.ToString(students.RegistrationDate);
                //dr["RegistrationDate"] = DateTime.ParseExact(students.RegistrationDate, "dd/MM/yyyy", null);
                //dr["RegistrationDate"] = Convert.ToDateTime(students.RegistrationDate, formatInfo);
                dataSet.Tables["Student"].Rows.Add(dr);
            }
        }

        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
