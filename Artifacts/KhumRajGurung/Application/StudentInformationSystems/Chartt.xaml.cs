using DataHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInformationSystems
{
    /// <summary>
    /// Interaction logic for Chartt.xaml
    /// </summary>
    public partial class Chartt : Window
    {
        public Chartt()
        {
            InitializeComponent();

            var handler = new Handler();
            var dataSet = new DataSet();
            dataSet.ReadXml(@"C:\Informatics\Coursework\Application Development\StudentReport.xml");
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

            ((BarSeries) totalChart.Series[0]).ItemsSource = new KeyValuePair<string, int>[] {
                new KeyValuePair<string, int>("Computting", total_Computing),
            new KeyValuePair<string, int>("Multimedia Technology", total_MultimediaTechnology),
            new KeyValuePair<string, int>("Networks and IT Secuity", total_NetworksandITSecuity)
    };
        }
    }
}
