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
using Microsoft.Win32;
using System.IO;

namespace ADCourseWork
{
    /// <summary>
    /// Interaction logic for StudentDetail.xaml
    /// </summary>
    public partial class StudentDetail : Page
    {
        public StudentDetail()
        {
            InitializeComponent();
            Startup();

            txtRegNo.Text = read_from_file();

            LoadStudentData();
        }
        public string gender = "Male";
        private string fileName;


        public void Startup()
        {
           
        }

        private void AddSampleData(DataSet dataSet)
        {

            var dr = dataSet.Tables["Course"].NewRow();

            dataSet.Tables["Student"].Rows.Add(dr);

        }

        private void AddSampleDataforStd(DataSet dataSet)
        {

            //var dr = dataSet.Tables["Course"].NewRow();
            //dataSet.Tables["Course"].Rows.Add(dr);

            //var dr1 = dataSet.Tables["Student"].NewRow();
            //dr1["Name"] = txtName.Text;
            //dr1["Address"] = txtAddress.Text;
            //dr1["ContactNo"] = txtContact.Text;

            //dr1["CourseEnroll"] = CourseEnroll.Text;
            //dr1["RegistrationDate"] = datePicker.Text;
            //dataSet.Tables["Student"].Rows.Add(dr1);


        }

        private void AppendStdReport(DataSet dataSet)
        {

            var handler = new Handler();

            dataSet.Tables["StudentReport"].ReadXml(@"file\StudentReport.xml");

            var dr2 = dataSet.Tables["StudentReport"].NewRow();
            dr2["RegNo"] = txtRegNo.Text;
            dr2["Name"] = txtName.Text;
            dr2["Address"] = txtAddress.Text;
            dr2["ContactNo"] = txtContact.Text;
            dr2["Gender"] =gender;
            dr2["CourseEnroll"] = CourseEnroll.Text;
            dr2["RegistrationDate"] = datePicker.Text;
            
            dataSet.Tables["StudentReport"].Rows.Add(dr2);
            dataSet.Tables["StudentReport"].WriteXml(@"file\StudentReport.xml");



        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            AddSampleDataforStd(dataSet);
            AppendStdReport(dataSet);

            var regno = txtRegNo.Text;
            var name = txtName.Text;
            
            dataSet.Tables["Student"].WriteXml(@"Indivisual Student Data\" + name + "CWData" + regno + ".xml");

            

            write_to_file(txtRegNo.Text);

            txtRegNo.Text = read_from_file();

            ClearControls();
            LoadStudentData();
        }

        private void write_to_file(string text)
        {


            System.IO.File.WriteAllText(@"file\count.txt", text);


        }
        private string read_from_file()
        {

            string text = System.IO.File.ReadAllText(@"file\count.txt");

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

            if (System.IO.File.Exists(@"file\StudentReport.xml"))
            {
                var dataSet = new DataSet();

                dataSet.ReadXml(@"file\StudentReport.xml");

                DataTable dtStdReport = dataSet.Tables[0];
                grdStd.DataContext = dtStdReport.DefaultView;
            }

        }




        private void ClearControls(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login());
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new WeeklyStudentReport());
           
        }

        private void grdStd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortBy_Name(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"file\StudentReport.xml"))
            {


                var dataSet = new DataSet();

                dataSet.ReadXml(@"file\StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                dtStdReport.DefaultView.Sort = "Name";
                grdStd.DataContext = dtStdReport.DefaultView;
            }
        }

        private void SortBy_Date(object sender, RoutedEventArgs e)
        {

            if (System.IO.File.Exists(@"file\StudentReport.xml"))
            {


                var dataSet = new DataSet();

                dataSet.ReadXml(@"file\StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                dtStdReport.DefaultView.Sort = "RegistrationDate";
                grdStd.DataContext = dtStdReport.DefaultView;
            }
        }

        private void btnMale(object sender, RoutedEventArgs e)
        {
            this.gender = "Male";

          
        }

        private void btnFemale(object sender, RoutedEventArgs e)
        {
            this.gender = "Female";
        }

        private void GoToGraph(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Chart());
        }

        private void ImportToCSV(object sender, RoutedEventArgs e)
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
                            MessageBox.Show("Fill the mandetory field!!");
                        }
                    }
                    grdStd.ItemsSource = dataSet.Tables["Student"].DefaultView;
                    MessageBox.Show("Fill the mandetory field!!");
                }
            }
            catch (Exception)
            {
            }
        }
    }
 }
