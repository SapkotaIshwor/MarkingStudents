using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Application_Development_CW1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static bool isLoggedIn = false;

        public Login()
        {
            InitializeComponent();
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            tbox_username.Clear();
            tbox_password.Clear();
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            if (tbox_username.Text.Trim() == "" && tbox_password.Text.Trim() == "")
            {
                MessageBox.Show("Please enter username & password.");
            }
            else{
                if (tbox_username.Text == "admin" && tbox_password.Text == "admin")
                {
                    Login.isLoggedIn = true;

                    MessageBox.Show("Your are successfully logged in.");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else {
                    MessageBox.Show("Username & Password is incorrect.");
                }

            }
        }
    }
}
