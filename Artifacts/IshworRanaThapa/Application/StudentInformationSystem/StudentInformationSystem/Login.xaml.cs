using System.Windows;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object MessageBoxButtons { get; private set; }
        public object MessageBoxIcon { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        // to check whether the username and password are correct or not
        private void ProcessLogin()
        {
            if (txtboxUname.Text == "admin" && txtPassword.Password == "admin")
            {
                HomePage hm = new HomePage();
                this.Close();
                hm.Show();
            }
            else
            {
                ErrorMess();
            }
        }


        private void ErrorMess()
        {
            MessageBox.Show("Incorrect username or password");
            txtboxUname.Text = "";
            txtPassword.Password = "";


        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            ProcessLogin();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
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
    }
}
