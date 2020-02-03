using DataHandler;
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

namespace StudentInformationSystems
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
            var handler = new Handler();
            var dataSet = new DataSet();
            dataSet.ReadXml(@"D:\StudentInformationSystem\StudentReport.xml");
            DataTable dtStdReport = dataSet.Tables[0];

            int total_Computing = 0;
            int total_MultimediaTechnology = 0;
            int total_NetworksandITSecuity = 0;

            DataTable dt = new DataTable("newTable");
            dt.Columns.Add("CourseEnroll", typeof(string));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                string col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    total_Computing++;
                }
                else if (col == "Multimedia Technology")
                {
                    total_MultimediaTechnology++;
                }
                else if (col == "Networks and IT Secuity")
                {
                    total_NetworksandITSecuity++;
                }

            }
            dt.Rows.Add("Computting", total_Computing);
            dt.Rows.Add("Multimedia Technology", total_MultimediaTechnology);
            dt.Rows.Add("Networks and IT Secuity", total_NetworksandITSecuity);
            grdReport.ItemsSource = dt.DefaultView;
        }

        private void btnTotalStd_Click(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = new DataSet();
            dataSet.ReadXml(@"D:\StudentInformationSystem\StudentReport.xml");
            DataTable dtStdReport = dataSet.Tables[0];

            int total_Computing = 0;
            int total_MultimediaTechnology = 0;
            int total_NetworksandITSecuity = 0;

            DataTable dt = new DataTable("newTable");
            dt.Columns.Add("CourseEnroll", typeof(string));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                string col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    total_Computing++;
                }
                else if (col == "Multimedia Technology")
                {
                    total_MultimediaTechnology++;
                }
                else if (col == "Networks and IT Secuity")
                {
                    total_NetworksandITSecuity++;
                }

            }
            dt.Rows.Add("Computting", total_Computing);
            dt.Rows.Add("Multimedia Technology", total_MultimediaTechnology);
            dt.Rows.Add("Networks and IT Secuity", total_NetworksandITSecuity);
            grdReport.ItemsSource = dt.DefaultView;
        }

        private void grdReport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            Chartt chartt = new Chartt();
            chartt.Show();
        }
    }

}
