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

namespace Coursework
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnrollStudent enrollStudent = new EnrollStudent();
            enrollStudent.Show();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StudentDetails student = new StudentDetails();
            student.Show();
            this.Close();
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            GenerateReport generate = new GenerateReport();
            generate.Show();
            this.Close();

        }

        private void TotalStudents_Click(object sender, RoutedEventArgs e)
        {
            TotalNoStudents totalNoStudents = new TotalNoStudents();
            totalNoStudents.Show();
            this.Close();

        }

        private void BarDiagram_Click(object sender, RoutedEventArgs e)
        {
            BarDiagram barDiagram = new BarDiagram();
            barDiagram.Show();
            this.Close();

        }

        private void StudentDetails_Click(object sender, RoutedEventArgs e)
        {
            StudentDetails student = new StudentDetails();
            student.Show();
            this.Close();

        }
    }
}
