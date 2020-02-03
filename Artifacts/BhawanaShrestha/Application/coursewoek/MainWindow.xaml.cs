using DataHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace coursewoek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable buffer;
        public MainWindow()
        {
            InitializeComponent();
            Startup();
        }

        public void Startup()
        {
            LoadStudentData();
        }

        private void AppendStdReport(DataSet dataSet)
        {
            dataSet = new DataSet();
            var handler = new Handler();
            dataSet.ReadXmlSchema(@"C:\\StudentCWSchema.xml");
            dataSet.ReadXml(@"C:\StudentCWData.xml");

            var studentTable = dataSet.Tables["Student"];

            var newRow = studentTable.NewRow();
            newRow["RegistrationNo"] = txtid.Text;
            newRow["Name"] = txtname.Text;
            newRow["Address"] = txtaddress.Text;
            newRow["ContactNo"] = txtcontact.Text;
            newRow["CourseEnroll"] = txtprogram.Text;
            newRow["RegistrationDate"] = txtreg.SelectedDate != null ? txtreg.SelectedDate.Value : DateTime.Today;
            studentTable.Rows.Add(newRow);

            dataSet.WriteXml(@"C:\StudentCWData.xml");
        }

        //private void write_to_file(string text)
        //{
        //    System.IO.File.WriteAllText(@"C:\count.txt", text);
        //}

        //private string read_from_file()
        //{

        //    string text = System.IO.File.ReadAllText(@"C:\count.txt");

        //    int i;

        //    i = int.Parse(text.ToString());
        //    i = i + 1;

        //    return i.ToString();
        //}

        private void LoadStudentData()
        {
            if (System.IO.File.Exists(@"C:\StudentCWData.xml"))
            {
                var dataSet = new DataSet();

                dataSet.ReadXmlSchema("C:\\StudentCWSchema.xml");

                dataSet.ReadXml(@"C:\StudentCWData.xml");


                if(dataSet.Tables.Contains("Student"))
                {
                    var dtStdReport = dataSet.Tables["Student"];
                    grid.ItemsSource = dtStdReport.DefaultView;
                }
                MessageBox.Show("Student Details retrieved from file");
            }
            else
                MessageBox.Show("Data Retrievel Unsucessful");
        }

        private void LoadDataforReport1()
        {
            {
                var handler = new Handler();
                var dataSet = new DataSet();

                dataSet.ReadXml(@"C:\StudentCWData.Xml");

                for (int i = 0; i <= dataSet.Tables["Student"].Rows.Count - 1; i++)
                {

                    if (dataSet.Tables["Student"].Rows[i]["CourseEnroll"].ToString() == "i")
                    {

                        var dr2 = dataSet.Tables["Student"].NewRow();
                        dr2["RegNo"] = txtid.Text;
                        dr2["Name"] = txtname.Text;
                        dr2["Address"] = txtaddress.Text;
                        dr2["ContactNo"] = txtcontact.Text;
                        dr2["CourseEnroll"] = txtprogram.Text;
                        dr2["RegistrationDate"] = txtreg.SelectedDate != null ? txtreg.SelectedDate.Value : DateTime.Today;
                        dataSet.Tables["Student"].Rows.Add(dr2);

                        dataSet.Tables["Student"].WriteXml(@"C:\StudentCWData.xml");
                    }
                }
            }
        }

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            DataSet dataSet = new DataSet();         
            AppendStdReport(dataSet);
            LoadStudentData();
            ClearText();
        }

        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            ClearText();
        }

        private void ClearText() {
            txtname.Text = "";
            txtaddress.Text = "";
            txtcontact.Text = "";
            txtid.Text = "";
            txtreg.Text = "";
        }

        public class Student
        {
            public string ID { get; set; }

            public string Name { get; set; }

            public string Address { get; set; }

            public string Email { get; set; }

            public string Contact { get; set; }

            public string Course { get; set; }

            public string Date { get; set; }
        }
        private void btnsortbyname_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXmlSchema(@"C:\\StudentCWSchema.xml");
            dataSet.ReadXml(@"C:\StudentCWData.xml");
            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[1];
            dataTable.DefaultView.Sort = "Name ASC";
            grid.DataContext = dataTable.DefaultView;
        }

        private void sortByDate()
        {
            string sampleXmlFile = @"E:\College\3rd Year\Application Development\StudentReport.xml"; //declaring sampleXmlFile to xml file destination
            DataSet dataset = new DataSet(); // createing new data set
            dataset.ReadXml(sampleXmlFile); // Reading the XML File

            buffer = new DataTable("dt"); //creating data table dt and assigning to buffer
            buffer.Columns.Add("ID", typeof(String));                   // Making new column ID with data type String 
            buffer.Columns.Add("Name", typeof(String));
            buffer.Columns.Add("Address", typeof(String));
            buffer.Columns.Add("ContactNo", typeof(String));
            buffer.Columns.Add("EmailAddress", typeof(String));
            buffer.Columns.Add("CourseEnroll", typeof(String));
            buffer.Columns.Add("Date", typeof(String));

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++) // Changing GMt format to local time zone
            {
                string s = dataset.Tables[0].Rows[i][6].ToString();
                DateTime dtime = DateTime.Parse(s);
                buffer.Rows.Add(
                    dataset.Tables[0].Rows[i][0].ToString(),
                    dataset.Tables[0].Rows[i][1].ToString(),
                    dataset.Tables[0].Rows[i][2].ToString(),
                    dataset.Tables[0].Rows[i][3].ToString(),
                    dataset.Tables[0].Rows[i][4].ToString(),
                    dataset.Tables[0].Rows[i][5].ToString(),
                    dtime.ToShortDateString());

            }
            DataView dataView = new DataView(buffer); // setting the itemsource to table
            grid.ItemsSource = dataView;
        }

        private void btnSortByDate_Click(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(buffer); // setting the itemsource to table
            dataView.Sort = "Date ASC";               // code responsible sorting in ascending order, In Date ASE, DATE should match your variable from handler class
            grid.ItemsSource = dataView;    // Displaying data 
        }
        private void btnreport_Click(object sender, RoutedEventArgs e)
        {
            LoadDataforReport1();
            WeeklyReport weeklyReport = new WeeklyReport();
            weeklyReport.Show();
        }
    }
}
