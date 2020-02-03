using System;
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
using System.Windows.Shapes;

namespace ApplicationDevelopmentCW
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : Window
    {

        public KeyValuePair<string, int>[] ItemsSource { get; private set; }

        public Chart()
        {
            InitializeComponent();

        }
        private void btnChart_click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"G:\student.xml");
            DataTable dtStudentReport = dataSet.Tables[0];

            int total_Computing = 0;
            int total_Networking = 0;
            int total_Multimedia = 0;

            DataTable dt = new DataTable("newTable");
            dt.Columns.Add("Course Enroll", typeof(string));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStudentReport.Rows.Count; i++)
            {
                string col = dtStudentReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    total_Computing++;
                }
                else if (col == "Networking")
                {
                    total_Networking++;
                }
                else if (col == "Multimedia")
                {
                    total_Multimedia++;
                }

            }
            dt.Rows.Add("computing", total_Computing);
            dt.Rows.Add("Networking", total_Networking);
            dt.Rows.Add("Multimedia", total_Multimedia);
            DataChartGrid.DataContext = dt.DefaultView;

        }

        private void btnPieChart_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            LoadPieChartData();
        }


        public void LoadPieChartData()
        {
            var dataSet = new DataSet();
            if (System.IO.File.Exists(@"G:\student.xml"))
            {
                dataSet.ReadXml(@"G:\student.xml");


                DataTable dtStdReport = dataSet.Tables[0];

                int Total_Computing = 0;
                int Total_Networking = 0;
                int Total_Multimedia = 0;

                DataTable Week = new DataTable("WeekTable1");
                Week.Columns.Add("Courses Enrolled", typeof(String));
                Week.Columns.Add("Overall Student", typeof(int));


                for (int i = 0; i < dtStdReport.Rows.Count; i++)
                {

                    String column = dtStdReport.Rows[i]["CourseEnroll"].ToString();

                    if (column == "Computing")
                    {
                        Total_Computing++;

                    }
                    else if (column == "Networking")
                    {
                        Total_Networking++;

                    }
                    else if (column == "Multimedia")
                    {
                        Total_Multimedia++;

                    }
                }
                Week.Rows.Add("BBA", Total_Computing);
                Week.Rows.Add("BE_IT", Total_Networking);
                Week.Rows.Add("BBS", Total_Multimedia);

                ((PieSeries) chartEnroll).ItemsSource = new KeyValuePair<string, int>[]{
                        new KeyValuePair<string,int>("Computing", Total_Computing),
                        new KeyValuePair<string,int>("Networking", Total_Networking),
                        new KeyValuePair<string,int>("Multimedia", Total_Multimedia)};

                             }
            else
            {
                MessageBox.Show("No data to show!");
            }

        }

        
    }
    }

