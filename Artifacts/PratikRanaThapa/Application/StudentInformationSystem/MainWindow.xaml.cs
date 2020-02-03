using DataHandler;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Text.RegularExpressions;



namespace StudentInformationSystem
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

            LoadStudentData();

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
            var currentDirectory = System.AppContext.BaseDirectory;
            var dr1 = dataSet.Tables["StudentReport"].NewRow();
            dataSet.Tables["StudentReport"].ReadXml($@"{currentDirectory}\StudentReport.xml");

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

            var handler = new Handler();
            var currentDirectory = System.AppContext.BaseDirectory;

            dataSet.Tables["StudentReport"].ReadXml(@"StudentReport.xml");

            var dr2 = dataSet.Tables["StudentReport"].NewRow();
            dr2["RegNo"] = tbRegNo.Text;
            dr2["Name"] = tbName.Text;
            dr2["Address"] = tbAddress.Text;
            dr2["EmailId"] = tbEmail.Text;
            dr2["ContactNo"] = tbContact.Text;
            dr2["CourseEnroll"] = cbProgramEnroll.Text;
            dr2["RegistrationDate"] = dpDateTime.SelectedDate;
      
            dataSet.Tables["StudentReport"].Rows.Add(dr2);
            
            dataSet.Tables["StudentReport"].WriteXml(@"StudentReport.xml");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            errormessage.Text = "";


            if (tbRegNo.Text.Length == 0)
            {
                errormessage.Text = "Enter an Register Number.";

                tbRegNo.Focus();
            }
            else if (tbName.Text.Length == 0)
            {
                errormessage.Text = "Enter Student Name.";

                tbName.Focus();
            }
            else if (tbAddress.Text.Length == 0)
            {
                errormessage.Text = "Enter Student Address.";

                tbAddress.Focus();
            }
            else if (!Regex.IsMatch(tbEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter A Valid Student Email.";

                tbEmail.Focus();
            }

            else if (dpDateTime.SelectedDate == null) {
                errormessage.Text = "Enter Correct Date.";

                tbContact.Focus();
            }
            else if (tbContact.Text.Length == 0)
            {
                errormessage.Text = "Enter Student Contact.";

                tbContact.Focus();
            }
            else if (cbProgramEnroll.Text.Length == 0)
            {
                errormessage.Text = "Enter an Course To Enroll.";

                cbProgramEnroll.Focus();
            }
           
            else
            {

                var handler = new Handler();
                var dataSet = handler.CreateDataSet();
                AddSampleDataforStd(dataSet);
                AppendStdReport(dataSet);


               

                var regno = tbRegNo.Text;
                var name = tbName.Text;

                var currentDirectory = System.AppContext.BaseDirectory;
                dataSet.Tables["Student"].WriteXml($@"{currentDirectory}" + name + "CWData" + regno + ".xml");

                write_to_file(tbRegNo.Text);

                tbRegNo.Text = read_from_file();

                ClearControls();
                LoadStudentData();
                MessageBox.Show("Add Successfully");
            }
        }

        private void write_to_file(string text)
        {

            var currentDirectory = System.AppContext.BaseDirectory;
            System.IO.File.WriteAllText($@"{currentDirectory}\count.txt", text);


        }
        private string read_from_file()
        {
           
            var currentDirectory = System.AppContext.BaseDirectory;


            string text = System.IO.File.ReadAllText($@"{currentDirectory}\count.txt");

            int i;

            i = int.Parse(text.ToString());
            i = i + 1;

            return i.ToString();

        }

        private void ClearControls()
        {
            tbName.Text = "";
            tbAddress.Text = "";
            tbContact.Text = "";
            tbEmail.Text = "";
        }

        private void tbRegNo_TextChanged(object sender, TextChangedEventArgs e)
        {
       
        }

        private void LoadStudentData()
        {
            var currentDirectory = System.AppContext.BaseDirectory;
           
            if (System.IO.File.Exists($@"{currentDirectory}\StudentReport.xml"))
            {
                var handler = new Handler();

               
                var dataSet = new DataSet();

                dataSet.ReadXml(@"StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdStudent.DataContext = dtStdReport.DefaultView;
            }

        }
        private void LoadDataforReport1()
        {



        }

        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            tbName.Text = "";
            tbAddress.Text = "";
            tbContact.Text = "";
            tbEmail.Text = "";
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
    }
}
