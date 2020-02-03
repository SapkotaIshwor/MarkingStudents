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

namespace studentManagement
{
    /// <summary>
    /// Interaction logic for weeklyReport.xaml
    /// </summary>
    public partial class weeklyReport : Page
    {
        Report report = new Report();
        List<Report> reportDetails = new List<Report>();
        int countAD = 0;
        int countAI = 0;
        int countADB = 0;
        public weeklyReport()
        {
            InitializeComponent();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> resLines = new List<string>();
            var lines = File.ReadLines("studentDetails.csv");
            Report report = new Report();
            Report report2 = new Report();
            Report report3 = new Report();

            foreach (var line in lines)
            {


                
                var res = line.Split(new char[] { ',' } ,StringSplitOptions.RemoveEmptyEntries);
                //or name to search 
                if (res[4] == "Application Development")
                {
                    countAD++;
                    report.CourseName = "Application Development";
                    report.TotalStudents = Convert.ToInt32(countAD);



                }
                
                 else if (res[4] == "Advanced Database")
                {
                    countADB++;
                    report3.CourseName = "Advanced Database";
                    report3.TotalStudents = Convert.ToInt32(countADB);

                }

                else if (res[4] == "Artifical Intelligence")
                {
                    countAI++;
                    report2.CourseName = "Artifical Intelligence";
                    report2.TotalStudents = Convert.ToInt32(countAI);

                }

            }



            reportDetails.Add(report);
            reportDetails.Add(report2);
            reportDetails.Add(report3);

            //Report report2 = new Report();
            //foreach (var line in lines)
            //{
            //    var res = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    //or name to search 
            //    if (res[4] == "Artificial Intelligence")
            //    {
            //        countAI++;
            //        report2.CourseName = "Artificial Intelligence";
            //        report2.TotalStudents = Convert.ToInt32(countAI);

            //    }
            //}

            //reportDetails.Add(report2);

            //Report report3 = new Report();
            //foreach (var line in lines)
            //{
            //    var res = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    //or name to search 
            //    if (res[4] == "Advanced Database")
            //    {
            //        countADB++;
            //        report3.CourseName = "Advanced Database";
            //        report3.TotalStudents = Convert.ToInt32(countADB);

            //    }
            //}

            //reportDetails.Add(report3);

            datagridFour.ItemsSource = reportDetails;


        }
    }
}
