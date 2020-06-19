using CourseWorkSample;
using DataHandler;
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

namespace APPLICATION_DEVELOPMENT
{
    /// <summary>
    /// Interaction logic for RetriveWindow.xaml
    /// </summary>
    public partial class RetriveWindow : Window
    {
        public RetriveWindow()
        {
            InitializeComponent();
            LoadStudentData();// method call

        }

        private void LoadStudentData()
        {

            if (System.IO.File.Exists(@"F:\StudentReport.xml"))
            {
                var handler = new Handler();


                var dataSet = new DataSet();

                dataSet.ReadXml(@"F:\StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grtd_Retrive.DataContext = dtStdReport.DefaultView;
            }

        }

        private void student_Date_regis_Click(object sender, RoutedEventArgs e)
        {

            RegisterInDate Date = new RegisterInDate();
            Date.Show();
            Close();
            MessageBox.Show("Student details registered according to date is depicted!!");
        }

        private void student_Name_regis_Click(object sender, RoutedEventArgs e)
        {
            RegisterInName Name = new RegisterInName();
            Name.Show();
            Close();
            MessageBox.Show("Student details registered according to name is depicted!!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Chart_Diagram chart = new Chart_Diagram();
            chart.Show();
            Close();
            MessageBox.Show("Student details registered on weekly basis is shown in Pie-chart!!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WeeklyStudentReport report = new WeeklyStudentReport();
            report.Show();
            Close();
            MessageBox.Show("Weekly Report is depicted!!");
        }

        private void CSV_FILE_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".csv";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                
                DataTable tableStd = ExtractsReportFromCSV(dlg.FileName, true);
                
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(@"F:\StudentReport.xml");
                foreach(DataRow dr in tableStd.Rows)
                {
                    var newRow = dataSet.Tables["StudentReport"].NewRow();//New data row on the smae table is created.
                    newRow["RegisNo"] = dr["RegisNo"];
                    newRow["Name"] = dr["Name"];
                    newRow["Address"] = dr["Address"];
                    newRow["ContactNo"] = dr["ContactNo"];
                    newRow["CourseEnroll"] = dr["CourseEnroll"];
                    newRow["RegistrationDate"] = dr["RegistrationDate"];
                    dataSet.Tables["StudentReport"].Rows.Add(newRow);

                }
                dataSet.Tables["StudentReport"].WriteXml(@"F:\StudentReport.xml");
                
                //var datasett = new DataSet();
                //datasett.ReadXml(@"F:\StudentReport.xml");
                DataTable table = dataSet.Tables["StudentReport"];
                grtd_Retrive.DataContext = table.DefaultView;

                // lblWindowName.Content = "DataTable showing CSV files.";
                
            }

        }

        static DataTable ExtractsReportFromCSV(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";

            string pathAddress = System.IO.Path.GetDirectoryName(path);
            string fileName = System.IO.Path.GetFileName(path);

            string sql = @"SELECT * FROM [" + fileName + "]";

            using (OleDbConnection join = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathAddress +
                      ";Extended Properties=\"Text;HDR=" + header + "\""))
            using (OleDbCommand command = new OleDbCommand(sql, join))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            back.Show();
            Close();

        }

    }
}
