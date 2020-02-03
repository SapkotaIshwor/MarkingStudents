using DataHandler;
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Windows;


namespace ApplicationDevelopment
{
    public partial class StudentList : Window
    {
        DataTable dataTable;

        public StudentList()
        {
            InitializeComponent();
            Load_stu_data();
        }

        private void Load_stu_data()
        {
            if (File.Exists("Student Report/StudentReport.xml"))
            {
                var dataset = new DataSet();
                dataset.ReadXml("Student Report/StudentReport.xml");

                dataTable = dataset.Tables["StudentReport"];
                stdGrid.DataContext = dataTable.DefaultView;
            }
        }

        private void btnWeekly_Click(object sender, RoutedEventArgs e)
        {
            int total_Com = 0;
            int total_Mul = 0;
            int total_Net = 0;

            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enroll", typeof(String));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                String col = dataTable.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    total_Com++;
                }
                else if(col == "Multimedia Technologies")
                {
                    total_Mul++;
                }
                else if(col == "Networks and IT Security")
                {
                    total_Net++;
                }
            }

            dt.Rows.Add("Computing", total_Com);
            dt.Rows.Add("Multimedia Technologies", total_Mul);
            dt.Rows.Add("Networks and IT Security", total_Net);


            stdGrid.DataContext = dt.DefaultView;
            lblWindowName.Content = "DataTable of Weekly Report";
        }

        private void btnDateSort_Click(object sender, RoutedEventArgs e)
        {
            var dataset = new DataSet();
            dataset.ReadXml("Student Report/StudentReport.xml");

            dataTable = dataset.Tables["StudentReport"];
            dataTable.DefaultView.Sort = "RegistrationDate ASC";
            stdGrid.DataContext = dataTable.DefaultView;
            lblWindowName.Content = "DataTable Sorted by Registration Date";
        }

        private void btnFNameSort_Click(object sender, RoutedEventArgs e)
        {
            var dataset = new DataSet();
            dataset.ReadXml("Student Report/StudentReport.xml");

            dataTable = dataset.Tables["StudentReport"];
            dataTable.DefaultView.Sort = "Name ASC";
            stdGrid.DataContext = dataTable.DefaultView;
            lblWindowName.Content = "DataTable Sorted by Student Name";
        }

        private void btnStuDetails_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("Student Report/StudentReport.xml"))
            {
                var dataset = new DataSet();
                dataset.ReadXml("Student Report/StudentReport.xml");

                DataTable tableStd = dataset.Tables["StudentReport"];
                stdGrid.DataContext = tableStd.DefaultView;
                lblWindowName.Content = "DataTable of Student Details";
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnViewCSV_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".csv";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                DataTable tableStd = GetStudentReportFromCsv(dlg.FileName, true);
                stdGrid.DataContext = tableStd.DefaultView;
                lblWindowName.Content = "DataTable showing CSV files.";
            }

        }

        static DataTable GetStudentReportFromCsv(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";
           
            string pathAddress = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);

            string sql = @"SELECT * FROM [" + fileName + "]";

            using (OleDbConnection connection = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathAddress +
                      ";Extended Properties=\"Text;HDR=" + header + "\""))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".csv";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                DataTable tableStd = GetStudentReportFromCsv(dlg.FileName, true);
                DataTable dtCloned = tableStd.Clone();
                dtCloned.Columns["ContactNo"].DataType = typeof(String);
                dtCloned.Columns["RegistrationDate"].DataType = typeof(String);
                foreach (DataRow row in tableStd.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                var handler = new Handler();
                var dataSet = handler.CreateDataSet();
                dataSet.Tables["StudentReport"].ReadXml("Student Report/StudentReport.xml");
                dataSet.Tables["StudentReport"].Merge(dtCloned);
                dataSet.Tables["StudentReport"].WriteXml("Student Report/StudentReport.xml");

                {
                    var dataset = new DataSet();
                    dataset.ReadXml("Student Report/StudentReport.xml");
                    DataTable table = dataset.Tables["StudentReport"];
                    stdGrid.DataContext = table.DefaultView;
                    lblWindowName.Content = "DataTable of Student Details";
                }
            }
        }
    }
}
