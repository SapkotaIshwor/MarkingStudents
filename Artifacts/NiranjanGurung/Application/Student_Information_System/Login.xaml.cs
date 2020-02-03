using System;
using System.Collections.Generic;
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

namespace Student_Information_System
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

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string Username = txtUsername.Text;
            string Password = txtPassword.Password;

            if (Username == "")
            {
                MessageBox.Show("Username is Empty!", "Error");
            }
            else if (Password == "")
            {
                MessageBox.Show("Password is Empty", "Error");
            }
            else if (Password == "admin" && Username == "admin")
            {
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }

            else
            {
                MessageBox.Show("Invalid Username and Password! Please Try Again", "Error");
            }
        }

        private void BtnExitLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Want to exit the system ?");
            this.Close();
        }
    }
}
