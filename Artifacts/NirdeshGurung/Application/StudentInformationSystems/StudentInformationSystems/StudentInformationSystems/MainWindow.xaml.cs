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
using System.IO;

namespace StudentInformationSystems
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

            tbRegNo.Text = read_from_file();
        }

        public void Startup()
        {

        }



        private void AddSampleDataforStd(DataSet dataSet)
        {

            var dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "BBA";
            dr["DisplayText"] = "BBA Hons";
            dataSet.Tables["Course"].Rows.Add(dr);

            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["Name"] = tbName.Text;
            dr1["Address"] = tbAddress.Text;
            dr1["EmailId"] = tbEmail.Text;
            dr1["ContactNo"] = tbContact.Text;
            dr1["CourseEnroll"] = cbProgramEnroll.Text;
            dr1["RegistrationDate"] = dpDateTime.SelectedDate;
            dataSet.Tables["Student"].Rows.Add(dr1);
        }

        private void AddofStdReport(DataSet dataSet)
        {

            var dr1 = dataSet.Tables["StudentReport"].NewRow();
            dataSet.Tables["StudentReport"].ReadXml(@"D:\StudentInformationSystem\StudentReport.xml");

            dr1["Name"] = tbName.Text;
            dr1["Address"] = tbAddress.Text;
            dr1["EmailId"] = tbEmail.Text;
            dr1["ContactNo"] = tbContact.Text;
            dr1["CourseEnroll"] = cbProgramEnroll.Text;
            dr1["RegistrationDate"] = dpDateTime.SelectedDate;
            dataSet.Tables["StudentReport"].Rows.Add(dr1);


        }

        private void AppendStdReport(DataSet dataSet)
        {
            if (File.Exists(@"D:\StudentInformationSystem\StudentReport.xml"))
            {
                var handler = new Handler();

                dataSet.Tables["StudentReport"].ReadXml(@"D:\StudentInformationSystem\StudentReport.xml");
                var dr2 = dataSet.Tables["StudentReport"].NewRow();
                dr2["RegNo"] = tbRegNo.Text;
                dr2["Name"] = tbName.Text;
                dr2["Address"] = tbAddress.Text;
                dr2["EmailId"] = tbEmail.Text;
                dr2["ContactNo"] = tbContact.Text;
                dr2["CourseEnroll"] = cbProgramEnroll.Text;
                dr2["RegistrationDate"] = dpDateTime.SelectedDate;

                dataSet.Tables["StudentReport"].Rows.Add(dr2);
                //dataSet.Tables["StudentReport"].WriteXml(@"C:\Informatics\Coursework\Application Development\StudentReport.xml");
            }
            else
            {
                dataSet.Tables["StudentReport"].WriteXml(@"D:\StudentInformationSystem\StudentReport.xml");
                AppendStdReport(dataSet);
            }



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            AddSampleDataforStd(dataSet);
            AppendStdReport(dataSet);

            var regno = tbRegNo.Text;
            var name = tbName.Text;

            dataSet.WriteXmlSchema(@"D:\StudentInformationSystem\StudentCWSchema1.xml");
            dataSet.Tables["Student"].WriteXml(@"D:\StudentInformationSystem\" + name + "CWData" + regno + ".xml");
            dataSet.Tables[2].WriteXml(@"D:\StudentInformationSystem\StudentReport.xml");

            write_to_file(tbRegNo.Text);

            tbRegNo.Text = read_from_file();

            ClearControls();

            MessageBox.Show("Successfully Added");
        }

        private void write_to_file(string text)
        {


            System.IO.File.WriteAllText(@"D:\StudentInformationSystem\count.txt", text);


        }
        private string read_from_file()
        {
            int i = 1;
            if (File.Exists(@"D:\StudentInformationSystem\count.txt"))
            {
                string text = File.ReadAllText(@"D:\StudentInformationSystem\count.txt");
                i = int.Parse(text.ToString());
                i = i + 1;
            }
            else
            {
                File.WriteAllText(@"D:\StudentInformationSystem\count.txt", "text");
            }
            return i.ToString();

        }

        private void ClearControls()
        {
            tbName.Text = "";
            tbAddress.Text = "";
            tbContact.Text = "";
            tbEmail.Text = "";
            cbProgramEnroll.Text = "";
        }

        private void tbRegNo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            tbRegNo.Text = "";
            tbName.Text = "";
            tbAddress.Text = "";
            tbContact.Text = "";
            tbEmail.Text = "";
            cbProgramEnroll.Text = "";

            MessageBox.Show("Cleared");

        }

        private void btnStudentDetails_Click(object sender, RoutedEventArgs e)
        {
            StudentDetailReport studentDetailReport = new StudentDetailReport();
            studentDetailReport.Show();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            Report report = new Report();
            report.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbProgramEnroll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
