using System.Windows;
using System.Windows.Controls;

namespace AppDevelopmentCW
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();

           
        }

        private void RegisterStudent(object sender, RoutedEventArgs e)
        {
            //main.Content = new StudentRegistration();
            this.NavigationService.Navigate(new StudentRegistration());

        }

        private void AddCourse(object sender, RoutedEventArgs e)
        {
            // main.Content = new Course();
            this.NavigationService.Navigate(new Course());

        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new login());
        }
    }
}
