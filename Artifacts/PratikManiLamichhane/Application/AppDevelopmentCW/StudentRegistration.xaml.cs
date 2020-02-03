using DataHandler;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace AppDevelopmentCW
{
    /// <summary>
    /// Interaction logic for StudentRegistration.xaml
    /// </summary>
    public partial class StudentRegistration : Page
    {
        public StudentRegistration()
        {
            InitializeComponent();

            txtRegNo.Text = read_from_file();
            txtRegDate.Text = DateTime.Today.ToShortDateString();

            LoadStudentData();
            //LoadCourseData();
        }

        public string gender = "Male";

        List<string> courseList = new List<string>();
        private string fileName;

        private void SaveStudentData(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(txtName.Text) && !String.IsNullOrEmpty(txtContact.Text) && !String.IsNullOrEmpty(txtContact.Text))
            {
                var handler = new Handler();
                var dataSet = handler.CreateDataSet();
                AddDataforStd(dataSet);
                AppendStdReport(dataSet);

                var regno = txtRegNo.Text;
                var name = txtName.Text.ToUpper();
                dataSet.Tables["Student"].WriteXml(@"Files/Student data/CWData" + name + "" + regno + ".xml");

                write_to_file(txtRegNo.Text);

                txtRegNo.Text = read_from_file();

                ClearControls();
                LoadStudentData();
            }
            else
            {
                MessageBox.Show("Fill the mandetory field!!");
            }
        }

        private void AddDataforStd(DataSet dataSet)
        {

            var dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "BBA";
            dr["DisplayText"] = "BBA Hons";
            dataSet.Tables["Course"].Rows.Add(dr);

            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["Name"] = txtName.Text;
            dr1["Address"] = txtAddress.Text;
            dr1["ContactNo"] = txtContact.Text;
            dr1["Gender"] = gender;
            dr1["DOB"] = txtDOB.Text;
            dr1["CourseEnrol"] = txtCourseEnrol.Text;
            dr1["RegistrationDate"] = txtRegDate.SelectedDate;
            dataSet.Tables["Student"].Rows.Add(dr1);


        }

        private void AppendStdReport(DataSet dataSet)
        {

            var handler = new Handler();
            if (System.IO.File.Exists(@"Files/StudentReport.xml"))
            {
                dataSet.Tables["StudentReport"].ReadXml(@"Files/StudentReport.xml");
            }

            var dr2 = dataSet.Tables["StudentReport"].NewRow();
            dr2["RegNo"] = txtRegNo.Text;
            dr2["Name"] = txtName.Text;
            dr2["Address"] = txtAddress.Text;
            dr2["ContactNo"] = txtContact.Text;
            dr2["Gender"] = gender;
            dr2["DOB"] = txtDOB.Text;
            dr2["CourseEnrol"] = txtCourseEnrol.Text;
            dr2["RegistrationDate"] = txtRegDate.SelectedDate;
            dataSet.Tables["StudentReport"].Rows.Add(dr2);

            dataSet.Tables["StudentReport"].WriteXml(@"Files/StudentReport.xml");
        }

        private void write_to_file(string text)
        {
            System.IO.File.WriteAllText(@"Files/count.txt", text);

        }
        private string read_from_file()
        {

            string text = System.IO.File.ReadAllText(@"Files/count.txt");

            int i;

            i = int.Parse(text.ToString());
            i = i + 1;

            return i.ToString();

        }

        public void ClearControls()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtDOB.Text = "";
            // txtCourseEnrol.ClearValue();

        }

        private void LoadStudentData()
        {

            if (System.IO.File.Exists(@"Files/StudentReport.xml"))
            {
                var handler = new Handler();
                var dataSet = new DataSet();

                dataSet.ReadXml(@"Files/StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdStd.DataContext = dtStdReport.DefaultView;
            }

        }

       
        private void LoadCourseData()
        {
            var handler = new Handler();
            var dataSet = new DataSet();

            var abc = dataSet.ReadXml(@"Files/AllCourses.Xml");
            for (int i = 0; i <= dataSet.Tables["AllCourses"].Rows.Count - 1; i++)
            {
                var dr2 = dataSet.Tables["AllCourses"].NewRow();
                courseList.Add(dr2["Name"].ToString());
                // Console.WriteLine(courseList);

            }
           // lvDataBinding.ItemsSource = abc.ToString();
        }


        private void BackToHomePage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WelcomePage());

        }

        private void GoToGraph(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new pieChart());
        }


        private void RadioButton_MaleChecked(object sender, RoutedEventArgs e)
        {
            this.gender = (string)(sender as RadioButton).Content;
        }

        private void RadioButton_FemaleChecked_1(object sender, RoutedEventArgs e)
        {
            this.gender = (string)(sender as RadioButton).Content;
        }

        private void RadioButton_OthersChecked(object sender, RoutedEventArgs e)
        {
            this.gender = (string)(sender as RadioButton).Content;
        }

        private void ClearField(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtDOB.SelectedDate =null;
            txtCourseEnrol.SelectedValue = null;
            
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"Files/StudentReport.xml"))
            {
                var dataSet = new DataSet();

                dataSet.ReadXml(@"Files/StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                dtStdReport.DefaultView.Sort = "Name";
                grdStd.DataContext = dtStdReport.DefaultView;
            }
        }

        private void SortByDate(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"Files/StudentReport.xml"))
            {
                var dataSet = new DataSet();

                dataSet.ReadXml(@"Files/StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                dtStdReport.DefaultView.Sort = "RegistrationDate";
                grdStd.DataContext = dtStdReport.DefaultView;
            }
        }

        private void ShowStdWeeklyReport(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WeeklyStudentReport());
        }

        private void TxtName_Error(object sender, ValidationErrorEventArgs e)
        {

        }
        

        private void ImportCVCfile(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml((@"Files/StudentReport.xml"));
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
                            dr1["CourseEnrol"] = values[5];
                            dr1["RegistrationDate"] = values[6];
                            dr1["Gender"] = values[7];
                            dr1["DOB"] = values[8];
                            dataSet.Tables["Student"].Rows.Add(dr1);
                            dataSet.WriteXml(@"Files/StudentReport.xml");
                        }
                    }
                    grdStd.ItemsSource = dataSet.Tables["Student"].DefaultView;
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error \n some thing is wrong in the code");
            }
        }
    }
}
