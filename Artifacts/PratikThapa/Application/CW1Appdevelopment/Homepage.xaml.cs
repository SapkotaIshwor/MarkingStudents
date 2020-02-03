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

namespace CW1Appdevelopment
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        public Homepage()
        {
            InitializeComponent();

        }

        private void Login(object sender, RoutedEventArgs e)
        {
            {
                //.Content = new StudentDetail();
                //this.NavigationService.Navigate(new Studentdetails());
            }
            string user, pass;
            user = txtuser.Text;
            pass = txtPass.Password;
            

            if (user == "admin" && pass == "admin")
            {
                MessageBox.Show("Select this to enter Studentdetails");
                this.NavigationService.Navigate(new Studentdetails());
                
            }
            else
            {
                MessageBox.Show("error");
            }
        }


        private void Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        
    }
}
