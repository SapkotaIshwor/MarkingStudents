﻿using System;
using System.Collections.Generic;
using System.Data;
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

namespace Coursework
{
    /// <summary>
    /// Interaction logic for Weekreport.xaml
    /// </summary>
    public partial class Weekreport : Window
    {
        public Weekreport()
        {
            InitializeComponent();
        }

        private void week(object sender, RoutedEventArgs e)
        {
            var dataset = new DataSet(); // declaring new data set
            dataset.ReadXml(@"E:\student.xml");  // reading main report
            DataTable stdReport = dataset.Tables[0];
            int total_Com = 0;   // assigning initial values of Course to 
            int total_Mul = 0;
            int total_Net = 0;


            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enroll", typeof(String));  // creating two columns
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < stdReport.Rows.Count; i++)
            {


                String col = stdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    total_Com++;   // incrementing values of each course based on user input
                }
                else if (col == "Multimedia Technologies")
                {
                    total_Mul++;
                }
                else if (col == "Networks and IT Security")
                {
                    total_Net++;
                }
            }

            dt.Rows.Add("Computing", total_Com);          // final assign
            dt.Rows.Add("Multimedia Technologies", total_Mul);
            dt.Rows.Add("Networks and IT Security", total_Net);


            weekGrid.ItemsSource = dt.DefaultView; // is the name of data grid
        }
    }
}



        
    








