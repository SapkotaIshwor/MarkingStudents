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
using APPLICATION_DEVELOPMENT;

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

            txtRegisNo.Text = read_from_file();//Registered regisno. readedfrom the saved file.
           // txt_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");//Extractes the actual date.
           
        }

       public void Startup()
        {
            var i = 0;//Variables initialized to 0.
        } 
     

        private void AddSampleData(DataSet dataSet)
        {
            var dr = dataSet.Tables["Course"].NewRow();//Course table created.

            // Data extrated from the text Field//
            dr["Name"] = " txtName.Text";
            dr["Address"] = "txtAddress.Text";
            dr["ContactNo"] = " txtContact.Text ";
            dr["CourseEnroll"] = " txtCourseEnroll.Text ";
            dr["RegsitrationDate"] = txt_date.SelectedDate.Value.ToString("MM/dd/yyyy");
        } 
      
        private void AddofStdReport(DataSet dataSet)
        {

            var handler = new Handler();//New handler created for student report.
            dataSet.Tables["StudentReport"].ReadXml(@"F:\StudentReport.xml");//Data stored in student report is readed.

            var dr1 = dataSet.Tables["StudentReport"].NewRow();//New data row on the smae table is created.
            dr1["RegisNo"] = txtRegisNo.Text;
            dr1["Name"] = txtName.Text;
            dr1["Address"] = txtAddress.Text;
            dr1["ContactNo"] = txtContact.Text;
            dr1["CourseEnroll"] = txt_CourseEnroll.Text;
            dr1["RegistrationDate"] = txt_date.SelectedDate.Value.ToString("MM/dd/yyyy");
            dataSet.Tables["StudentReport"].Rows.Add(dr1);

            dataSet.Tables["StudentReport"].WriteXml(@"F:\StudentReport.xml");//All data added to the StudentReport through variable dr1.


        }
        private void AppendStdReport(DataSet dataSet)
        {
                var handler = new Handler();//New handler created for data to be appended on student report.

                dataSet.Tables["StudentReport"].ReadXml(@"D:\StudentReport.xml");
           
                var dr2 = dataSet.Tables["StudentReport"].NewRow();
                dr2["RegisNo"] = txtRegisNo.Text;
                dr2["Name"] = txtName.Text;
                dr2["Address"] = txtAddress.Text;
                dr2["ContactNo"] = txtContact.Text;
                dr2["CourseEnroll"] = txt_CourseEnroll.Text;
                dr2["RegsitrationDate"] = txt_date.SelectedDate.Value.ToString("MM/dd/yyyy");

            dataSet.Tables["StudentReport"].Rows.Add(dr2);
            dataSet.Tables["StudentReport"].WriteXml(@"F:\StudentReport.xml");//All data added to the StudentReport through variable dr2.

        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "")
            {
                String check1 = string.Empty;
                MessageBox.Show("ERROR!!! PLEASE, Fill UP REQUIRED DETAILS!!!");
                return;
            }
            else if (txtAddress.Text == "")
            {
                String check2 = string.Empty;
                MessageBox.Show("ERROR!!! PLEASE, Fill UP REQUIRED DETAILS!!!");
                return;
            }
            else if (txtContact.Text == "")
            {
                String check2 = string.Empty;
                MessageBox.Show("ERROR!!!PLEASE, Fill UP REQUIRED DETAILS!!!");
                return;
            }
            else if (txt_CourseEnroll.Text == "")
            {
                String check2 = string.Empty;
                MessageBox.Show("ERROR!!!PLEASE, Fill UP REQUIRED DETAILS!!!");
                return;
            }
            


            var handler = new Handler();
            var dataSet = handler.CreateDataSet();

            AddofStdReport(dataSet);


            var regno = txtRegisNo.Text;
            var name = txtName.Text;
           
            dataSet.Tables["Student"].WriteXml(@"F:\files\"+name+""+regno+".xml");


            write_to_file(txtRegisNo.Text);

            txtRegisNo.Text = read_from_file();  


            ClearControls();
            MessageBox.Show("Student details is Stored!!");

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void write_to_file(string text)
        { 
            System.IO.File.WriteAllText(@"F:\count.txt", text);
        }
        private string read_from_file()
        {

            string text = System.IO.File.ReadAllText(@"F:\count.txt");

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
            //txt_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

      
        private void LoadDataforReport1()
        {
            var handler = new Handler();
            var dataSet = new DataSet();

            var dr2 = dataSet.Tables["WeeklyReport"].NewRow();
            dr2["RegisNo"] = txtRegisNo.Text;
            dr2["Name"] = txtName.Text;
            dr2["Address"] = txtAddress.Text;
            dr2["ContactNo"] = txtContact.Text;
            dr2["CourseEnroll"] = txt_CourseEnroll.Text;
            dr2["RegsitrationDate"] = txt_date.SelectedDate.Value.ToString("MM/dd/yyyy");
            dataSet.Tables["StudentReport"].Rows.Add(dr2);//All data added to the student through variable dr2.
        }

        private void Retrieve_Button(object sender, RoutedEventArgs e)
        {
            RetriveWindow Ret = new RetriveWindow();
            Ret.Show();
            Close();
            MessageBox.Show("Student details is retrived");

        }

        private void txt_CourseEnroll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
