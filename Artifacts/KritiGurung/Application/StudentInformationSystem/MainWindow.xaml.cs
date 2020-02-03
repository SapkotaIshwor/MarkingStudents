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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Login Button
        private void login_button(object sender, RoutedEventArgs e)
        {

            if (username.Text == "admin" && password.Password == "admin")
            {
                MessageBox.Show("Welcome to the system", "Login Sucessful!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                this.Hide();
                HomePage homepage = new HomePage();
                homepage.ShowDialog();
            }

            else if(username.Text != "admin" && password.Password == "admin")
            {
                MessageBox.Show("Invalid username","Try Again",MessageBoxButton.OK,MessageBoxImage.Error);
            }

            else if (username.Text == "admin" && password.Password != "admin")
            {
                MessageBox.Show("Invalid password","Try Again", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                MessageBox.Show("Please enter username and password.","Try Again", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
