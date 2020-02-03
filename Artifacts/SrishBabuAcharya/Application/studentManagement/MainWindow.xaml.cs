using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace studentManagement
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
        
     
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string Username = textBoxUserName.Text;
            string password = passwordBox.Password;

            if (textBoxUserName.Text == "admin" && passwordBox.Password == "admin")
            {
                Console.WriteLine("Reached!");
                home sm = new home();
                this.Hide();
                sm.Show();
                //Application.Run(new Form1());
            }

            else if (textBoxUserName.Text.Length == 0)
            {
                errormessage.Text = "Enter an username.";
                textBoxUserName.Focus();
            }

            else if (passwordBox.Password.Length == 0)
                {
                errormessage.Text = "Enter password.";
                passwordBox.Focus();
            }


            else
            {
                MessageBox.Show("Invalid username or password! Please Try Again", "Error");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

