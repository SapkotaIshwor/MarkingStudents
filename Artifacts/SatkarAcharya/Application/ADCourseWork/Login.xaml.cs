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

namespace ADCourseWork
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        

        public Login()
        {
            InitializeComponent();
        }


 

        private void Button_Login(object sender, RoutedEventArgs e)
        {

            string user, pass;
            user = txtUserName.Text;
            pass = txtPassword.Password;
            if (user == "admin" && pass == "admin")
            {
                MessageBox.Show("Now you are Logged in");
                this.NavigationService.Navigate(new StudentDetail());
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomePage());
        }
    }
}
