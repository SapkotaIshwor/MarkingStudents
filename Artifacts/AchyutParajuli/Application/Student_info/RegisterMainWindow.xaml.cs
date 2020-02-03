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

namespace Student_info
{
    /// <summary>
    /// Interaction logic for RegisterMainWindow.xaml
    /// </summary>
    public partial class RegisterMainWindow : Window
    {
        public RegisterMainWindow()
        {
            InitializeComponent();
        }

        private void individualRegister_Click(object sender, RoutedEventArgs e)
        {
            Register_student register_StudentWindow = new Register_student();
            register_StudentWindow.Show();
            this.Close();
        }

        private void bilkRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterBulkStdWindow registerBulkStdWindow = new RegisterBulkStdWindow();
            registerBulkStdWindow.Show();
            this.Close();
        }

        private void back_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
