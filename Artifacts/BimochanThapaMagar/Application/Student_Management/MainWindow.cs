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

namespace Student_Management
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Password;

            if (username == "")
            {
                MessageBox.Show("Empty username ! Please try again inserting correct username");
            }
            else if (password == "")
            {
                MessageBox.Show("Empty password ! Please try again inserting correct password");
            }
            else if (password == "bimochan2" && username == "Bimochan")
            {
                this.Hide();
                baseWndo basewndo = new baseWndo();
                basewndo.Show();
            }

            else
            {
                MessageBox.Show("Incorrect username and password!");
            }

        }

        internal void Show()
        {
            throw new NotImplementedException();
        }

        private void Hide()
        {
            throw new NotImplementedException();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Window is being exited");
            this.Close();
        }

        private void Close()
        {
            throw new NotImplementedException();
        }

        private void usernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
