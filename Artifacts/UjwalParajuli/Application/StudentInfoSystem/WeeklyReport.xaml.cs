using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for WeeklyReport.xaml
    /// </summary>
    public partial class WeeklyReport : Page
    {
        List<Report> reportDetails = new List<Report>();
        int countAD = 0;
        int countAI = 0;
        int countADB = 0;
        public WeeklyReport()
        {
            InitializeComponent();
        }

        private void ButtonReport_Click(object sender, RoutedEventArgs e)
        {
            var csvData = System.IO.File.ReadAllText("studentDetails.csv");
            ReadFromCSV(csvData);
          
        }
        public List<Report> ReadFromCSV(string csvData)
        {
            Report report = new Report();
            Report report2 = new Report();
            Report report3 = new Report();
            try
            {
                //1st row contains property name so skipping the first row.
                var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    if(values[5] == "Application Development")
                    {
                        countAD++;
                        report.CourseName = "Application Development";
                        report.TotalStudents = Convert.ToInt32(countAD);
                    }
                    else if (values[5] == "Advanced Database")
                    {
                        countADB++;
                        report2.CourseName = "Advanced Database";
                        report2.TotalStudents = Convert.ToInt32(countADB);
                    }
                    else if (values[5] == "Artificial Intelligence")
                    {
                        countAI++;
                        report3.CourseName = "Artificial Intelligence";
                        report3.TotalStudents = Convert.ToInt32(countAI);
                    }
                }
                reportDetails.Add(report);
                reportDetails.Add(report2);
                reportDetails.Add(report3);
                dgFourth.ItemsSource = reportDetails;
                MessageBox.Show("Successfully Retrieved", "Success");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return reportDetails;
        }


    }
}
