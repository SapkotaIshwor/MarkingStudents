using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            errormessage.Text = "";
            string user = tbUsername.Text;
            string pass = pbPassword.Password;
            if (tbUsername.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";

                tbUsername.Focus();
            }

            else if (pbPassword.Password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                pbPassword.Focus();
                }
                else if (!Regex.IsMatch(tbUsername.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                
            }
            else {
                if (user == "admin@gmail.com" && pass == "admin")
                {
                    errormessage.Text = "You have Logged successfully.";

                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else if (user != "admin@gmail.com" && pass != "admin")
                {
                    errormessage.Text = "Either Email Or PassWord Is Wrong";
                }
                else if ((user == "admin@gmail.com" && pass != "admin"))
                {
                    errormessage.Text = "PassWord Is Incorrect";
                }
                else {
                    errormessage.Text = "Email Or Pass Is Incorrect";
                }
            }
        }
    }
}
