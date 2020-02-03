using System.Windows;


namespace ApplicationDevelopment
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if(txtUsername.Text == "admin" && txtPassword.Password == "admin")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Username or Password Not Matched!");

            }
        }
    }
}
