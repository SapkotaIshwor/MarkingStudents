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

namespace Student_Information_System
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

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text != "" || txtPassword.Password != "")
            {

                if (txtUsername.Text == "admin" && txtPassword.Password == "admin")
                {
                    MessageBox.Show("Sucess!");
                    this.Hide();
                    StudentInfo studentInfo = new StudentInfo();
                    studentInfo.ShowDialog();


                }
                else ErrorMessage();
            }
        }
        public void ErrorMessage()
        {
            MessageBox.Show("Incorrect username or password", "Login Error");
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
        }
    }
}
