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

namespace Student_Management_System
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

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close this window?",
                "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passTextbox.Password;

            if (username == "")
            {
                MessageBox.Show("Username is Empty!", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else if (password == "")
            {
                MessageBox.Show("Password is Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (password == "admin" && username == "admin")
            {
                Forms.HomePage hpobj = new Forms.HomePage();
                this.Close();
                hpobj.ShowDialog();
            }

            else
            {
                MessageBox.Show("Invalid Username and Password! Please Try Again", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
            
        }
    }
}
