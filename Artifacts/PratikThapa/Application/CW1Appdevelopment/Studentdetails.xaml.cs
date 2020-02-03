using DataHandler;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CW1Appdevelopment
{
    /// <summary>
    /// Interaction logic for Studentdetails.xaml
    /// </summary>
    public partial class Studentdetails : Page
    {
        public Studentdetails()
        {
            InitializeComponent();
            txtRegNo.Text = read_from_file();
            LoadStudentData();
        }
        List<string> courseList = new List<string>();
        private string fileName;
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


        private void AddSampleDataforStd(DataSet dataSet)
        {

            var dr = dataSet.Tables["Course"].NewRow();

            dataSet.Tables["Course"].Rows.Add(dr);

            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["Name"] = txtName.Text;
            dr1["Address"] = txtAddress.Text;
            dr1["ContactNo"] = txtContact.Text;
            dr1["CourseEnroll"] = courseEnroll.Text;
            dr1["RegistrationDate"] = datePicker.Text;
            dataSet.Tables["Student"].Rows.Add(dr1);


        }

        private void AppendStdReport(DataSet dataSet)
        {

            var handler = new Handler();
            dataSet.Tables["StudentReport"].ReadXml(@"files\StudentReport.xml");

            var dr2 = dataSet.Tables["StudentReport"].NewRow();
            dr2["RegNo"] = txtRegNo.Text;
            dr2["Name"] = txtName.Text;
            dr2["Address"] = txtAddress.Text;
            dr2["ContactNo"] = txtContact.Text;
            dr2["CourseEnroll"] = courseEnroll.Text;
            dr2["RegistrationDate"] = datePicker.Text;
            dataSet.Tables["StudentReport"].Rows.Add(dr2);

            dataSet.Tables["StudentReport"].WriteXml(@"files\StudentReport.xml");

        }
        private void Save(object sender, RoutedEventArgs e)
        {

            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            AddSampleDataforStd(dataSet);
            AppendStdReport(dataSet);

            var regno = txtRegNo.Text;
            var name = txtName.Text;
            //dataSet.WriteXmlSchema(@"files\StudentCWSchema1.xml");
            dataSet.Tables["Student"].WriteXml(@"files\" + name + "CWData" + regno + ".xml");

            //dataSet.Tables[2].WriteXml(@"files\StudentReport.xml");

            write_to_file(txtRegNo.Text);

            txtRegNo.Text = read_from_file();

            ClearControls();
            LoadStudentData();
        }

        public void Clear(object sender, EventArgs e)
        {

            txtName.Clear();
            txtAddress.Clear();
            txtContact.Clear();


        }

        private void write_to_file(string text)
        {

            System.IO.File.WriteAllText(@"files\count.txt", text);

        }
        private string read_from_file()
        {
            string text = System.IO.File.ReadAllText(@"files\count.txt");

            int i;

            i = int.Parse(text.ToString());
            i = i + 1;

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
            if (System.IO.File.Exists(@"files\StudentReport.xml"))
            {
                var handler = new Handler();

                var dataSet = new DataSet();


                dataSet.ReadXml(@"files\StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdStd.DataContext = dtStdReport.DefaultView;

            }
        }

        



        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Homepage());
        }


        private void Weeklyreport_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Weeklyreport());
        }

        private void sortbyname(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"files\StudentReport.xml"))
            {


                var dataSet = new DataSet();

                dataSet.ReadXml(@"files\StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                dtStdReport.DefaultView.Sort = "Name";
                grdStd.DataContext = dtStdReport.DefaultView;
            }
        }

        private void sortbydate(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"files\StudentReport.xml"))
            {


                var dataSet = new DataSet();

                dataSet.ReadXml(@"files\StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                dtStdReport.DefaultView.Sort = "RegistrationDate";
                grdStd.DataContext = dtStdReport.DefaultView;
            }
        }

        private void Chart(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Chart());
        }

        

        private void Import(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml((@"files/StudentReport.xml"));
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Filter = "CSV Files|*.csv";
                openfile.DefaultExt = ".csv";
                openfile.FilterIndex = 1;
                openfile.Multiselect = false;
                bool? fileselect = openfile.ShowDialog();
                if (fileselect != null || fileselect == true)
                {
                    fileName = openfile.FileName;

                    using (var reader = new StreamReader(fileName))
                    {
                        reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            var dr1 = dataSet.Tables["StudentReport"].NewRow();
                            dr1["RegNo"] = values[1];
                            dr1["Name"] = values[2];
                            dr1["Address"] = values[3];
                            dr1["ContactNo"] = values[4];
                            dr1["Gender"] = values[5];
                            dr1["CourseEnroll"] = values[6];
                            dr1["RegistrationDate"] = values[7];

                            dataSet.Tables["Student"].Rows.Add(dr1);
                            dataSet.WriteXml(@"files/StudentReport.xml");
                            MessageBox.Show("Fill the field!!");
                        }
                    }
                    grdStd.ItemsSource = dataSet.Tables["Student"].DefaultView;
                    MessageBox.Show("Fill the field!!");
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
