using System.Windows;

namespace CWAD
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

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "admin" && passPassword.Password == "admin")
            {
                MessageBox.Show("Welcome!!!", "Login Sucessful!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                this.Hide();
                Home homePage = new Home();
                homePage.ShowDialog();
            }

            else if (txtUsername.Text != "admin" && passPassword.Password == "admin")
            {
                MessageBox.Show("Username Error!!!", "Try Again!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (txtUsername.Text == "admin" && passPassword.Password != "admin")
            {
                MessageBox.Show("Password Error!!!", "Try Again!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                MessageBox.Show("Please enter correct Username and Password.", "Try Again!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
