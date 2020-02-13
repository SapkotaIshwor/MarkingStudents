﻿using System;
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
using System.IO;

namespace Student_info
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
        private void exit_btn(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure wanna exit ?", "Exit Confirmation", System.Windows.MessageBoxButton.YesNo,MessageBoxImage.Warning);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Close();
                MainWindow mainWindow = new MainWindow();
            }
            else
            {
                //
            }
        

        }

        private void register_student(object sender, RoutedEventArgs e)
        {
            this.Hide();

            RegisterMainWindow rmWindow = new RegisterMainWindow();
            rmWindow.Show();
        }

        private void view_report(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ReportMainWindow reportMainWindow = new ReportMainWindow();
            reportMainWindow.Show();
        }

        private void log_out_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure wanna logout ?", "Logout Confirmation", System.Windows.MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Hide();
                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();
            }
            else
            {
                //
            }

           
        }

        private void change_password_Click(object sender, RoutedEventArgs e)
        {
            string msg = "                                     Change your password";
            password pw = new password(msg);
            pw.Show();


        }

     
    }
}
///////////////
///

