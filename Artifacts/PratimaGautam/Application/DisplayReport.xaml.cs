using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for DisplayReport.xaml
    /// </summary>
    public partial class DisplayReport : Window
    {
        string CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory;

        public DisplayReport()
        {
            InitializeComponent();
            var dataHandler = new DataHandler();
            var dataSet = dataHandler.CreateDataSet();

            if (File.Exists(@CurrentPath + "\\StudentCWData.xml"))
            {
                dataSet.ReadXml(@CurrentPath + "\\StudentCWData.xml");
                ReportGrid.ItemsSource = new DataView(dataSet.Tables["Student"]);
            }
        }

        private void BtnSortByName(object sender, RoutedEventArgs e)
        {
            ReportGrid.Items.SortDescriptions.Clear();
            ReportGrid.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("FirstName", System.ComponentModel.ListSortDirection.Ascending));
            ReportGrid.Items.Refresh();
        }

        private void BtnSortByDate(object sender, RoutedEventArgs e)
        {
            ReportGrid.Items.SortDescriptions.Clear();
            ReportGrid.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("RegistrationDate", System.ComponentModel.ListSortDirection.Descending));
            ReportGrid.Items.Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void BtnWeeklyReport_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@CurrentPath + "\\StudentCWData.xml");
            DataTable stdReport = dataSet.Tables[0];

            int total_computing = 0;
            int total_multimedia_technologies = 0;
            int total_networks_and_it_security = 0;

            DataTable dt = new DataTable("Weekly_Report_Of_Students");
            dt.Columns.Add("CourseEnroll", typeof(String));
            dt.Columns.Add("TotalStudents", typeof(int));

            for(int i=0; i<stdReport.Rows.Count; i++)
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

            WeeklyReportGrid.ItemsSource = dt.DefaultView;
        }

        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
