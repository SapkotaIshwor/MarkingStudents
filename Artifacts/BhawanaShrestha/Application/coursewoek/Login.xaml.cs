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

namespace coursewoek
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

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtuname.Text != "admin")
            {
                MessageBox.Show("Username is incorrect!", "Alert", MessageBoxButton.OK);
                txtuname.Clear();

            }
            else if (txtpw.Password != "admin")
            {
                MessageBox.Show("Password is incorrect!", "Alert", MessageBoxButton.OK);
                txtpw.Clear();
            }
            else
            {
                MessageBox.Show("Logged in Successfully !!!", "Success", MessageBoxButton.OK);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }

        private void btnlogincancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
