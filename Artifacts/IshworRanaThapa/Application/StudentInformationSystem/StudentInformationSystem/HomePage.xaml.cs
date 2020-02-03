using System.Windows;

namespace StudentInformationSystem
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

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentAdd addStd = new StudentAdd();
            this.Hide();
            addStd.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Report rp = new Report();
            MessageBox.Show("Do you want to open the report file ");
            this.Close();
            rp.Show();
        }

        private void Btn_WeeklyReport(object sender, RoutedEventArgs e)
        {
            WeeklyTabularReport wtr = new WeeklyTabularReport();
            MessageBox.Show("Opening Weekly Report Window");
            this.Close();
            wtr.Show();
        }

        private void Btn_Csv_Imp(object sender, RoutedEventArgs e)
        {
            ImportCsv csvImp = new ImportCsv();
            this.Close();
            csvImp.Show();
        }
    }
}
