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
using AppDevCoursewrk;

namespace AppDevCoursewrk
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void Btnlogin_Click(object sender, RoutedEventArgs e)
        {


            var user = txtuser.Text;
            var pass = txtpass.Password;
            if (user.Equals("") || pass.Equals(""))
            {
                MessageBox.Show("Empty value", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (user != "Admin" || pass != "Admin")
            {
                MessageBox.Show("Username or Password Mismatch", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtuser.Clear();
                txtpass.Clear();
            }
            else
            {
                MessageBox.Show("Successfully Login", "Login Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }
}
