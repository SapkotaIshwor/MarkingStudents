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
        private Boolean err;
        private String errMsg;

        public LoginWindow()
        {
            InitializeComponent();
        }

        /**
         * Handle login request.
         */
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String username = txtUsername.Text.ToString();
            String password = txtPassword.Password.ToString();

            // Validation
            err = false;
            errMsg = "";

            if (username.Length <= 0)
            {
                err = true;
                errMsg += "Username is required.\n";
            }

            if (password.Length <= 0)
            {
                err = true;
                errMsg += "Password is required.\n";
            }

            if (err)
            {
                // If validation fails
                MessageBox.Show(errMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // If validation succeeds
                if (username.Equals("sajan") && password.Equals("sajan"))
                {
                    // Close this window and open main window
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
