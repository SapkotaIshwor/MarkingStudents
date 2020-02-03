using System;
using System.Data;
using System.IO;
using System.Windows;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for StudentAdd.xaml
    /// </summary>
    public partial class StudentAdd : Window
    {
        private string fileName = "D:\\StudentData.xml";
        public StudentAdd()
        {
            InitializeComponent();
            Startup();

            //txtRegNo.Text = read_from_file();

            LoadStudentData();
        }

        public void Startup()
        {
            if (!File.Exists(fileName))
            {
                var handler = new Handler();
                var dataSet = handler.CreateDataSet();
                AddSampleData(dataSet);
                dataSet.WriteXmlSchema(@"D:\StudentDataschema.xml");
                dataSet.WriteXml(@"D:\StudentData.xml");
            }
                
           
            //var dataSet = new DataSet();
            //dataSet.ReadXmlSchema(@"D:\StudentCWSchema.xml");
            //dataSet.ReadXml(@"D:\StudentCWData.xml");

            //var i = 0;
        }

        private void AddSampleData(DataSet dataSet)
        {

            var dr = dataSet.Tables["Student"].NewRow();
            dr["RegistrationNumber"] = "19030";
            dr["FirstName"] = "Ishwor";
            dr["LastName"] = "Magar";
            dr["Address"] = "Kathmandu";
            dr["ContactNo"] = "9851220847";
            dr["CourseEnroll"] = "Advanced Database";
            dr["RegistrationDate"] = DateTime.Today.AddDays(-3);
            dataSet.Tables["Student"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["RegistrationNumber"] = "19031";
            dr["FirstName"] = "Ujjal";
            dr["LastName"] = "Parajuli";
            dr["Address"] = "Kathmandu";
            dr["ContactNo"] = "9851220847";
            dr["CourseEnroll"] = "Application Development";
            dr["RegistrationDate"] = DateTime.Today.AddDays(-3);
            dataSet.Tables["Student"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["RegistrationNumber"] = "19034";
            dr["FirstName"] = "Bishal";
            dr["LastName"] = "Parajuli";
            dr["Address"] = "Pokhara";
            dr["ContactNo"] = "9851220847";
            dr["CourseEnroll"] = "Advanced database";
            dr["RegistrationDate"] = DateTime.Today.AddDays(-8);
            dataSet.Tables["Student"].Rows.Add(dr);

        }

        //private void AddSampleDataforStd(DataSet dataSet)
        //{

        //    var dr = dataSet.Tables["Course"].NewRow();
        //    dr["Name"] = "BBA";
        //    dr["DisplayText"] = "BBA Hons";
        //    dataSet.Tables["Course"].Rows.Add(dr);

        //    var dr1 = dataSet.Tables["Student"].NewRow();
        //    dr1["FirstName"] = txtFirst.Text;
        //    dr1["LastName"] = txtLast.Text;
        //    dr1["Address"] = txtAddress.Text;
        //    dr1["ContactNo"] = txtContact.Text;
        //    dr1["CourseEnroll"] = "Application development";
        //    dr1["RegistrationDate"] = DateTime.Today.AddDays(-2);
        //    dataSet.Tables["Student"].Rows.Add(dr1);


        //}

        private void AppendStdReport(DataSet dataSet)
        {
          
            //var handler = new Handler();
            dataSet.ReadXml(@"D:\StudentData.xml");

            var dr2 = dataSet.Tables["Student"].NewRow();
            dr2["RegistrationNumber"] = txtRegNo.Text;
            dr2["FirstName"] = txtFirst.Text;
            dr2["LastName"] = txtLast.Text;
            dr2["Address"] = txtAddress.Text;
            dr2["ContactNo"] = txtContact.Text;
            dr2["CourseEnroll"] = txtCombo.Text;
            dr2["RegistrationDate"] = txtRegistrationDt.SelectedDate;    //DateTime.Today.AddDays(-2);
            dataSet.Tables["Student"].Rows.Add(dr2);

            dataSet.Tables["Student"].WriteXml(@"D:\StudentData.xml");

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtFirst.Text == "" || txtLast.Text == "" || txtAddress.Text == "" || txtContact.Text == "" || txtRegistrationDt.Text=="" || txtCombo.Text == "")
            {
                MessageBox.Show("Fields should not be empty", "Warning");
                return;
            }
            else
            {
                var handler = new Handler();
                var dataSet = handler.CreateDataSet();
                //AddSampleDataforStd(dataSet);
                AppendStdReport(dataSet);

                //var regno = txtRegNo.Text;
                //var name = txtFirst.Text;
                //dataSet.WriteXmlSchema(@"D:\StudentCWSchema1.xml");
                //dataSet.Tables["Student"].WriteXml(@"D:\" + name + "Individual" + regno + ".xml");

                dataSet.Tables["Student"].WriteXml(@"D:\StudentData.xml");

                //write_to_file(txtRegNo.Text);

                //txtRegNo.Text = read_from_file();

                ClearControls();

                LoadStudentData();
            }   
        }

        //private void write_to_file(string text)
        //{


        //    System.IO.File.WriteAllText(@"D:\count.txt", text);


        //}
        //private string read_from_file()
        //{

        //    string text = System.IO.File.ReadAllText(@"D:\count.txt");

        //    int i;

        //    i = int.Parse(text.ToString());
        //    i = i + 1;

        //    return i.ToString();

        //}

        private void ClearControls()
        {
            txtRegNo.Text = "";
            txtFirst.Text = "";
            txtLast.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
        }

        private void LoadStudentData()
        {

            if (System.IO.File.Exists(@"D:\StudentData.xml"))
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(@"D:\StudentData.xml");
                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdStd.DataContext = dtStdReport.DefaultView;
            }

        }

        private void Btn_BackHome(object sender, RoutedEventArgs e)
        {
            HomePage hp = new HomePage();
            MessageBox.Show("Going Back To Home Page");
            this.Close();
            hp.Show();
        }

        private void Btn_Clear(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }

    }
}
