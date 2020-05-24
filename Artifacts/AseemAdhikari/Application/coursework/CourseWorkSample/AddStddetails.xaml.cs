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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseWorkSample
{
    /// <summary>
    /// Interaction logic for AddStddetails.xaml
    /// </summary>
    public partial class AddStddetails : Window
    {
        public AddStddetails()
        {
            InitializeComponent();
        }

        private void ImportCSV_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".csv";
            Nullable<bool> load = dialog.ShowDialog();

            if (load == true)
            {
                DataTable stdinfo = import_From_CSV(dialog.FileName, true);
                gridStudentDetails.ItemsSource = stdinfo.DefaultView;

            }
            else
            {
                MessageBox.Show("File not found");
            }
        }
        private void stddetails_Click(object sender, RoutedEventArgs e)
        {
            Stddetails std = new Stddetails();
            std.Show();
        }
        static DataTable import_From_CSV(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";

            string pathdirectory = System.IO.Path.GetDirectoryName(path);
            string filename = System.IO.Path.GetFileName(path);

            string sql = @"SELECT * FROM [" + filename + "]";

            using (OleDbConnection connection = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathdirectory +
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
        private void AddStudentDetails(DataSet dataset)
        {

            var dt_student = dataset.Tables["Student"].NewRow();
            dt_student["Name"] = txtName.Text;
            dt_student["Address"] = txtAddress.Text;
            dt_student["ContactNo"] = txtContact.Text;
            dt_student["CourseEnroll"] = cbCourseEnroll.Text;
            dt_student["EmailAddress"] = txtemail.Text;
            dt_student["RegistrationDate"] = RegistrationDate.SelectedDate.ToString();
            //MessageBox.Show("Date Added" + dpRegistrationDate.SelectedDate.ToString());
            dataset.Tables["Student"].Rows.Add(dt_student);

        }
        private void AppendStudentDetails(DataSet dataset)
        {

            if (File.Exists(@"D:\Year 3\Application Development\cw1\StudentReport.xml"))
            {
                dataset.Tables["StudentReport"].ReadXml(@"D:\Year 3\Application Development\cw1\StudentReport.xml");
                var dt_student = dataset.Tables["StudentReport"].NewRow();
                dt_student["Name"] = txtName.Text;
                dt_student["Address"] = txtAddress.Text;
                dt_student["ContactNo"] = txtContact.Text;
                dt_student["CourseEnroll"] = cbCourseEnroll.Text;
                dt_student["EmailAddress"] = txtemail.Text;
                dt_student["RegistrationDate"] = RegistrationDate.SelectedDate;
                dataset.Tables["StudentReport"].Rows.Add(dt_student);

                dataset.Tables["StudentReport"].WriteXml(@"D:\Year 3\Application Development\cw1\StudentReport.xml");
            }
            else
            {
                dataset.Tables["StudentReport"].WriteXml(@"D:\Year 3\Application Development\cw1\StudentReport.xml");
                AppendStudentDetails(dataset);
            }

        }

        private void Show_Student_Details()
        {
            if (File.Exists(@"D:\Year 3\Application Development\cw1\StudentReport.xml"))
            {
                var dataset = new DataSet();
                dataset.ReadXml(@"D:\Year 3\Application Development\cw1\StudentReport.xml");
            }
            else
            {
                MessageBox.Show("Sorry, there's data. Please fill up the form to view data.");
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataset = handler.CreateDataSet();
            AddStudentDetails(dataset);
            AppendStudentDetails(dataset);

            dataset.Tables["Student"].WriteXml(@"D:\Year 3\Application Development\cw1\" + txtName.Text + "Data.xml");
            //Res_no_write(txtResNo.Text);
            //txtResNo.Text = Res_no_read();

            MessageBox.Show("Sudent Details saved successfully!");
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtemail.Text = "";
            //cbCourseEnroll.SelectedIndex
            //dpRegistrationDate.SelectedDate
            Stddetails stddetails = new Stddetails();
            stddetails.Show();
        }


        private void SortDate_Click(object sender, RoutedEventArgs e)
        {
            SortByDate std = new SortByDate();
            std.Show();

        }

        private void SortName_Click(object sender, RoutedEventArgs e)
        {
           
            SortByName std = new SortByName();
            std.Show();


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
