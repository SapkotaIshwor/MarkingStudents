using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentRegistration
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addstd = new AddStudent();
            addstd.Show();
        }

        private void bulkUpload_Click(object sender, RoutedEventArgs e)
        {
            ExcelImport excelImport = new ExcelImport();
            excelImport.Show();
        }

        private void viewReport_Click(object sender, RoutedEventArgs e)
        {
            ViewReport viewReport = new ViewReport();
            viewReport.Show();
        }

        private void addCourse_Click(object sender, RoutedEventArgs e)
        {
            AddCourse addCourse = new AddCourse();
            addCourse.Show();
        }
    }
}
