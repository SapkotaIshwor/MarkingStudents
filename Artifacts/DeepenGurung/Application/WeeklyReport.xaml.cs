using System;
using System.Collections.Generic;
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

namespace StudentInformationSystem
{
    public partial class WeeklyReport : Page
    {
        Report report = new Report();
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
            List<string> resLines = new List<string>();
            var lines = File.ReadLines("studentDetails.csv");
            Report report = new Report();
            foreach (var line in lines)
            {
                //here I suppose that your csv file it like this 
                // 1,Peter,USA,12345
                // 2,Anna,UK,45678
                var res = line.Split(new char[] { ',' } ,StringSplitOptions.RemoveEmptyEntries);
                //or name to search 
                if (res[4] == "Application Development")
                {
                    countAD++;
                    report.CourseName = "Application Development";
                    report.TotalStudents = Convert.ToInt32(countAD);
                }
            }
            reportDetails.Add(report);

            Report report2 = new Report();
            foreach (var line in lines)
            {
                var res = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                //or name to search 
                if (res[4] == "Artificial Intelligence")
                {
                    countAI++;
                    report2.CourseName = "Artificial Intelligence";
                    report2.TotalStudents = Convert.ToInt32(countAI);
                }
            }
            reportDetails.Add(report2);
            
            
            Report report3 = new Report();
            foreach (var line in lines)
            {
                var res = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                //or name to search 
                if (res[4] == "Advanced Database")
                {
                    countADB++;
                    report3.CourseName = "Advanced Database";
                    report3.TotalStudents = Convert.ToInt32(countADB);
                }
            }
            reportDetails.Add(report3);

            datagrid4.ItemsSource = reportDetails;
        }

    }
}
