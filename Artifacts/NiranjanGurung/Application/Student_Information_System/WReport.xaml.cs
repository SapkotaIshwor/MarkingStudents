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

namespace Student_Information_System
{
    /// <summary>
    /// Interaction logic for WReport.xaml
    /// </summary>
    /// 
   
    public partial class WReport : Window
    {
        List<ReportGetSet> reportGetSet= new List<ReportGetSet>();
        int countAD = 0;
        int countADB = 0;
        int countAI = 0;
        int countWRL = 0;
        public WReport()
        {
            InitializeComponent();
        }
        private void btnViewWeeklyReport_click(object sender, RoutedEventArgs e)
        {
            var csvData = System.IO.File.ReadAllText("studentDetails.csv");
            ReadFromCSV(csvData);

        }

        public List<ReportGetSet> ReadFromCSV(string csvData)
        {
            ReportGetSet report = new ReportGetSet();
            ReportGetSet report2 = new ReportGetSet();
            ReportGetSet report3 = new ReportGetSet();
            ReportGetSet report4 = new ReportGetSet();
            //List<Student> studentDetails = new List<Student>();
            try
            {
                //1st row contains property name so skipping the first row.
                var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    if (values[4] == "Application Development")
                    {
                        countAD++;
                        report.courseEnroll = "Application Development";
                        report.totalStudents = Convert.ToInt32(countAD);
                    }
                    else if (values[4] == "Artificial Intelligence")
                    {
                        countADB++;
                        report3.courseEnroll = "Artificial Intelligence";
                        report3.totalStudents = Convert.ToInt32(countADB);
                    }
                    else if (values[4] == "Advanced Database")
                    {
                        countAI++;
                        report2.courseEnroll = "Advanced Database";
                        report2.totalStudents = Convert.ToInt32(countAI);
                    }
                   
                    else if (values[4] == "Work Related Learning")
                    {
                        countWRL++;
                        report4.courseEnroll = "Work Related Learning";
                        report4.totalStudents = Convert.ToInt32(countWRL);
                    }

                   
                }
                reportGetSet.Add(report);
                reportGetSet.Add(report2);
                reportGetSet.Add(report3);
                reportGetSet.Add(report4);
                DGWeeklyReport.ItemsSource = reportGetSet;
                MessageBox.Show("Successfully Retrieved", "Success");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return reportGetSet;
        }
    }
}
