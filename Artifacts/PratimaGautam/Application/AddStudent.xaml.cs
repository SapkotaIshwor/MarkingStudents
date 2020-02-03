using System;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        string CurrentPath = AppDomain.CurrentDomain.BaseDirectory;

        public AddStudent()
        {
            InitializeComponent();
            txtRegDate.Text = DateTime.Today.ToString();
            txtRegID.Text = RandomString(6, false);
        }

        private void BtnEnroll(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Program Enroll cannot be Empty so value set to default index.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                comboBox.SelectedIndex = 0;
            }
            var handler = new DataHandler();
            var dataSet = handler.CreateDataSet();
            AddSampleData(dataSet);

            if (ValidateInputs())
            {
                if (File.Exists(@CurrentPath + "\\StudentCWData.xml"))
                {
                    dataSet = new DataSet();
                    dataSet.ReadXmlSchema(@CurrentPath + "\\StudentCWSchema.xml");
                    dataSet.ReadXml(@CurrentPath + "\\StudentCWData.xml");
                    AddSampleData(dataSet);
                    dataSet.WriteXml(@CurrentPath + "\\StudentCWData.xml"); 
                }
                else
                {
                    if (!File.Exists(@CurrentPath + "\\StudentCWSchema.xml"))
                    {
                        dataSet.WriteXmlSchema(@CurrentPath + "\\StudentCWSchema.xml");
                    }
                    dataSet.WriteXml(@CurrentPath + "\\StudentCWData.xml");
                }

                MessageBox.Show("Student Enrolled Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearControls();
            }
            txtRegID.Text = RandomString(6, false);
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private void ClearControls()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            comboBox.Text = "";
        }

        private void AddSampleData(DataSet dataSet)
        {
            var dr = dataSet.Tables["Student"].NewRow();
            dr["RegID"] = txtRegID.Text;
            dr["FirstName"] = txtFirstName.Text;
            dr["LastName"] = txtLastName.Text;
            dr["Address"] = txtAddress.Text;
            dr["ContactNo"] = txtContactNo.Text;
            dr["CourseEnroll"] = comboBox.SelectedValue.ToString();
            //dr["RegistrationDate"] = DateTime.Today.AddDays(-2);
            dr["RegistrationDate"] = DateTime.Today;
            dataSet.Tables["Student"].Rows.Add(dr);
        }

        public bool ValidateInputs()
        {
            if (txtFirstName.Text.Equals(""))
            {
                MessageBox.Show("First Name cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (txtLastName.Text.Equals(""))
            {
                MessageBox.Show("Last Name cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (txtAddress.Text.Equals(""))
            {
                MessageBox.Show("Address cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (txtContactNo.Text.Equals(""))
            {
                MessageBox.Show("Enter a Valid phone number (Max 10 digit)", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();            
            mainWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
