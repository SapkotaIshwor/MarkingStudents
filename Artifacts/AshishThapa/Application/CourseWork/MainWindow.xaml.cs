using DataHandler;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace StudentInformationSystem
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dtStdReport = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            Startup();

            txtRegNo.Text = read_from_file();
            LoadStudentData();


        }

        public void Startup()
        {
         
        }

        private void AddSampleDataforStd(DataSet dataSet)
        {

            //var dr = dataSet.Tables["Course"].NewRow();
            //dr["Name"] = "BBA";
            //dr["DisplayText"] = "BBA Hons";
            //dataSet.Tables["Course"].Rows.Add(dr);

            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["Name"] = txtName.Text;
            dr1["Email"] = txtEmail.Text;
            dr1["Address"] = txtAddress.Text;
            dr1["ContactNo"] = txtContact.Text;
            dr1["CourseEnroll"] = comboSubject.Text;
            dr1["RegistrationDate"] = DateTime.Now.ToString("h:mm:ss tt");
            dataSet.Tables["Student"].Rows.Add(dr1);


        }

        private void  AppendStdReport(DataSet dataSet)
        {

            var handler = new Handler();

            dataSet.Tables["StudentReport"].ReadXml(@"D:\StudentReport.xml");

            var dr2 = dataSet.Tables["StudentReport"].NewRow();
            dr2["RegNo"] = txtRegNo.Text;
            dr2["Name"] = txtName.Text;
            dr2["Email"] = txtEmail.Text;
            dr2["Address"] = txtAddress.Text;
            dr2["ContactNo"] = txtContact.Text;
            dr2["CourseEnroll"] = comboSubject.Text;
            dr2["RegistrationDate"] = DateTime.Now.ToString("h:mm:ss tt");
            dataSet.Tables["StudentReport"].Rows.Add(dr2);

            dataSet.Tables["StudentReport"].WriteXml(@"D:\StudentReport.xml");

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            AddSampleDataforStd(dataSet);
            AppendStdReport(dataSet);

            var regno = txtRegNo.Text;
            var name = txtName.Text;
            //dataSet.WriteXmlSchema(@"D:\StudentCWSchema1.xml");
            dataSet.Tables["Student"].WriteXml(@"D:\" + name + "CWData" + regno + ".xml");

            //dataSet.Tables[2].WriteXml(@"D:\StudentReport.xml");

            write_to_file(txtRegNo.Text);
            

            if (txtName.Text == "" && txtAddress.Text==""&&txtEmail.Text==""&&txtContact.Text=="")
            {
                MessageBox.Show("Complete the input field. ");
                
            }

           else if(!this.txtEmail.Text.Contains('@')&&!this.txtEmail.Text.Contains('.'))
                {
                MessageBox.Show("Enter a valid email address with @ and . ", "Invalid Email");
                return;
            }
           //else if (txtContact.Text.Length <= 10) 
           // { 
           //     MessageBox.Show("Enter a Valid phone number (Max 10 digit)");
           //     return;

           // }
            else
            {
                txtRegNo.Text = read_from_file();
                MessageBox.Show("Data Added ^_^");
                ClearControls();
                LoadStudentData();
            }
        }

        private void write_to_file(string text)
        {


            System.IO.File.WriteAllText(@"D:\count.txt", text);


        }
        private string read_from_file()
        {

            string text = System.IO.File.ReadAllText(@"D:\count.txt");

            int i;

            i = int.Parse(text.ToString());
            i = i + 1;

            return i.ToString();

        }

        private void ClearControls()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
        }
        private void LoadStudentData()
        {

            if (System.IO.File.Exists(@"D:\StudentReport.xml"))
            {
                var handler = new Handler();

                var dataSet = new DataSet();

                dataSet.ReadXml(@"D:\StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdStd.DataContext = dtStdReport.DefaultView;
            }

        }

        private void LoadDataforReport1()
        { 


        
        }

        private void grdReport1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Regex regex = new Regex("[^a-zA-Z]+");
            //if (regex.IsMatch(txtName.Text))
            //{
            //    MessageBox.Show("Only alphabets are allowed !");
            //}
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();

            var dataSet = new DataSet();

            dataSet.ReadXml(@"D:\StudentReport.xml");

           // DataTable dtStdReport = new DataTable();
            dtStdReport = dataSet.Tables[0];
            dtStdReport.DefaultView.Sort = "Name ASC";
            grdStd.DataContext = dtStdReport.DefaultView;



            //grdStd.Sorting(grdStd.Columns[1], IsDescendantOf);

        }

        private void btnDate_Click(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();

            var dataSet = new DataSet();

            dataSet.ReadXml(@"D:\StudentReport.xml");
            dtStdReport = dataSet.Tables[0];
            dtStdReport.DefaultView.Sort = "RegistrationDate ASC";
            grdStd.DataContext = dtStdReport.DefaultView;
        }

        private void btnCount(object sender, RoutedEventArgs e)
        {
            int bit_Total = 0;
            int bba_Total = 0;
            int marketing_Total = 0;
            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Programme", typeof(string));
            dt.Columns.Add("Total Students", typeof(int));
            for(int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                String subject = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (subject == "BIT")
                {
                    bit_Total++;
                }
                else if (subject == "BBA")
                {
                    bba_Total++;
                }
                else if (subject == "Marketing")
                {
                    marketing_Total++;
                }
            }
            dt.Rows.Add("BIT", bit_Total);
            dt.Rows.Add("BBA", bba_Total);
            dt.Rows.Add("Marketing",marketing_Total);
            grdStd.DataContext = dt.DefaultView;
        }

        private void grdStd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnImport(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".csv";
            Nullable<bool> load = dialog.ShowDialog();

            if (load == true)
            {
                DataTable stdinfo = DataTableFromCsv(dialog.FileName, true);
                DataTable dataTable = stdinfo.Clone();
                dataTable.Columns["ContactNo"].DataType = typeof(String);
                dataTable.Columns["RegNo"].DataType = typeof(String);
                foreach (DataRow row in stdinfo.Rows)
                {
                    dataTable.ImportRow(row);
                }
                Handler handler = new Handler();
                DataSet dataSet = handler.CreateDataSet();
                dataSet.Tables["StudentReport"].ReadXml(@"D:\StudentReport.xml");
                dataSet.Tables["StudentReport"].Merge(dataTable);
                dataSet.Tables["StudentReport"].WriteXml(@"D:\StudentReport.xml");

                var datasett = new DataSet();
                //dataSet.ReadXml(@"D:\StudentReport.xml");
                DataTable dataTable1 = dataSet.Tables["StudentReport"];
                grdStd.DataContext = dataTable1.DefaultView;
            }
            else
            {
                MessageBox.Show("File not found", "Alert");
            }

        }
        static DataTable DataTableFromCsv(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";

            string pathOnly =System.IO.Path.GetDirectoryName(path);
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

        

        private void txtContact_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtContact.Text))
            {
                MessageBox.Show("Input Only Number !");
            }
        }
    }
}
