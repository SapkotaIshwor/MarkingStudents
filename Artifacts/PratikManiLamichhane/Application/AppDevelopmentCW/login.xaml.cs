using System.Windows;
using System.Windows.Controls;

namespace AppDevelopmentCW
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }


        private string userName;
        private string pass;
        private int attempt=1;
        private void LoginCheck(object sender, System.Windows.RoutedEventArgs e)
        {
            if (attempt < 4)
            {
                userName = txtUserName.Text;
                pass = txtPassword.Password;
                if (userName == "Admin" && pass == "admin")
                {
                    this.NavigationService.Navigate(new WelcomePage());
                }
                else
                {
                    int rem =3-attempt ;
                    MessageBox.Show("Password  Wrong try Again!!! \n" + attempt+ " Attempt\n"+rem+ "Attempts Remaining");
                    attempt++;
                    clear();
                }
            }
            else
            {
                MessageBox.Show("Restart this program again!");
            }
        }

        public void clear()
        {
            txtPassword.Password = null;
        }
    }
}
