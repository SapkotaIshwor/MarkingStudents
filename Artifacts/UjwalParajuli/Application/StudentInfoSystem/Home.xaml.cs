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
using System.Windows.Shapes;

namespace StudentInfoSystem
{

    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        
        public Home()
        {
            InitializeComponent();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddStudents();
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ImportCSV();
        }

        private void viewDetails_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new StudentDetails();
            
        }

        private void viewReport_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new WeeklyReport();
        }

        private void viewChart_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Chart();
        }
    }
}