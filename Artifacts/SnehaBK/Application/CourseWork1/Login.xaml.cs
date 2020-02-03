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

namespace CourseWork1
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

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            var user = txtName.Text;
            var pass = txtPassword.Password;
            if (user.Equals("") || pass.Equals(""))
            {
                MessageBox.Show("You can't pass empty value", "Login Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (user != "admin" || pass != "admin")
            {
                MessageBox.Show("Username or passwoard didn't match!", "Login Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
                txtName.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("Login Successful", "Login success",
                MessageBoxButton.OK, MessageBoxImage.Information);
                var StudentDetailForm = new StudentDetailForm();
                StudentDetailForm.Show();
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
                Close();
           }
    }
}
