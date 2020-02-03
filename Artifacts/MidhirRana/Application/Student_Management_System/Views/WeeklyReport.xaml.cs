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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Management_System.Views
{
    /// <summary>
    /// Interaction logic for WeeklyReport.xaml
    /// </summary>
    public partial class WeeklyReport : UserControl
    {
        List<Report> reportDetails = new List<Report>();
        int countCP = 0;
        int countMT = 0;
        int countNIT = 0;
        public WeeklyReport()
        {
            InitializeComponent();
        }

        private void ViewWeeklyReport_Click(object sender, RoutedEventArgs e)
        {
            var csvData = System.IO.File.ReadAllText("studentDetails.csv");
            ReadFromCSV(csvData);
        }

        public List<Report> ReadFromCSV(string csvData)
        {
            Report report = new Report();
            Report report2 = new Report();
            Report report3 = new Report();
            //List<Student> studentDetails = new List<Student>();
            try
            {
                //1st row contains property name so skipping the first row.
                var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    if (values[6] == "Computing")
                    {
                        countCP++;
                        report.ProgrammeName = "Computing";
                        report.TotalStudents = Convert.ToInt32(countCP);
                    }
                    else if (values[6] == "Multimedia Technologies")
                    {
                        countMT++;
                        report2.ProgrammeName = "Multimedia Technologies";
                        report2.TotalStudents = Convert.ToInt32(countMT);
                    }
                    else if (values[6] == "Networks and IT Security")
                    {
                        countNIT++;
                        report3.ProgrammeName = "Networks and IT Security";
                        report3.TotalStudents = Convert.ToInt32(countNIT);
                    }
                 
                }
                reportDetails.Add(report);
                reportDetails.Add(report2);
                reportDetails.Add(report3);
                WeeklyGridView.ItemsSource = reportDetails;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return reportDetails;
        }
    }
}
