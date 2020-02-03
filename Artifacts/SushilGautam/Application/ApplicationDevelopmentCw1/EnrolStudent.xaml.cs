using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace ApplicationDevelopmentCw1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\StudentRecords.xml";
        private string CurrentSchemaPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\StudentRecordsSchema.xml";
        bool validEmail;
        

        public MainWindow()
        {
          
            InitializeComponent();
            enrolDate.Text = DateTime.Now.ToString();
            registrationNo.Text = CreateStudentId().ToString();
            
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                var dataHandler = new DataHandler();
                var dataSet = dataHandler.CreateDataSet();
                AddSampleData(dataSet);

                if (File.Exists(CurrentPath) && File.Exists(CurrentSchemaPath))
                {
                    dataSet.ReadXmlSchema(CurrentSchemaPath);
                    dataSet.ReadXml(CurrentPath);
                    dataSet.WriteXmlSchema(CurrentSchemaPath);
                    dataSet.WriteXml(CurrentPath);
                    MessageBox.Show("Enrolled Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearText();

                }
                else
                {
                    dataSet.WriteXmlSchema(CurrentSchemaPath);
                    dataSet.WriteXml(CurrentPath);
                    MessageBox.Show("Enrolled Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearText();
                }
               
            }
        }
        private void AddSampleData(DataSet dataSet)
        {
            var dr = dataSet.Tables["Student"].NewRow();
            dr["Id"] = Int32.Parse(registrationNo.Text);
            dr["FirstName"] = firstName.Text;
            dr["LastName"] = lastName.Text;
            dr["Gender"] = genderCombo.Text;
            dr["ContactNumber"] = contactNo.Text;
            dr["Email"] = email.Text;
            dr["CourseEnroll"] = courseEnrol.Text;
            dr["Zone"] = zone.Text;
            dr["District"] = district.Text;
            dr["RegistrationDate"] = DateTime.Now.ToString();
            dataSet.Tables["Student"].Rows.Add(dr);

        }
        public void clearText()
        {
            registrationNo.Text = "";
            firstName.Text = "";
            lastName.Text = "";
            email.Text = "";
            contactNo.Text = "";
            zone.Text = "";
            district.Text = "";

        }
        public Boolean ValidateInputs()
        {
            
            if (firstName.Text.Equals(""))
            {
                MessageBox.Show("First Name cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (lastName.Text.Equals(""))
            {
                MessageBox.Show("Last Name cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (email.Text.Equals(""))
            {
                MessageBox.Show("Email cannot be empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!validEmail)
            {
                MessageBox.Show("Email not valid", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (district.Text.Equals(""))
            {
                MessageBox.Show("District cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (zone.Text.Equals(""))
            {
                MessageBox.Show("Zone cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else  if (contactNo.Text.Equals(""))
            {
                MessageBox.Show("Contact Number cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }
       
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            clearText();
        }
        public string CreateStudentId()
        {
            var bytes = new byte[4];
            var randomNumber = RandomNumberGenerator.Create();
            randomNumber.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }
        private bool emailValidation(string email)
        {

            return new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", RegexOptions.IgnoreCase).IsMatch(email);
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            validEmail = emailValidation(email.Text);
        }
    }
}
