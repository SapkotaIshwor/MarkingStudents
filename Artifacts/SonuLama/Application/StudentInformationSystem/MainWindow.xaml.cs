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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user, pass;
            user = txtUser.Text;
            pass = txtPass.Password;
            if(user != "admin")
            {
                MessageBox.Show("Username is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUser.Clear();
            }
            else if(pass != "root")
            {
                MessageBox.Show("Password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPass.Clear();
            }

            else
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                StartPage start = new StartPage();
                start.ShowDialog();
            }
        }
    }
}
