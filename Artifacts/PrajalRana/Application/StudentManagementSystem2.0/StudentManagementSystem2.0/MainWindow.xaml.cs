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
using DataHandler;

namespace StudentManagementSystem2._0 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
       
     
        private void menu2_Click(object sender, RoutedEventArgs e) {
            WeeklyReport weeklydtls = new WeeklyReport();
            weeklydtls.Show();
        }

        private void menu1_Click(object sender, RoutedEventArgs e) {
            StudentDetails stddetails = new StudentDetails();
            stddetails.Show();
        }

        private void menu2_Click_1(object sender, RoutedEventArgs e) {

        }

        private void menu3_Click(object sender, RoutedEventArgs e) {

        }

        private void menu5_Click(object sender, RoutedEventArgs e) {
            SortByDate srtbd = new SortByDate();
            srtbd.Show();
        }

        private void menu4_Click(object sender, RoutedEventArgs e) {

        }

        private void menu6_Click(object sender, RoutedEventArgs e) {
            SortByName srtbn = new SortByName();
            srtbn.Show();
        }

        private void menu7_Click(object sender, RoutedEventArgs e) {
            Chart chartt = new Chart();
            chartt.Show();
        }
    }
}
