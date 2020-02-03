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

namespace StudentRegistration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
           InitializeComponent();
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = tvUsername.Text;
            string password = tvPassword.Password;
            if (username == "" || password == "")
            {
                MessageBox.Show("username or password cannot be empty");
            }
            else
            {
                if (username == "admin")
                {
                    if (password == "admin")
                    {
                        
                        HomePage home = new HomePage();
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password !! Please input correct password of if forgotten contact developer");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect username !! Please input correct password of if forgotten contact developer");
                }

            }


        }
    }
}
