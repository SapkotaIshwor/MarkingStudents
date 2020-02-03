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
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (username == "")
            {
                MessageBox.Show("Username is Empty!", "Error");
            }
            else if (password == "")
            {
                MessageBox.Show("Password is Empty", "Error");
            }
            else if (password == "admin" && username == "admin")
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }

            else
            {
                MessageBox.Show("Incorrect Username and Password!!! Please Try Again", "Error Occured");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close this system?",
                "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.Show();
            }

        }
    }
}

