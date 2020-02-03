using DataHandler;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInformationSystems
{
    /// <summary>
    /// Interaction logic for StudentDetailReport.xaml
    /// </summary>
    public partial class StudentDetailReport : Window
    {
        public StudentDetailReport()
        {
            InitializeComponent();
            LoadStudentData();

        }
        private void LoadStudentData()
        {

            if (System.IO.File.Exists(@"C:\Informatics\Coursework\Application Development\StudentReport.xml"))
            {
                var handler = new Handler();


                var dataSet = new DataSet();

                dataSet.ReadXml(@"C:\Informatics\Coursework\Application Development\StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdStudentDetails.ItemsSource = dtStdReport.DefaultView;
            }

        }


        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void btnStudentRecord_Click(object sender, RoutedEventArgs e)
        {
            LoadStudentData();
        }

        private void btnSortRegDate_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"C:\Informatics\Coursework\Application Development\StudentReport.xml");
            DataTable DataTable = dataSet.Tables["StudentReport"];
            DataTable.DefaultView.Sort = "RegistrationDate Asc";
            grdStudentDetails.ItemsSource = DataTable.DefaultView;
        }

        private void btnSortName_Click_1(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"C:\Informatics\Coursework\Application Development\StudentReport.xml");
            DataTable DataTable = dataSet.Tables["StudentReport"];
            DataTable.DefaultView.Sort = "Name Asc";
            grdStudentDetails.ItemsSource = DataTable.DefaultView;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
