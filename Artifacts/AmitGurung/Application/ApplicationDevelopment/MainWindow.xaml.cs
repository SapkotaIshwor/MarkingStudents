using DataHandler;
using System.Windows;
using System.Data;
using System.IO;

namespace ApplicationDevelopment
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            txtResNo.Text = Res_no_read();
            
        }

        private void AddStudentData(DataSet dataSet)
        {
            var dr_Std = dataSet.Tables["Student"].NewRow();
            dr_Std["Name"] = txtName.Text;
            dr_Std["Address"] = txtAddr.Text;
            dr_Std["ContactNo"] = txtContact.Text;
            dr_Std["Email"] = txtEmail.Text;
            dr_Std["CourseEnroll"] = comboProgram.Text;
            dr_Std["RegistrationDate"] = Date_Pick.SelectedDate.Value.ToString("yyyy/MM/dd");
            dataSet.Tables["Student"].Rows.Add(dr_Std);

        }

        private void AppendStudentData(DataSet dataSet)
        {
            if (File.Exists("Student Report/StudentReport.xml"))
            {
                dataSet.Tables["StudentReport"].ReadXml("Student Report/StudentReport.xml");

                var dr_Std = dataSet.Tables["StudentReport"].NewRow();
                dr_Std["RegistrationNo"] = txtResNo.Text;
                dr_Std["Name"] = txtName.Text;
                dr_Std["Address"] = txtAddr.Text;
                dr_Std["ContactNo"] = txtContact.Text;
                dr_Std["Email"] = txtEmail.Text;
                dr_Std["CourseEnroll"] = comboProgram.Text;
                dr_Std["RegistrationDate"] = Date_Pick.SelectedDate.Value.ToString("yyyy/MM/dd"); 
                dataSet.Tables["StudentReport"].Rows.Add(dr_Std);

                dataSet.Tables["StudentReport"].WriteXml("Student Report/StudentReport.xml");
            }
            else
            {
                dataSet.Tables["StudentReport"].WriteXml("Student Report/StudentReport.xml");
                AppendStudentData(dataSet);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Fill your Name.");
            }
            else if (txtAddr.Text == "")
            {
                MessageBox.Show("Please Fill your Address.");
            }
            else if (txtContact.Text == "")
            {
                MessageBox.Show("Please Fill your contact.");
            }
            else if (IsValidEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Please Fill Email correctly.");
            }
            else if (Date_Pick.SelectedDate == null)
            {
                MessageBox.Show("Please Select a date.");
            }
            else if (comboProgram.SelectedItem == null)
            {
                MessageBox.Show("Please Select a course.");
            }
            else
            {
                
                var handler = new Handler();
                var dataSet = handler.CreateDataSet();
                AddStudentData(dataSet);
                AppendStudentData(dataSet);

                dataSet.Tables["Student"].WriteXml("Individual Data/" + txtName.Text + "-Data-" + txtResNo.Text + ".xml");
                Res_no_write(txtResNo.Text);
                txtResNo.Text = Res_no_read();

                MessageBox.Show("Sudent Details Saved!");

                Clear_field();
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear_field();
        }
        public void Clear_field()
        {
            txtName.Text = "";
            txtAddr.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            comboProgram.Text = "";
            Date_Pick.Text = "";
        }

        private void Res_no_write(string text)
        {
            File.WriteAllText("Res Count/count_res.txt", text);
        }

        private string Res_no_read()
        {
            int i = 100000;
            if (File.Exists("Res Count/count_res.txt"))
            {
                string text = File.ReadAllText("Res Count/count_res.txt");
                i = int.Parse(text.ToString());
                i += 1;
            }
            else
            {
                File.WriteAllText("Res Count/count_res.txt", "100000");
            }
            
            return i.ToString();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            StudentList studentList = new StudentList();
            studentList.Show();
            Close();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var eAdd = new System.Net.Mail.MailAddress(email);
                return eAdd.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
