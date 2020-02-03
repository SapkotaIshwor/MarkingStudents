using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coursework
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
            {
                if (Username.Text.Trim() == "" && Password.Password.Trim() == "")
                {
                    MessageBox.Show("Invalid Username or Password");
                }
                else
                {
                    if (Username.Text.Trim() == "admin" && Password.Password.Trim() == "admin")
                    {
                        Home homeWindow = new Home();
                        homeWindow.Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                }
            }
        }
    }
}