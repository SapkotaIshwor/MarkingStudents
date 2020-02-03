using DataHandler;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ApplicationDevelopmentCW
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

            txtRegNo.Text = read_from_file();
            //LoadStudentData();


        }

        public void Startup()
        {
            var i = 0;
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
            dr1["CourseEnroll"] = comboBoxCourse.Text;
            //dr1["RegistrationDate"] = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            dr1["RegistrationDate"] = datePick.SelectedDate.Value.ToString("yyyy/MM/dd");
            dataSet.Tables["Student"].Rows.Add(dr1);

        }

        private void AppendStdReport(DataSet dataSet)
        {

            var handler = new Handler();

            
            dataSet.Tables["StudentReport"].ReadXml(@"Files\\StudentReport.xml");

            var dr2 = dataSet.Tables["StudentReport"].NewRow();
            dr2["RegNo"] = txtRegNo.Text;
            dr2["Name"] = txtName.Text;
            dr2["Address"] = txtAddress.Text;
            dr2["ContactNo"] = txtContact.Text;
            dr2["CourseEnroll"] = comboBoxCourse.Text;
            //dr2["RegistrationDate"] = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            dr2["RegistrationDate"] = datePick.SelectedDate.Value.ToString("yyyy/MM/dd");
            dataSet.Tables["StudentReport"].Rows.Add(dr2);

            
            dataSet.Tables["StudentReport"].WriteXml(@"Files\\StudentReport.xml");
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

            String reg = txtRegNo.Text;
            String fullname = txtName.Text;
            String address = txtAddress.Text;
            String contact = txtContact.Text;
            String course = comboBoxCourse.Text;
            //String date = datePick.SelectedDate.Value.ToString("yyyy/MM/dd");


            if (reg != "" && fullname != "" && address != "" && contact != "" && course != "")
            {
                grdStd.IsReadOnly = true;

                var handler = new Handler();
                var dataSet = handler.CreateDataSet();
                AddSampleDataforStd(dataSet);
                AppendStdReport(dataSet);

                var regno = txtRegNo.Text;
                var name = txtName.Text;


                dataSet.Tables["Student"].WriteXml(@"Files\\IndividualStudentRecords\\" + name + "CWData" + regno + ".xml");
               

                write_to_file(txtRegNo.Text);

                txtRegNo.Text = read_from_file();


                MessageBox.Show("Student Details saved to file", "Alert");


                ClearControls();
                
            }
            else
            {
                MessageBox.Show("Required Fields Missing", "Alert");
            }
        }

        private void write_to_file(string text)
        {


            
            System.IO.File.WriteAllText(@"Files\\count.txt", text);


        }
        public void sortbyName()
        {

        }

        private string read_from_file()
        {

            
            string text = System.IO.File.ReadAllText(@"Files\\count.txt");

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

            
            if (System.IO.File.Exists(@"Files\\StudentReport.xml"))
            {
                var handler = new Handler();

                var dataSet = new DataSet();

                
                dataSet.ReadXml(@"Files\\StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdStd.DataContext = dtStdReport.DefaultView;

                
            }
            else
                MessageBox.Show("Data Retrievel Unsucessful", "Alert");

        }



        private void Button_Click_Retrieve(object sender, RoutedEventArgs e)
        {
            ClearControls();
            LoadStudentData();
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Radio_Button_NameSorting_Checked(object sender, RoutedEventArgs e)
        {

            var handler = new Handler();

            var dataSet = new DataSet();

            
            dataSet.ReadXml(@"Files\\StudentReport.xml");

            DataTable dtStdReport = new DataTable();
            dtStdReport = dataSet.Tables[0];
            dtStdReport.DefaultView.Sort = "Name ASC";
            grdStd.DataContext = dtStdReport.DefaultView;

        }

        private void Radio_Button_DateSorting_Checked(object sender, RoutedEventArgs e)
        {

            var handler = new Handler();

            var dataSet = new DataSet();

            
            dataSet.ReadXml(@"Files\\StudentReport.xml");

            DataTable dtStdReport = new DataTable();
            dtStdReport = dataSet.Tables[0];
            dtStdReport.DefaultView.Sort = "RegistrationDate ASC";
            grdStd.DataContext = dtStdReport.DefaultView;

        }



        private void Button_Click_Enroll_Report(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();

            
            dataSet.ReadXml(@"Files\\StudentReport.xml");

            DataTable dtStdReport = dataSet.Tables[0];

            int total_BIT = 0;
            int total_BBA = 0;

            DataTable dt = new DataTable("newTable");
            dt.Columns.Add("Course Enroll", typeof(String));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                String col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
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

            grdReport1.DataContext = dt.DefaultView;
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            ImportFile showWindow = new ImportFile();
            showWindow.Show();
            this.Close();
        }

        private void Button_Click_Chart(object sender, RoutedEventArgs e)
        {
            Window1 showWindow = new Window1();
            showWindow.Show();
        }
    }

}
