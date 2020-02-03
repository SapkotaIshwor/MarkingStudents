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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Information_System
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

     

      
        private void RegistrationDetails_Click(object sender, RoutedEventArgs e)
        {

            StudentDetails studentDetails = new StudentDetails();
            studentDetails.Show();

        }

      
     

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Want to exit the system ?");
            this.Close();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudents addStudents = new AddStudents();
            addStudents.Show();
        }

        private void ImportStudent_Click(object sender, RoutedEventArgs e)
        {
           
            ImporttoCSV importtoCSV = new ImporttoCSV();
            importtoCSV.Show();

        }

        private void WeeklyReport_Click(object sender, RoutedEventArgs e)
        {
            WReport wReport = new WReport();
            wReport.Show();
        }

        private void Chart_click(object sender, RoutedEventArgs e)
        {
            ColumnChart columnChart = new ColumnChart();
            columnChart.Show();
        }
    }
}
