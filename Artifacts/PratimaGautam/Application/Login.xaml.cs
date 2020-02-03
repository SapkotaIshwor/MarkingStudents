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

        Registration registration = new Registration();

        private void BtnLogin(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text != "admin")
            {
                MessageBox.Show("Username is incorrect!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                errormessage.Text = "Enter a correct username.";
                textBoxEmail.Focus();
                textBoxEmail.Clear();
            }
            else if (passwordBox.Password != "admin")
            {
                MessageBox.Show("Sorry! Password is incorrect!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                errormessage.Text = "Please enter existing password.";
                passwordBox.Clear();
            }
            else
            {
                MessageBox.Show("Logged in Successfully !!!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                this.Visibility = Visibility.Hidden; // hiding the login window using this
                mainWindow.Show();
            }

            //// Using the SQL Client

            //if (textBoxEmail.Text.Length == 0)
            //{
            //    errormessage.Text = "Enter an email.";
            //    textBoxEmail.Focus();
            //}
            //else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            //{
            //    errormessage.Text = "Enter a valid email.";
            //    textBoxEmail.Select(0, textBoxEmail.Text.Length);
            //    textBoxEmail.Focus();
            //}
            //else
            //{
            //    string email = textBoxEmail.Text;
            //    string password = passwordBox.Password;
            //    SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=pratima");
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("Select * from Registration where Email='" + email + "'  and password='" + password + "'", con);
            //    cmd.CommandType = CommandType.Text;
            //    SqlDataAdapter adapter = new SqlDataAdapter();
            //    adapter.SelectCommand = cmd;
            //    DataSet dataSet = new DataSet();
            //    adapter.Fill(dataSet);
            //    if (dataSet.Tables[0].Rows.Count > 0)
            //    {
            //        string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();
            //        mainWindow.TextBlockName.Text = username;//Sending value from one form to another form.  
            //        mainWindow.Show();
            //        Close();
            //    }
            //    else
            //    {
            //        errormessage.Text = "Sorry! Please enter existing emailid/password.";
            //    }
            //    con.Close();
            //}
        }

        private void BtnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // exit the application 
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }
    }
}
