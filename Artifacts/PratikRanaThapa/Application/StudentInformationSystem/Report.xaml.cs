using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
        }

        private void btnClose1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnWeekly_Click(object sender, RoutedEventArgs e)
        {
            var dataset = new DataSet();
            dataset.ReadXml(@"StudentReport.xml");
            DataTable stdReport = dataset.Tables[0];
            int total_AD = 0;
            int total_AI = 0;
            int total_Database = 0;

            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enroll", typeof(string));
            dt.Columns.Add("Total Students", typeof(int));

            for (int a = 0; a < stdReport.Rows.Count; a++)
            {
                string col = stdReport.Rows[a]["CourseEnroll"].ToString();
                if (col == "Multimedia Technology")
                {
                    total_Database++;
                }
                else if (col == "Networks and IT Security")
                {
                    total_AD++;
                }
                else if (col == "Computing")
                {
                    total_AI++;
                }
            }
            dt.Rows.Add("Application Development: ", total_AD);
            dt.Rows.Add("Artificial Intelligence: ", total_AI);
            dt.Rows.Add("Advance Database: ", total_Database);

            dgReport.ItemsSource = dt.DefaultView;


        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
          
            main.Content = new Page1();
            dgReport.Visibility = Visibility.Collapsed;
            btnWeekly.Visibility = Visibility.Collapsed;
            btnChart.Visibility = Visibility.Collapsed;
            btnClose1.Visibility = Visibility.Collapsed;


        }
    }
}

