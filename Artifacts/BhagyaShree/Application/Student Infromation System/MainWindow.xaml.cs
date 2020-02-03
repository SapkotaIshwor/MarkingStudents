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

namespace Student_Infromation_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    ///// </summary>
    public partial class MainWindow : Window
    {
        App app = App.Current as App;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Login Button
        private void Login_button(object sender, RoutedEventArgs e)
        {
     
            if (username.Text == "admin" && password.Password == "admin")
            {
                MessageBox.Show("Login sucessfull, Welcome to Student Infromation System", "Welcome admin");
                this.Hide();
                Home home = new Home();
                home.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login Failed,Please enter valid Information");
            }
        }
   
    }
}


