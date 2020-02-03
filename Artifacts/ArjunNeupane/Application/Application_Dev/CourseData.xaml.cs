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

namespace Application_Dev
{
    /// <summary>
    /// Interaction logic for CourseData.xaml
    /// </summary>
    public partial class CourseData : Window
    {
        public CourseData()
        {
            InitializeComponent();
        }

        private void addCourseData(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
