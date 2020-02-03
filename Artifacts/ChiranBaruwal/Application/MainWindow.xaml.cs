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
        UserControl activeUC;
        public MainWindow()
        {
            InitializeComponent();
            activeUC = addStudentControl;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ImportControl.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            activeUC.Visibility = Visibility.Hidden;
            addStudentControl.Visibility = Visibility.Visible;
            activeUC = addStudentControl;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            activeUC.Visibility = Visibility.Hidden;
            generateReportControl.Visibility = Visibility.Visible;
            activeUC = generateReportControl;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            activeUC.Visibility = Visibility.Hidden;
            weeklyReport.Visibility = Visibility.Visible;
            activeUC = weeklyReport;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            activeUC.Visibility = Visibility.Hidden;
            courseEnrollment.Visibility = Visibility.Visible;
            activeUC = courseEnrollment;
        }

        private void addStudentControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
