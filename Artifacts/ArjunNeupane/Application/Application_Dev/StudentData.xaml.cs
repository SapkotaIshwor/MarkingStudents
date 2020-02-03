using DataHandler;
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
using System.Windows.Shapes;


namespace Application_Dev
{
    /// <summary>
    /// Interaction logic for StudentData.xaml
    /// </summary>
    public partial class StudentData : Window
    {
        public StudentData()
        {
            InitializeComponent();
        }
 
        private void AddSampleDataforStd(DataSet dataSet)
        {

            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["RegistrationNo"] = registration.Text;
            dr1["FirstName"] = fname.Text;
            dr1["LastName"] = lname.Text;
            dr1["Address"] = address.Text;
            dr1["ContactNo"] = contact.Text;
            dr1["Email"] = email.Text;
            dr1["CourseEnroll"] = program.Text;
            dr1["RegistrationDate"] = DateTime.Now;
            dataSet.Tables["Student"].Rows.Add(dr1);


        }

        private void addStudent_Click(object sender, RoutedEventArgs e)
        {

            string xmlPath = System.IO.Path.Combine(Environment.CurrentDirectory, "studentCWData.xml");
            string schemaPath = System.IO.Path.Combine(Environment.CurrentDirectory, "StudentCWSchema.xml");


            var handler = new Handler();
            var dataSet = handler.CreateDataSet();

            AddSampleDataforStd(dataSet);


            if (ValidateInputs())
            {
                if (File.Exists(xmlPath))
                {
                    dataSet.ReadXml(xmlPath);
                    dataSet.WriteXml(xmlPath);
                    dataSet.WriteXmlSchema(schemaPath);

                    MessageBox.Show("Enrolled Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearText();

                }
                else
                {
                    dataSet.WriteXml(xmlPath);
                    dataSet.WriteXmlSchema(schemaPath);
                    MessageBox.Show("Enrolled Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearText();
                }

            }

        }

        public void clearText()
        {
            registration.Text = "";
            fname.Text = "";
            lname.Text = "";
            address.Text = "";
            contact.Text = "";
            email.Text = "";

        }


        public Boolean ValidateInputs()
        {
            if (registration.Text.Equals(""))
            {
                MessageBox.Show("Registration No cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (fname.Text.Equals(""))
            {
                MessageBox.Show("First Name cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (lname.Text.Equals(""))
            {
                MessageBox.Show("Last Name cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (address.Text.Equals(""))
            {
                MessageBox.Show("Address cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (contact.Text.Equals(""))
            {
                MessageBox.Show("Contact Number cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (email.Text.Equals(""))
            {
                MessageBox.Show("Email cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;

            }
            return true;
        }

        private void bthome(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
    }
}
