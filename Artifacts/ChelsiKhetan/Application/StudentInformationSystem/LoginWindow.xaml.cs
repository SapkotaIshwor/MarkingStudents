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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Boolean error;
        private String errorMsg;
        public LoginWindow()
        {
            InitializeComponent();
        }

        /**
         * Validate user login credentials.
         */
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Fetch data from form
            String userName = txtUsername.Text.ToString();
            String password = txtPassword.Password.ToString();

            // Form validation
            error = false;
            errorMsg = "";

            if (userName.Length <= 0)
            {
                error = true;
                errorMsg += "Username is required.\n";
            }

            if (password.Length <= 0)
            {
                error = true;
                errorMsg += "Password is required.\n";
            }
            
            // If there is error in the form
            if (error == true)
            {
                MessageBox.Show(errorMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // If there is no error in the form
                if (userName.Equals("chelsi") && password.Equals("chelsi"))
                {
                    // Open main window and close this window.
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username/password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
