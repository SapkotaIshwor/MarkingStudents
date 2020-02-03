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
  
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
        }


        private void sortData_Click(object sender, RoutedEventArgs e)
        {
            SortData sort = new SortData();
            sort.Show();
        }

     
        private void showChart_Click(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();

        }

        private void weeklyTable_Click(object sender, RoutedEventArgs e)
        {
            WeeklyTable weeklytable = new WeeklyTable();
            weeklytable.Show();
        }

        private void saveAndRetrive_Click(object sender, RoutedEventArgs e)
        {
            SerializerDeserializer serialize = new SerializerDeserializer();
            serialize.Show();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
                home.Show();
            this.Close();
        }
    }
}
