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

namespace StudentInformationSystems
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
        private void LoginDetail()
        {
            string user = tbUsername.Text;
            string pass = pbPassword.Password;

            if (user == "admin" && pass == "admin@123")
            {
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                ErrorMessage();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginDetail();
        }

        private void ErrorMessage()
        {
            MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            tbUsername.Text = "";
            pbPassword.Password = "";

        }
    }
}
