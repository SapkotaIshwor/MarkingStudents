﻿using System;
using System.Data;
using System.Windows;
using DataHandler;

namespace AppDevelopmentCW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

            main.Content = new login();

        }

       
    }
}

