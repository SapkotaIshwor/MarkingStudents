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
using System.IO;

namespace StudentInformationSystem
{
    /// <summary>
    /// <Interaction logic for Home.xaml>
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void EnrollStudent_Click(object sender, RoutedEventArgs e)
        {
            EnrollStudent enrollStudent = new EnrollStudent();
            enrollStudent.Show();
            this.Close();

        }

        private void TotalStudent_Click(object sender, RoutedEventArgs e)
        {
            TotalStudents totalStudents = new TotalStudents();
            totalStudents.Show();
            this.Close();
        }

        private void btnImportStudentDetails_Click(object sender, RoutedEventArgs e)
        {
            ImportStudentDetails importStudentDetails = new ImportStudentDetails();
            importStudentDetails.Show();
            this.Close();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            Report report = new Report();
            report.Show();
            this.Close();
        }

        private void btnBarDaigram_Click(object sender, RoutedEventArgs e)
        {
            BarDiagram barDiagram = new BarDiagram();
            barDiagram.Show();
            this.Close();
        }
    }
}
