using System;
using System.Windows;
using System.Data;
using DataHandler;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

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


            txtRegNo.Text = read_from_file();



        }


        private void AddSampleDataforStd(DataSet dataSet)
        {



            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["Name"] = txtName.Text;
            dr1["Address"] = txtAddress.Text;
            dr1["ContactNo"] = txtContact.Text;
            dr1["CourseEnroll"] = comboBox.Text;
            dr1["RegistrationDate"] = DateTime.Today.AddDays(-2);
            dataSet.Tables["Student"].Rows.Add(dr1);


        }

        private void AppendStdReport(DataSet dataSet)
        {

            var handler = new Handler();

            if (File.Exists(@"D:\StudentReport.xml"))
            {



                dataSet.Tables["StudentReport"].ReadXml(@"D:\StudentReport.xml");

                var dr2 = dataSet.Tables["StudentReport"].NewRow();
                dr2["RegNo"] = txtRegNo.Text;
                dr2["Name"] = txtName.Text;
                dr2["Address"] = txtAddress.Text;
                dr2["ContactNo"] = txtContact.Text;
                dr2["CourseEnroll"] = comboBox.Text;
                dr2["Email"] = txt_email.Text;
                DateTime? selectedDate = dateselect.SelectedDate;
                if (selectedDate.HasValue)
                {
                    string date = selectedDate.Value.ToString("dd/MM/yyyy");
                    dr2["RegistrationDate"] = date;
                }
                dataSet.Tables["StudentReport"].Rows.Add(dr2);
            }
            else
            {

                dataSet.Tables["StudentReport"].WriteXml(@"D:\StudentReport.xml");
                AppendStdReport(dataSet);
            }
        }

       
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             if (txtName.Text == "")
            {
                string myStringVariable1 = string.Empty;
                MessageBox.Show("All Field is requierd");
                return;
               
            }
            else if (txtContact.Text == "")
            {
                string myStringVariable2 = string.Empty;
                MessageBox.Show("Contact Number is requierd");
                return;

            }
            else if (txt_email.Text == "")
            {
                string myStringVariable2 = string.Empty;
                MessageBox.Show("Email Address is requierd");
                return;

                
            }
            else if (txtAddress.Text == "")
            {
                string myStringVariable2 = string.Empty;
                MessageBox.Show("Address is requierd");
                return;

               
            }


            else if (comboBox.Text == "--Choose--")
            {
                string myStringVariable3 = string.Empty;
                MessageBox.Show("Select Corse Enroll");
                return;

            }
            else if (!this.txt_email.Text.Contains('@') || !this.txt_email.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email Input someone@someting.com", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

                
            }

            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            AddSampleDataforStd(dataSet);
            AppendStdReport(dataSet);

            var regno = txtRegNo.Text;
            var name = txtName.Text;
            //dataSet.WriteXmlSchema(@"D:\StudentCWSchema1.xml");
            dataSet.Tables["StudentReport"].WriteXml(@"D:\" + name + "CWData" + regno + ".xml");

            dataSet.Tables[2].WriteXml(@"D:\StudentReport.xml");

            write_to_file(txtRegNo.Text);

            txtRegNo.Text = read_from_file();

            ClearControls();
            

            MessageBox.Show("Submit Sucessfully");

        }

        private void write_to_file(string text)
        {


            System.IO.File.WriteAllText(@"D:\count.txt", text);


        }
        private string read_from_file()
        {
            int i = 0001;
            if (File.Exists(@"D:\StudentReport.xml"))
            {

                string text = System.IO.File.ReadAllText(@"D:\count.txt");
                i = int.Parse(text.ToString());
                i = i + 1;
            }
            else
            {
                System.IO.File.WriteAllText(@"D:\count.txt", "23000");
            }

            return i.ToString();

        }

        private void ClearControls()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txt_email.Text = "";




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StudentDetails studentDetails = new StudentDetails();
            studentDetails.Show();


        }

        private void txtName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(txtName.Text))
            {
                MessageBox.Show("Invalid Input !");
            }
        }

        private void txtContact_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtContact.Text))
            {
                MessageBox.Show("Input Only Number !");
            }
        }

       
    }

}
