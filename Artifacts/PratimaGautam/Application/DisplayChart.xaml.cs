using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for DisplayChart.xaml
    /// </summary>
    public partial class DisplayChart : Window
    {
        string CurrentPath = AppDomain.CurrentDomain.BaseDirectory;

        public DisplayChart()
        {
            InitializeComponent();
            var dataSet = new DataSet();
            dataSet.ReadXml(@CurrentPath + "\\StudentCWData.xml");
            DataTable stdReport = dataSet.Tables[0];

            int total_computing = 0;
            int total_multimedia_technologies = 0;
            int total_networks_and_it_security = 0;

            DataTable dt = new DataTable("Weekly_Report_Of_Students");
            dt.Columns.Add("Course Enroll", typeof(String));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < stdReport.Rows.Count; i++)
            {
                String col = stdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    total_computing++;
                }
                else if (col == "Multimedia Technologies")
                {
                    total_multimedia_technologies++;
                }
                else if (col == "Networks and IT Security")
                {
                    total_networks_and_it_security++;
                }
            }

            dt.Rows.Add("Computing", total_computing);
            dt.Rows.Add("Multimedia Technologies", total_multimedia_technologies);
            dt.Rows.Add("Networks and IT Security", total_networks_and_it_security);

            // WeeklyReportGrid.ItemsSource = dt.DefaultView;
            ((PieSeries)pieChart).ItemsSource =
                new KeyValuePair<string, int>[] { new KeyValuePair<string, int>("Computing", total_computing), new KeyValuePair<string, int>("Multimedia Technologies", total_multimedia_technologies), new KeyValuePair<string, int>("Networks and IT Security", total_networks_and_it_security)

                };
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
