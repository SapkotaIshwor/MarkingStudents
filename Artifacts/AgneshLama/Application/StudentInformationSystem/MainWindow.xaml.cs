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

namespace StudentInformationSystem
{
    /// <summary>
    /// <Interaction logic for MainWindow.xaml>
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtUserName.Text.Trim() == "" && txtPassword.Password.Trim() == "")
            {
                MessageBox.Show("Invalid Username or Password");
            }
            else
            {
                if (txtUserName.Text.Trim() == "admin" && txtPassword.Password.Trim() == "admin")
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
