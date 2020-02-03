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
using System.Data;

namespace CourseWorkSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Startup();

            //txtRegNo.Text = read_from_file();

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

            var i = 0;
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
            dr1["CourseEnroll"] = 1;
            dr1["RegistrationDate"] = DateTime.Today.AddDays(-2);
            dataSet.Tables["Student"].Rows.Add(dr1);


        }

        private void AppendStdReport(DataSet dataSet)
        {

            var handler = new Handler();

            //dataSet.Tables["StudentReport"].ReadXml(@"E:\APPXML\StudentReport.xml");

            var dr2 = dataSet.Tables["StudentReport"].NewRow();
            dr2["RegNo"] = txtName.Text;
            dr2["Name"] = txtName.Text;
            dr2["Address"] = txtAddress.Text;
            dr2["ContactNo"] = txtContact.Text;
            dr2["CourseEnroll"] = 1;
            dr2["RegistrationDate"] = DateTime.Today.AddDays(-2);
            dataSet.Tables["StudentReport"].Rows.Add(dr2);

            dataSet.Tables["StudentReport"].WriteXml(@"E:\APPXML\StudentReport.xml");

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
            dataSet.Tables["Student"].WriteXml(@"E:\APPXML\" + name + "CWData" + regno + ".xml");

            //dataSet.Tables[2].WriteXml(@"D:\StudentReport.xml");

            write_to_file(txtRegNo.Text);

            //txtRegNo.Text = read_from_file();

            ClearControls();
            LoadStudentData();
        }

        private void write_to_file(string text)
        {


            System.IO.File.WriteAllText(@"E:\APPXML\count.txt", text);


        }
        /*private string read_from_file()
        {

            string text = System.IO.File.ReadAllText(@"E:\APPXML\count.txt");

            int i;

            i = int.Parse(text.ToString());
            i = i + 1;

            return i.ToString();

        }*/

        private void ClearControls()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
        }

        private void LoadStudentData()
        {

            if (System.IO.File.Exists(@"E:\APPXML\StudentReport.xml"))
            {
                var handler = new Handler();


                var dataSet = new DataSet();

                dataSet.ReadXml(@"E:\APPXML\StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdStd.DataContext = dtStdReport.DefaultView;
            }

        }

        private void LoadDataforReport1()
        { 


        
        }

    }
}
