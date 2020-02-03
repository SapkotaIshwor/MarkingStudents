using DataHandler;
using Microsoft.Win32;
using System;
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
using Path = System.IO.Path;

namespace ApplicationDevelopmentCW
{
    /// <summary>
    /// Interaction logic for ImportFile.xaml
    /// </summary>
    public partial class ImportFile : Window
    {
        public ImportFile()
        {
            InitializeComponent();
        }

        private void btnImportClick(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".csv";
            Nullable<bool> load = dialog.ShowDialog();

            if (load == true)
            {
                DataTable stdinfo = DataTableFromCsv(dialog.FileName, true);
                DataTable dataTable = stdinfo.Clone();
                dataTable.Columns["RegNo"].DataType = typeof(String);
                dataTable.Columns["ContactNo"].DataType = typeof(String);
                dataTable.Columns["RegistrationDate"].DataType = typeof(String);
                foreach (DataRow row in stdinfo.Rows)
                {
                    dataTable.ImportRow(row);
                }

                Handler handler = new Handler();
                DataSet dataSet = handler.CreateDataSet();
                dataSet.Tables["StudentReport"].ReadXml(@"Files\\StudentReport.xml");
                dataSet.Tables["StudentReport"].Merge(dataTable);
                dataSet.Tables["StudentReport"].WriteXml(@"Files\\StudentReport.xml");

                var dataset = new DataSet();
                //dataSet.ReadXml(@"D:\StudentReport.xml");
                DataTable dataTable1 = dataSet.Tables["StudentReport"];
                dataImportGrid.DataContext = dataTable1.DefaultView;
            }
            else
            {
                MessageBox.Show("File not found", "Alert");
            }
        }

        static DataTable DataTableFromCsv(string path, bool isFirstRowHeader)
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

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            MainWindow showWindow = new MainWindow();
            showWindow.Show();
            this.Close();
        }
    }
}
