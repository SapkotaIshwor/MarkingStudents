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
            for (int i = 0; i < 100; i++)
            {
                registrationNo.Text = $"17031{i}";
            }
        }

        
        private void cancel_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
            RegisterMainWindow RmWindow = new RegisterMainWindow();
            RmWindow.Show();
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

    
      

 
        private void FacultyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
         
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

                    MessageBox.Show("E-mail address format is not correct.", "incorrect format");

                    mail_id.Focus();

                }
                //register student only if email format is correct
                else
                {
                    if (valid == true)
                    {
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
           

            departmentBox.Items.DeferRefresh();
        }


        //loading courses on dropdown list
      

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

        private void departmentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
