using System;
using System.Windows;


namespace StudentInformationSystem
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

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            String user, pass;
            user = editusername.Text;
            pass = editpassword.Password;
            if (user.Equals("") || pass.Equals(""))
            {
                MessageBox.Show("You can't pass empty value", "Login Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (user != "admin" || pass != "admin")
            {
                MessageBox.Show("Username or passwoard didn't match!", "Login Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                editusername.Clear();
                editpassword.Clear();
            }
            else
            {
                MessageBox.Show("Login Successful", "Login success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                MainPage hp = new MainPage();
                hp.Show();
                this.Close();
            }
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you Sure?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (dialogResult == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
