using Student_Management_System.ViewModels;
using Student_Management_System.Windows;
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

namespace Student_Management_System.Forms
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

        private void Enrollbtn_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new EnrollModel();
        }

        private void ViewStudents_ButtonClicked(object sender, RoutedEventArgs e)
        {
            ViewStudents vsobj = new ViewStudents();
            vsobj.ShowDialog();
        }

        private void ImportFileButton_Clicked(object sender, RoutedEventArgs e)
        {
            Import imfile = new Import();
            imfile.ShowDialog();
        }

        private void WeeklyReport_keyAction(object sender, RoutedEventArgs e)
        {
            DataContext = new WeeklyReport();
        }

        private void ViewInChart_Clicked(object sender, RoutedEventArgs e)
        {
            ViewInChart vchobj = new ViewInChart();
            vchobj.ShowDialog();
        }
    }
}
