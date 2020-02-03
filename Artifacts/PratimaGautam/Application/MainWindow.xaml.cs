using System.Windows;

namespace StudentInformationSystem
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

        private void BtnImport(object sender, RoutedEventArgs e)
        {
            ImportReport importReport = new ImportReport();
            this.Visibility = Visibility.Hidden; // hiding the main window using this
            importReport.Show();
        }

        private void BtnAddStudent(object sender, RoutedEventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            this.Visibility = Visibility.Hidden; // hiding the main window using this
            addStudent.Show();
        }

        private void BtnDisplayReport(object sender, RoutedEventArgs e)
        {
            DisplayReport displayReport = new DisplayReport();
            this.Visibility = Visibility.Hidden;
            displayReport.Show();
        }

        private void BtnLogout(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Do You Really Want To Exit?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Hide();
                Login frm = new Login();
                frm.Show();
            }
            else if (messageBoxResult == MessageBoxResult.No)
            {
                //do something else
                messageBoxResult = MessageBoxResult.Cancel;
            }
        }

        private void BtnChartView(object sender, RoutedEventArgs e)
        {
            DisplayChart displayChart = new DisplayChart();
            this.Visibility = Visibility.Hidden; // hiding the main window using this
            displayChart.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
            Login loginWindow = new Login();
            loginWindow.Show();
        }
    }
}
