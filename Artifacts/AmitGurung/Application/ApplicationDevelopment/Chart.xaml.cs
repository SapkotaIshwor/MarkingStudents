using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;


namespace ApplicationDevelopment
{

    public partial class Chart : Window
    {
        public Chart()
        {
            InitializeComponent();
            showPieChart();
  
        }
        
        private void showPieChart()
        {
            var dataset = new DataSet();
            dataset.ReadXml("Student Report/StudentReport.xml");

            DataTable dataTable = dataset.Tables["StudentReport"];

            int total_Com = 0;
            int total_Mul = 0;
            int total_Net = 0;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                String col = dataTable.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    total_Com++;
                }
                else if (col == "Multimedia Technologies")
                {
                    total_Mul++;
                }
                else if (col == "Networks and IT Security")
                {
                    total_Net++;
                }
            }

            ((PieSeries)pieChart).ItemsSource = new KeyValuePair<string, int>[]{
                                                new KeyValuePair<string,int>("Computing", total_Com),
                                                new KeyValuePair<string,int>("Multimedia Technologies", total_Mul),
                                                new KeyValuePair<string,int>("Networks and IT Security", total_Net) }; 
        }
    }
}
