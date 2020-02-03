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

namespace ApplicationDevelopmentCw1
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

       
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var email = txtEmail.Text;
            var password = txtPassword.Text;
            if (email == "susheelgautam321@gmail.com" && password=="1234")
            {
                Homeage homepage = new Homeage();
                homepage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter susheelgautam321@gmail.com as Email and 1234 as password", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
