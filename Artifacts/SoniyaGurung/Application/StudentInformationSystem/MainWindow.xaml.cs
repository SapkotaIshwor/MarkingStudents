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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin(object sender, RoutedEventArgs e)
        {
            if (userName.Text == "admin" && userPass.Password == "admin")
            {
                MessageBox.Show("Login Successful");
                StudentForm sForm = new StudentForm();
                this.Hide();
                sForm.Show();
            }
            else
            {
                MessageBox.Show("Enter correct username and password");
            }
        }

        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
