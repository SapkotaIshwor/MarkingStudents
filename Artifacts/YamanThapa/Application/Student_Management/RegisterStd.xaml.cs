using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for RegisterStd.xaml
    /// </summary>
    public partial class RegisterStd : Window
    {
        public RegisterStd()
        {
            InitializeComponent();
        }

        private void levelBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProgramBox.Items.Clear();
            ProgramBox.Items.Add("Click View Button");
            ProgramBox.SelectedItem = "Click View Button";

        }




        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            fname.Clear();
            lname.Clear();
            std_id.Clear();
            phone.Clear();
            p_phone.Clear();
            email_id.Clear();
            P_name.Clear();
            
            ProgramBox.Items.Refresh();
        }

     

     

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            baseWndo basewndo = new baseWndo();
            basewndo.Show();
        }

 

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            fileWriter();

          
        }
        public void fileWriter()
        {

            string valid = validator();
            //call file writer
            if (valid == "valid")
            {
                xmlWriter();
                fname.Clear();
                lname.Clear();
                std_id.Clear();
                phone.Clear();
                p_phone.Clear();
                email_id.Clear();
                P_name.Clear();
                address.Clear();
                ProgramBox.Items.Refresh();
            }
           
        }
        public void xmlWriter()
        {

            var handler = new Handler();
            var dataSet = handler.GenerateDataSet();

            dataSet = new DataSet();
            if (File.Exists(@"D:\StudentData.xml"))
            {

                dataSet.ReadXml(@"D:\StudentData.xml");
                AddStudentInfo(dataSet);
                dataSet.WriteXmlSchema(@"D:\StudentSchema.xml");
                dataSet.WriteXml(@"D:\StudentData.xml");
                MessageBox.Show("Successfully Registered","Success",MessageBoxButton.OK,MessageBoxImage.Information);
                
            }
            else
            {
                handler = new Handler();
                dataSet = handler.GenerateDataSet();
                AddStudentInfo(dataSet);
                dataSet.WriteXmlSchema(@"D:\StudentSchema.xml");
                dataSet.WriteXml(@"D:\StudentData.xml");

                MessageBox.Show("Successfully Registered", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


            }




        }

        private void AddStudentInfo(DataSet dataSet)
        {

            var dr = dataSet.Tables["StudentInfo"].NewRow();
            dr["StudentID"] = std_id.Text;
            dr["Name"] = fname.Text + lname.Text;
            dr["ParentName"] = P_name.Text; 
            dr["ParentPhone"] = p_phone.Text;
            dr["StudentPhone"] = phone.Text; 
            dr["Email"] = email_id.Text; 
            dr["Program"] = ProgramBox.Text;
            dr["Address"] = address.Text; 
            dr["Gender"] = genderBox.Text;
            dr["RegistrationDate"] = DateTime.Today;
            dataSet.Tables["StudentInfo"].Rows.Add(dr);
          
        }


    
    public string validator()
        {
            string b;
            //empty input validation
            if (fname.Text == "")
            {
                MessageBox.Show("Empty Firstname!");
                b = "Invalid";
                return b;
            }
            else if (lname.Text == "")
            {
                MessageBox.Show("Lastname is required");
                b = "Invalid";
                return b;
            }

             bool isnumber = Int32.TryParse(std_id.Text, out int j);

             if (isnumber == false)
             {
                 MessageBox.Show("ID must be integer");
                b = "Invalid";
                return b;
            }


            else if (std_id.Text == "")
            {
                MessageBox.Show("Empty ID!");
                b = "Invalid";
                return b;
            }
            else if (phone.Text == "")
            {
                MessageBox.Show("Empty Contact Number!");
                b = "Invalid";
                return b;
            }
            else if (email_id.Text == "")
            {
                MessageBox.Show("Empty email id!");
                b = "Invalid";
                return b;
            }
         
         
        
      
            else if (email_id.Text.Trim() != string.Empty)
            {
                Regex mRegxExpression;              

                    mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                    if (!mRegxExpression.IsMatch(email_id.Text.Trim()))
                    {
                        MessageBox.Show("E-mail format is not correct.");
                        email_id.Focus();
                    b = "Invalid";
                return b;
                     }
                else
                {
                    b = "valid";
                    return b;
                }
                
            }

            else
            {
                b = "valid";
                return b;
            }


        }

    
    }
}
