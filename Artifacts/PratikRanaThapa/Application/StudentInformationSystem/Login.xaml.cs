
using System.Windows;



namespace StudentInformationSystem
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            errormessage.Text = "";
            string user = tbUsername.Text;
            string pass = pbPassword.Password;
            if (tbUsername.Text.Length == 0)
            {
                errormessage.Text = "Enter an Username.";

                tbUsername.Focus();
            }

            else if (pbPassword.Password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                pbPassword.Focus();
                }
            
            else {
                if (user == "admin" && pass == "admin")
                {
                    errormessage.Text = "Good Job!! You have Logged successfully.";

                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else if (user != "admin" && pass != "admin")
                {
                    errormessage.Text = "Either Username Or PassWord Is Wrong";
                }
                else if ((user == "admin" && pass != "admin"))
                {
                    errormessage.Text = "PassWord Is Incorrect";
                }
                else {
                    errormessage.Text = "Username Or Pass Is Incorrect";
                }
            }
        }
    }
}
