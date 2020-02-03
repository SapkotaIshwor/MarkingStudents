using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Login2
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            errormessage.Text = "";

            var username = txtUsername.Text;
            var password = txtPassword.Password;

           
                if (username == "admin" && password == "admin")
                {

                MessageBox.Show("You have Logged successfully");
               

                    Home home = new Home();
                    home.Show();
                    this.Close();
                }
                else if (username != "admin" && password != "admin")
                {
                MessageBox.Show("Either Email Or PassWord Is Incorrect");
                }
                else if ((username == "admin" && password != "admin"))
                {
                MessageBox.Show("PassWord Is Incorrect");
                
                }
                else
                {
                MessageBox.Show("Email Or Pass Is Incorrect");
                   
                }
            
        }
            
            
            
         

    }
}
