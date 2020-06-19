using CourseWorkSample;
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
using System.Windows.Shapes;

namespace APPLICATION_DEVELOPMENT
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                if (Txt_username.Text == "ANKIT GURUNG" && Txt_Password.Password == "ANKIT22")
                {
                    MessageBox.Show("Logged in Successfully", "Alert");
                    MainWindow Log = new MainWindow();
                     Log.Show();
                     Close();

                }
                else
                {
                    MessageBox.Show("Login Fail!", "Alert");
                    Txt_username.Clear();
                    Txt_Password.Clear();
                }
            
        } 
    }
}
