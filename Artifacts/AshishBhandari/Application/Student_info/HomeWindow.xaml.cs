using System;
using System.Collections.Generic;
using System.IO;
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

namespace Student_info
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private string CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private string FilePath = @"d:\Student_Management\password.dat";
        public HomeWindow()
        {
        
        InitializeComponent();

            //if folder exist system ignore this line
            string folderName = @"d:\Student_Management";

            System.IO.Directory.CreateDirectory(folderName);

            //check whether password file exists or not

            bool checkFile = check_file(FilePath);
            if (checkFile == false)
            {
                string msg = "It seems you are new to this system! Set username and password";
                this.Hide();

                password pw = new password(msg);
                pw.Show();


            }


        }

        private void exit_button(object sender, RoutedEventArgs e)
        {

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure wanna exit ?", "Exit Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Close();

            }
            else
            {
                //
            }

        }

        private void login_button(object sender, RoutedEventArgs e)
        {
            string user_name = username_box.Text;
            string password = password_box.Password;

            string user;
            string pw;

            List<string> lines = File.ReadAllLines(FilePath).ToList();


            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                user = entries[0];
                pw = entries[1];



                if (user_name == "")
                {
                    MessageBox.Show("Empty username! Please enter username first","Error", System.Windows.MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (password == "")
                {
                    MessageBox.Show("Password can't be empty!", "Error", System.Windows.MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (password == pw && user_name == user)
                {
                    // this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Invalid username and password!", "Error", System.Windows.MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool check_file(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                return true;
            }

        }



        private void Checkbox_pw_show(object sender, RoutedEventArgs e)
        {


        }

        private void forgetpw_button(object sender, RoutedEventArgs e)
        {
            string msg = "                                Set up new username and password";

            password pw = new password(msg);
            pw.Show();
        }

    }
}
