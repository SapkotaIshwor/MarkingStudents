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

namespace StudentManagementSystem2._0 {
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window {
        public Login() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            if (txtbxUsername.Text != "admin") // checks if the username isn't matching the required username
            {
                MessageBox.Show("Username is incorrect!", "Alert");
                txtbxUsername.Clear();
            }
            else if (txtbxPassword.Password != "admin") // checks if the password isn't matching the required password
            {
                MessageBox.Show("Password is incorrect", "Alert");
                txtbxPassword.Clear();
            }
            else // if username and password are matched MainWindow is opened
            {
                
                MainWindow hm = new MainWindow();
                hm.Show();
                this.Close(); // after loggin in it temrinates the login window

            }

        }


        private void txtbxUsername_TextChanged_1(object sender, TextChangedEventArgs e) {

        }

     
        private void Button_Click(object sender, RoutedEventArgs e) {
            System.Windows.Application.Current.Shutdown();  // on hitting cancel button the system is terminated
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }
}
