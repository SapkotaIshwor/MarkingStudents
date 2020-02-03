﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Login2
{
    /// <summary>
    /// Interaction logic for viewChart.xaml
    /// </summary>
    public partial class viewChart : Page
    {
        public viewChart()
        {
            InitializeComponent();
            var dataset = new DataSet();
            dataset.ReadXml("StudentDetails.xml");
            DataTable stdReport = dataset.Tables[0];
            int total_AD = 0;
            int total_AI = 0;
            int total_Database = 0;

            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enroll", typeof(string));
            dt.Columns.Add("Total Students", typeof(int));

            for (int a = 0; a < stdReport.Rows.Count; a++)
            {
                string col = stdReport.Rows[a]["CourseName"].ToString();
                if (col == "Advance Database")
                {
                    total_Database++;
                }
                else if (col == "Application Development")
                {
                    total_AD++;
                }
                else if (col == "Artificial Intelligence")
                {
                    total_AI++;
                }
            }
            dt.Rows.Add("Application Development: ", total_AD);
            dt.Rows.Add("Artificial Intelligence: ", total_AI);
            dt.Rows.Add("Advance Database: ", total_Database);

            ((PieSeries)display_pie_chart).ItemsSource =
                new KeyValuePair<string, int>[]{
                new KeyValuePair<string,int>("Computing", total_AD),
                new KeyValuePair<string,int>("Network and IT Security", total_AI),
                new KeyValuePair<string,int>("Multimedia Technologies", total_Database) };
        }
    }
}
