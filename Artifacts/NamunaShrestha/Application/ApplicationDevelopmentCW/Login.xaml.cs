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

namespace ApplicationDevelopmentCW
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
            if (txtUname.Text != "admin")
            {
                MessageBox.Show("Username is incorrect!", "Alert", MessageBoxButton.OK);
                txtUname.Clear();
            }
            else if (txtPw.Password != "admin")
            {
                MessageBox.Show("Password is incorrect!", "Alert", MessageBoxButton.OK);
                txtPw.Clear();
            }
            else
            {
                MessageBox.Show("Logged in Successfully !!!", "Success", MessageBoxButton.OK);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
        private void Btnlogincancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
