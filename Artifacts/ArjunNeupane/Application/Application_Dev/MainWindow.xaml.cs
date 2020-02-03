using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

namespace Application_Dev
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

        private void btnSubmit(object sender, RoutedEventArgs e)
        {
            string user_name = txtUsername.Text;
            string password = txtPassword.Password;

            string user = "user";
            string pw = "user";


               
                if (user_name == "")
                {
                    MessageBox.Show("Empty username! Please enter username first", "Error", System.Windows.MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (password == "")
                {
                    MessageBox.Show("Password can't be empty!", "Error", System.Windows.MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (password == pw && user_name == user)
                {
                // this.Hide();
                Home dashboard = new Home();
                        dashboard.Show();
                      this.Close();
            }

            else
                {
                    MessageBox.Show("Invalid username and password!", "Error", System.Windows.MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }
    }
}
