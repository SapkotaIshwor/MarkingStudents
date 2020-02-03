    using System;
using System.Collections.Generic;
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

namespace Student_info
{
    /// <summary>
    /// Interaction logic for Register_student.xaml
    /// </summary>
    public partial class Register_student : Window
    {
        string sex = "";
        public Register_student()
        {
            InitializeComponent();
          
        }

        
        private void cancel_btn(object sender, RoutedEventArgs e)
        {
         
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure wanna cancel process?", "Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Close();
                RegisterMainWindow RmWindow = new RegisterMainWindow();
                RmWindow.Show();
            }
            else
            {
                //
            }
        }
        

        private void clear_btn(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure wanna clear all fields?", "Reset Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {       
                       clear_text();
            }
            else
            {
                //
            }
        }

    
        private void departmentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            facultyBox.Items.Clear();
            facultyBox.Items.Add("Click Load button");
            facultyBox.SelectedItem = "Click Load button";

            programBox.Items.Clear();
            programBox.Items.Add("Click Load button");
            programBox.SelectedItem = "Click Load button";

        }



 
        private void FacultyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
         
        }

        private void faculty_load_Click(object sender, RoutedEventArgs e)
        {
                facultyBox.Items.Clear();

                if (departmentBox.Text == "")
                {
                    facultyBox.Items.Add("Select department first");
                    facultyBox.SelectedItem = ("Select department first");
                }


                else if (departmentBox.Text == "IT")
                {
                    facultyBox.Items.Add("BIT");
                    facultyBox.Items.Add("BSCIT");
                }

                else if (departmentBox.Text == "Education")
                {
                    facultyBox.Items.Add("Literature");
                    facultyBox.Items.Add("Teaching");
                }

                else if (departmentBox.Text == "Management")
                {
                    facultyBox.Items.Add("BBA");
                    facultyBox.Items.Add("BBS");
                }
            
        }


        private void program_load_Click(object sender, RoutedEventArgs e)
        {
                        dropdown_loader();
        }

 
        //validating student phone 
        private void phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool valid = int_validator(phone.Text);

            if (valid == false)
            {
                System.Windows.MessageBox.Show("Number can't be String", "Invalid", System.Windows.MessageBoxButton.OK,MessageBoxImage.Information);
                phone.Clear();
            }
            

        }
   
       //validating student id
        private void student_id_TextChanged(object sender, TextChangedEventArgs e)
        {

            bool valid = int_validator(student_id.Text);


            if (valid == false)
            {
                student_id.Clear();
                MessageBox.Show("ID can't be String","Invalid",System.Windows.MessageBoxButton.OK, MessageBoxImage.Information);

            }
          
        }


        // register new student
        private void register_btn(object sender, RoutedEventArgs e)
        {

            bool valid = validator();
            

            //validating email format
            Regex mRegxExpression;

            if (mail_id.Text.Trim() != string.Empty)

            {

                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(mail_id.Text.Trim()))

                {
                    System.Windows.MessageBox.Show("E-mail address format is not correct.", "incorrect format", System.Windows.MessageBoxButton.OK, MessageBoxImage.Warning);
                    mail_id.Focus();

                }
                //register student only if email format is correct
                else
                {
                    if (valid == true)
                    {
                        passValue();
                    }
                }

            }


        }

        //getting gender 

        private void maleRdb_Checked(object sender, RoutedEventArgs e)
        {
            sex = "Male";
        }

        private void femaleRdb_Checked(object sender, RoutedEventArgs e)
        {
            sex = "Female";

        }

        private void otherRdb_Checked(object sender, RoutedEventArgs e)
        {
            sex = "Other";
        }
        //clearing inputed text in all text fields
        private void clear_text()
        {
            first_name.Clear();
            last_name.Clear();
            student_id.Clear();
            phone.Clear();
            mail_id.Clear();
            tmp_address.Clear();
            permanent_address.Clear();
            religion.Clear();
            nationality.Clear();


            departmentBox.Items.DeferRefresh();
        }


        //loading courses on dropdown list
        private void dropdown_loader()
        {
            programBox.Items.Clear();

            if (facultyBox.Text == "")
            {
                programBox.Items.Add("Select faculty first");
                programBox.SelectedItem = ("Select faculty first");
            }
            else if (facultyBox.Text == "Select department first" || facultyBox.Text == "Click Load button")
            {
                programBox.Items.Add("Select faculty first");
                programBox.SelectedItem = ("Select faculty first");
            }

            else if (facultyBox.Text == "BIT")
            {
                programBox.Items.Add("Computing");
                programBox.Items.Add("Multimedia Technologies ");
                programBox.Items.Add("Networks and IT Security ");
            }
            else if (facultyBox.Text == "CSIT")
            {
                programBox.Items.Add("csit course 1");
                programBox.Items.Add("csit course 2");
                programBox.Items.Add("csit course 3");
            }

            else if (facultyBox.Text == "Literature")
            {
                programBox.Items.Add("Literature course 1");
                programBox.Items.Add("Literature course 2");
                programBox.Items.Add("Literature course 3");
            }

            else if (facultyBox.Text == "Teaching")
            {
                programBox.Items.Add("Teaching course 1");
                programBox.Items.Add("Teaching course 2");
                programBox.Items.Add("Teaching course 3");
            }

            else if (facultyBox.Text == "BBA")
            {
                programBox.Items.Add("BBA course 1");
                programBox.Items.Add("BBA course 2");
                programBox.Items.Add("BBA course 3");
            }

            else if (facultyBox.Text == "BBS")
            {
                programBox.Items.Add("BBS course 1");
                programBox.Items.Add("BBS course 2");
                programBox.Items.Add("BBS course 3");
            }

        }


        //validating all the empty required text box
        public bool validator()
        {
            //empty input validation
            if (first_name.Text == "")
            {
                MessageBox.Show("Firstname is required", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (last_name.Text == "")
            {
                MessageBox.Show("Lastname is required", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (student_id.Text == "")
            {
                MessageBox.Show("student_id is required", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (phone.Text == "")
            {
                MessageBox.Show("Phone is required", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (phone.Text.Length <5)
            {
                MessageBox.Show("Contact number can't be too short", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }

            else if (mail_id.Text == "")
            {
                MessageBox.Show("Mail-id is required", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (sex == "")
            {
                MessageBox.Show("Gender is required", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (tmp_address.Text == "" || permanent_address.Text == "")
            {
                MessageBox.Show("Address is required", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (departmentBox.Text == "")
            {
                MessageBox.Show("Select one Department ");
                return false;

            }
            else if (facultyBox.Text == "" || facultyBox.Text == "Click Load button" || facultyBox.Text == "Select department first")
            {
                MessageBox.Show("Select one Faculty", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (programBox.Text == "" || programBox.Text == "Click Load button" || programBox.Text == "Select faculty first")
            {
                MessageBox.Show("Select one Program", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else
            {
                return true;
            }


        }

        //validating whether a number is integer or not
        public bool int_validator(string num)
        {
            bool isnumber = Int32.TryParse(num, out int j);

            if (isnumber == false)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        public void passValue()
        {
            
            string Fname = first_name.Text;
            string Lname = last_name.Text;
            int Id = Convert.ToInt32(student_id.Text);
            string Department = departmentBox.Text;
            string Faculty = facultyBox.Text;
            string Program = programBox.Text;
            int Phone = Convert.ToInt32(phone.Text);
            string Email = mail_id.Text;
            string Gender = sex;
            string currentAddr = tmp_address.Text;
            string permanentAddr = permanent_address.Text;
            string Religion = religion.Text;
            string Nationality = nationality.Text;
            string MarritalStatus = marritalStatus.Text;

            this.Hide();
            Register_confirm register_Confirm = new Register_confirm(Fname, Lname, Id, Department, Faculty, Program, Phone, Email, Gender, currentAddr, permanentAddr, Religion, Nationality, MarritalStatus);
            register_Confirm.Show();

        }

        private void first_name_TextChanged(object sender, TextChangedEventArgs e)
        {

            bool valid = int_validator(first_name.Text);


            if (valid == true)
            {
                first_name.Clear();
                MessageBox.Show("Name can't be Number", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void last_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool valid = int_validator(last_name.Text);


            if (valid == true)
            {
                last_name.Clear();
                MessageBox.Show("Name can't be Number", "Invalid", System.Windows.MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}
