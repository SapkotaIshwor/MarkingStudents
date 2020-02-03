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
    /// Interaction logic for password.xaml
    /// </summary>
    public partial class password : Window
    {

        public password(string msg)
        {
            InitializeComponent();
            header_box.Content = msg;
            header_box.IsEnabled = false;

        }

        private void register_button(object sender, RoutedEventArgs e)
        {
            string pw1 = password_box.Password;
            string pw2 = password_box_Copy.Password;
            if (pw1 == pw2)
            {
                string path = @"d:\Student_Management\password.dat";

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Close();
                    //write text
                    string username = username_box.Text;
                   
                    using (StreamWriter streamWriter = new StreamWriter(path, true))
                    {
                        streamWriter.WriteLine($"{username },{pw1}");
                        streamWriter.Close();
                    }
                }

                this.Hide();
                HomeWindow hmWindow = new HomeWindow();
                hmWindow.Show();
            }
            else
            {
                MessageBox.Show("Password does not match!");
            }
        }

        private void exit_btn(object sender, RoutedEventArgs e)
        {

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure wanna cancel process ?", "Exit Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Close();

            }
            else
            {
                //
            }
            
        }

        private void pw_show_btn(object sender, RoutedEventArgs e)
        {
            password_box.PasswordChar = default(char);
        }
    }
}
