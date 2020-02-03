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
            string[] str = new string[] { "Male", "Female", "Other" };
            cbGender.ItemsSource = str;
            cbGender.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String user = txtUsername.Text;
            String pass = pbLoginPassword.Password.ToString();
            Console.WriteLine("Clicked: "+ user +" | "+ pass);
            login(user, pass);
        }

        private void login(String username, String password)
        {
            if (username == "admin" & password == "pass")
            {
                Console.WriteLine("User: " + username + " | pass: " + password);
                Dashboard win2 = new Dashboard();
                win2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sorry! Wrong username or password", "Login Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void signUP(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not in working condition.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
