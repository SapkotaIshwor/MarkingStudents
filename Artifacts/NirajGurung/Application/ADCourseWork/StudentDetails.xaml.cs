using DataHandler;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
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

namespace CourseWorkSample
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void displayDataInGrid_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists("Files/StudentReport.xml"))
            {
                var handler = new Handler();

                var dataSet = new DataSet();

                dataSet.ReadXml("Files/StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdStd.DataContext = dtStdReport.DefaultView;
            }
        }

        private void btnSortDate_Click(object sender, RoutedEventArgs e)
        {
            sortByDate();
        }

        private void sortByDate()
        {

            if (System.IO.File.Exists("Files/StudentReport.xml"))
            {
                var dataSet = new DataSet();

                dataSet.ReadXml("Files/StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                dtStdReport.DefaultView.Sort = "RegistrationDate ASC";
                grdStd.DataContext = dtStdReport.DefaultView;
            }
        }

        private void sortByName()
        {
            if (System.IO.File.Exists("Files/StudentReport.xml"))
            {
                var dataSet = new DataSet();

                dataSet.ReadXml("Files/StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                dtStdReport.DefaultView.Sort = "Name ASC";
                grdStd.DataContext = dtStdReport.DefaultView;
            }
        }

        private void btnSortName_Click(object sender, RoutedEventArgs e)
        {
            sortByName();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();

            dataSet.ReadXml("Files/StudentReport.xml");

            DataTable dtStdReport = dataSet.Tables[0];

            int BHM = 0;
            int BBA = 0;
            int BIT = 0;

            DataTable dt = new DataTable("Report");

            dt.Columns.Add("CourseEnroll", typeof(String));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                String col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "BHM")
                {
                    BHM++;
                }
                else if (col == "BBA")
                {
                    BBA++;
                }
                else if (col == "BIT")
                {
                    BIT++;
                }
            }
            dt.Rows.Add("BHM", BHM);
            dt.Rows.Add("BBA", BBA);
            dt.Rows.Add("BIT", BIT);
            grdStd.DataContext = dt.DefaultView;
        }

        private void displayCSV_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".csv";
            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                DataTable tableStd = getCsv(dialog.FileName, true);
                DataTable dataTable = tableStd.Clone();
                dataTable.Columns["ContactNo"].DataType = typeof(String);
                dataTable.Columns["RegNo"].DataType = typeof(String);
                //dataTable.Columns["RegistrationDate"].DataType = typeof(String);
                foreach (DataRow row in tableStd.Rows) {
                    dataTable.ImportRow(row);
                }
                Handler handler = new Handler();
                DataSet dataSet = handler.CreateDataSet();
                dataSet.Tables["StudentReport"].ReadXml("Files/StudentReport.xml");
                dataSet.Tables["StudentReport"].Merge(dataTable);
                dataSet.Tables["StudentReport"].WriteXml("Files/StudentReport.xml");

                var dataset1 = new DataSet();
                dataSet.ReadXml("Files/StudentReport.xml");
                DataTable dataTable1 = dataset1.Tables["StudentReport"];
                grdStd.DataContext = tableStd.DefaultView;
            }
        }

        static DataTable getCsv(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";

            string pathOnly = System.IO.Path.GetDirectoryName(path);
            string fileName = System.IO.Path.GetFileName(path);

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
    }
}
