
using DataHandler;
using Microsoft.Win32;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using Path = System.IO.Path;

namespace CourseWorkSample
{

    /// <summary>
    /// Interaction logic for StudentDetails.xaml
    /// </summary>
    public partial class StudentDetails : Window
    {
        DataTable dtStdReport;

        //public object BrowseTextBox { get; private set; }

        public StudentDetails()
        {
            InitializeComponent();
            LoadStudentData();
        }



        private void LoadStudentData()
        {

            if (System.IO.File.Exists(@"D:\StudentReport.xml"))
            {

                var dataSet = new DataSet();
                dataSet.ReadXml(@"D:\StudentReport.xml");

                //DataTable dtStdReport = new DataTable("dt");
                dtStdReport = dataSet.Tables[0];
                grdStd.DataContext = dtStdReport.DefaultView;
            }

        }

        private void btn_weeklyreport_Click(object sender, RoutedEventArgs e)
        {



            int sum_computing = 0;
            int sum_mediatechnology = 0;
            int sum_networksanditsecurity = 0;
            int sum_cybersecurityandethicalhacking = 0;

            DataTable dtable = new DataTable("tbl");
            dtable.Columns.Add("Course Enroll", typeof(String));
            dtable.Columns.Add("Sum Students", typeof(int));


            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                String col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    sum_computing++;
                }
                else if (col == "Multimedia Technology")
                {
                    sum_mediatechnology++;
                }
                else if (col == "Networking and IT Security")
                {
                    sum_networksanditsecurity++;
                }
                else if (col == "Cyber Security and Ethical Hacking")
                {
                    sum_cybersecurityandethicalhacking++;
                }

            }

            dtable.Rows.Add("Computing", sum_computing);
            dtable.Rows.Add("Multimedia Technology", sum_mediatechnology);
            dtable.Rows.Add("Networking and IT Security", sum_networksanditsecurity);
            dtable.Rows.Add("Cyber Security and Ethical Hacking", sum_cybersecurityandethicalhacking);

            grdStd.DataContext = dtable.DefaultView;


        }

        private void btn_sortregistrationdate_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"D:\StudentReport.xml"))
            {

                var dataSet = new DataSet();
                dataSet.ReadXml(@"D:\StudentReport.xml");

                //DataTable dtStdReport = new DataTable("dt");
                dtStdReport = dataSet.Tables[0];
                dtStdReport.DefaultView.Sort = "RegistrationDate ASC";
                grdStd.DataContext = dtStdReport.DefaultView;

            }
            MessageBox.Show("Sucessfully Import CSV File and Merge with XML File");

        }

        private void btn_sortname_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"D:\StudentReport.xml"))
            {

                var dataSet = new DataSet();
                dataSet.ReadXml(@"D:\StudentReport.xml");

                //DataTable dtStdReport = new DataTable("dt");
                dtStdReport = dataSet.Tables[0];
                dtStdReport.DefaultView.Sort = "Name ASC";
                grdStd.DataContext = dtStdReport.DefaultView;
            }
            MessageBox.Show("Sucessfully Import CSV File and Merge with XML File");

        }
        static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";

            string pathOnly = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);

            string sql = @"SELECT * FROM [" + fileName + "]";

            using (OleDbConnection connection = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
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




        private void Btn_import_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".csv";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                DataTable tablestd = GetDataTableFromCsv(dlg.FileName, true);
                DataTable dataTable = tablestd.Clone();
                dataTable.Columns["ContactNo"].DataType = typeof(String);
                dataTable.Columns["Address"].DataType = typeof(String);
                dataTable.Columns["RegNo"].DataType = typeof(String);
                dataTable.Columns["RegistrationDate"].DataType = typeof(String);
                foreach (DataRow row in tablestd.Rows)
                {
                    dataTable.ImportRow(row);
                }
                Handler handler = new Handler();
                DataSet dataSet = handler.CreateDataSet();
                dataSet.Tables["StudentReport"].ReadXml(@"D:\StudentReport.xml");
                dataSet.Tables["StudentReport"].Merge(dataTable);
                dataSet.Tables["StudentReport"].WriteXml(@"D:\StudentReport.xml");

                var dataset1 = new DataSet();
                dataSet.ReadXml(@"D:\StudentReport.xml");
                DataTable table1 = dataset1.Tables["StudentReport"];
                grdStd.DataContext = tablestd.DefaultView;
            }

            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f1 = new MainWindow();
            f1.ShowDialog();
            this.Hide();
        }

        private void btn_chart_Click(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }
    }
}



