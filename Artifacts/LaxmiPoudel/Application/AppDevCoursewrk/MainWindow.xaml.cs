using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using CourseWorkOne;
using DataHandler;
using Microsoft.Win32;

namespace AppDevCoursewrk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataTable buffer;
       

        public MainWindow()
        {
            InitializeComponent();
            Startup();

            txtRegNo.Text = read_from_file();

            LoadStudentData();


        }

        public void Startup()
        {
            //var handler = new Handler();
            //var dataSet = handler.CreateDataSet();
            //AddSampleData(dataSet);
            //dataSet.WriteXmlSchema(@"D:\StudentCWSchema.xml");
            //dataSet.WriteXml(@"D:\StudentCWData.xml");

            //var dataSet = new DataSet();
            //dataSet.ReadXmlSchema(@"D:\StudentCWSchema.xml");
            //dataSet.ReadXml(@"D:\StudentCWData.xml");

            //var i = 0;
        }

        private void AddSampleData(DataSet dataSet)
        {

            var dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "BBA";
            dr["DisplayText"] = "BBA Hons";
            dataSet.Tables["Course"].Rows.Add(dr);

            dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "Network & Communication";
            dr["DisplayText"] = "BCA Network";
            dataSet.Tables["Course"].Rows.Add(dr);

            dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "Programming & Application Development";
            dr["DisplayText"] = "BSc CSIT Application Development";
            dataSet.Tables["Course"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = "Ishwor Sapkota";
            dr["Address"] = "Kathmandu";
            dr["ContactNo"] = "9851220845";
            dr["CourseEnroll"] = 1;
            dr["RegistrationDate"] = DateTime.Today.AddDays(-2);
            dataSet.Tables["Student"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = "Samyam Sapkota";
            dr["Address"] = "Kathmandu";
            dr["ContactNo"] = "9851220846";
            dr["CourseEnroll"] = 2;
            dr["RegistrationDate"] = DateTime.Today.AddDays(-1);
            dataSet.Tables["Student"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = "Safal Sapkota";
            dr["Address"] = "Kathmandu";
            dr["ContactNo"] = "9851220847";
            dr["CourseEnroll"] = 3;
            dr["RegistrationDate"] = DateTime.Today.AddDays(-3);
            dataSet.Tables["Student"].Rows.Add(dr);

        }

        private void AddSampleDataforStd(DataSet dataSet)
        {

            var dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "BBA";
            dr["DisplayText"] = "BBA Hons";
            dataSet.Tables["Course"].Rows.Add(dr);

            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["Name"] = txtName.Text;
            dr1["Address"] = txtAddress.Text;
            dr1["ContactNo"] = txtContact.Text;
            dr1["ProgramEnroll"] = combo.Text;
            dr1["RegistrationDate"] = DateTime.Today.AddDays(-2);
            dataSet.Tables["Student"].Rows.Add(dr1);


        }

        private void AppendStdReport(DataSet dataSet)
        {
            if (File.Exists(@"C:\Appxml\StudentReport.xml"))
            {
                var handler = new Handler();

                dataSet.Tables["StudentReport"].ReadXml(@"C:\Appxml\StudentReport.xml");

                var dr2 = dataSet.Tables["StudentReport"].NewRow();
                dr2["RegNo"] = txtRegNo.Text;
                dr2["Name"] = txtName.Text;
                dr2["Address"] = txtAddress.Text;
                dr2["ContactNo"] = txtContact.Text;
                dr2["ProgramEnroll"] = combo.Text;
                dr2["RegistrationDate"] = txtdate.Text;
                dataSet.Tables["StudentReport"].Rows.Add(dr2);

                dataSet.Tables["StudentReport"].WriteXml(@"C:\Appxml\StudentReport.xml");
               

            }
            else
            {
                dataSet.Tables["StudentReport"].WriteXml(@"C:\Appxml\StudentReport.xml");
                AppendStdReport(dataSet);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            AddSampleDataforStd(dataSet);
            MessageBox.Show("Successfully Inserted Data", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            AppendStdReport(dataSet);

            var regno = txtRegNo.Text;
            var name = txtName.Text;
            dataSet.WriteXmlSchema(@"C:\Appxml\StudentCWSchema1.xml");
            dataSet.Tables["Student"].WriteXml(@"E:\APPXML\" + name + "CWData" + regno + ".xml");

            dataSet.Tables[2].WriteXml(@"C:\Appxml\StudentReport.xml");

            write_to_file(txtRegNo.Text);

            txtRegNo.Text = read_from_file();

            ClearControls();
            LoadStudentData();
        }

        private void write_to_file(string text)
        {


            File.WriteAllText(@"C:\Appxml\count.txt", text);


        }
        private string read_from_file()
        {
            /*
            string text = System.IO.File.ReadAllText(@"C:\Appxml storage\count.txt");
            int i;
            i = int.Parse(text.ToString());
            i = i + 1;
            return i.ToString();*/
            int i = 1;
            if (File.Exists(@"C:\Appxml\count.txt"))
            {
                string text = File.ReadAllText(@"C:\Appxml\count.txt");
                i = int.Parse(text.ToString());
                i = i + 1;
            }
            else
            {
                //File.WriteAllText(@"E:\APPXML\count.txt", "text");
            }
            return i.ToString();

        }

        private void ClearControls()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
        }

        private void LoadStudentData()
        {

            if (System.IO.File.Exists(@"C:\Appxml\StudentReport.xml"))
            {
                var handler = new Handler();


                var dataSet = new DataSet();

                dataSet.ReadXml(@"C:\Appxml\StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdStd.DataContext = dtStdReport.DefaultView;
            }


        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"C:\Appxml\StudentReport.xml");
            DataTable dtStdReport = dataSet.Tables[0];

            int total_BIT = 0;
            int total_BBA = 0;

            DataTable dt = new DataTable("newTable");
            dt.Columns.Add("ProgramEnroll", typeof(string));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                string col = dtStdReport.Rows[i]["ProgramEnroll"].ToString();
                if (col == "BIT")
                {
                    total_BIT++;
                }
                else if (col == "BBA")
                {
                    total_BBA++;
                }

            }
            dt.Rows.Add("BBA", total_BBA);
            dt.Rows.Add("BIT", total_BIT);
            grdreport.DataContext = dt.DefaultView;


        }


        private void Srtname_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"C:\Appxml\StudentReport.xml");
            DataTable DataTable = dataSet.Tables["StudentReport"];
            DataTable.DefaultView.Sort = "Name Asc";
            grdStd.DataContext = DataTable.DefaultView;
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"C:\Appxml\StudentReport.xml");
            DataTable DataTable = dataSet.Tables["StudentReport"];
            DataTable.DefaultView.Sort = "RegistrationDate Asc";
            grdStd.DataContext = DataTable.DefaultView;
        }
        private void DataShow()
        {
            string dataXMLFile = @"C:\Appxml\StudentReport.xml";
            System.Data.DataSet dataset = new DataSet();
            dataset.ReadXml(dataXMLFile);

            buffer = new DataTable("dt");
            buffer.Columns.Add("RegNo", typeof(string));
            buffer.Columns.Add("Name", typeof(string));
            buffer.Columns.Add("Address", typeof(string));
            buffer.Columns.Add("ContactNo", typeof(string));
            buffer.Columns.Add("ProgramEnroll", typeof(string));
            buffer.Columns.Add("RegistrationDate", typeof(string));

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                string s = dataset.Tables[0].Rows[i][5].ToString();
                DateTime dtime = DateTime.Parse(s);
                buffer.Rows.Add(
                    dataset.Tables[0].Rows[i][0].ToString(),
                    dataset.Tables[0].Rows[i][1].ToString(),
                    dataset.Tables[0].Rows[i][2].ToString(),
                    dataset.Tables[0].Rows[i][3].ToString(),
                    dataset.Tables[0].Rows[i][4].ToString(),
                    dtime.ToShortDateString());
            }
            DataView dataView = new DataView(buffer);
            grdreport.ItemsSource = dataView;
        }


        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            var import = new OpenCsv();
            import.Show();




        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            var chart = new Chart();
            chart.Show();
        }
    }

        
    }

