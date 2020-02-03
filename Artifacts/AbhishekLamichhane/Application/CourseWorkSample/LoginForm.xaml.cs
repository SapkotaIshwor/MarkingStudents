using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CourseWorkSample
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (txt_username.Text != "admin")
            {
                MessageBox.Show("Username is incorrect!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_username.Clear();

            }
            else if (txt_password.Password != "admin")
            {
                MessageBox.Show("Password is incorrect!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_password.Clear();
            }
            else
            {   
                MessageBox.Show("Logged in Successfully !!!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainForm = new MainWindow();
                mainForm.Show();


            }
        }

       

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();

        }
    }
}
