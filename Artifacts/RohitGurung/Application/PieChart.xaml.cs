using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;

namespace CWAD
{
    /// <summary>
    /// Interaction logic for PieChart.xaml
    /// </summary>
    public partial class PieChart : Page
    {
        public PieChart()
        {
            InitializeComponent();

            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(@"StudentDetails.xml");

                DataTable studentDataReport = dataSet.Tables[0];

                int application = 0;
                int artificial = 0;
                int database = 0;

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Course", typeof(String));
                dataTable.Columns.Add("Total", typeof(int));

                for (int i = 0; i < studentDataReport.Rows.Count; i++)
                {
                    String course = studentDataReport.Rows[i]["StudentCourse"].ToString();
                    if (course == "Application Development")
                    {
                        application++;
                    }
                    else if (course == "Artificial Intelligence")
                    {
                        artificial++;
                    }
                    else if (course == "Advanced Database")
                    {
                        database++;
                    }
                }

                dataTable.Rows.Add("Application Development", application);
                dataTable.Rows.Add("Artificial Intelligence", artificial);
                dataTable.Rows.Add("Advanced Database", database);

                ((PieSeries)display_pie_chart).ItemsSource =
                new KeyValuePair<string, int>[]{
                new KeyValuePair<string,int>("Application Development", application),
                new KeyValuePair<string,int>("Advance Database", database),
                new KeyValuePair<string,int>("Artificial Intelligence", artificial) };
            }
            catch
            {
                MessageBox.Show("No xml file is created to get data from, and show in the Pie Chart.", "Xml file not created!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
    }
}
