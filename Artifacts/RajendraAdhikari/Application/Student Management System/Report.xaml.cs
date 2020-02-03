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

namespace Student_Management_System
{
    /// <summary>
    /// Interaction logic for ViewReport.xaml
    /// </summary>
    public partial class ViewReport : Page
    {
        Report report = new Report();
        List<Report> reportDetails = new List<Report>();
        int countJava = 0;
        int countPhython = 0;
        int countNetworking = 0;
        int countDatabase = 0;
        int countWordpress = 0;
        public ViewReport()
        {
            InitializeComponent();
        }
        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> resLines = new List<string>();
            var lines = File.ReadLines("studentDetails.csv");
            Report report = new Report();
            foreach (var line in lines)
            {
                var res = line.Split(new char[] { ',' } ,StringSplitOptions.RemoveEmptyEntries);
                if (res[5] == "Java")
                {
                    countJava++;
                    report.CourseName = "Java";
                    report.TotalStudents = Convert.ToInt32(countJava);
                }
            }
            reportDetails.Add(report);

            Report report2 = new Report();
            foreach (var line in lines)
            {
                var res = line.Split(new char[] { ',' });
                if (res[5] == "Python")
                {
                    countPhython++;
                    report2.CourseName = "Python";
                    report2.TotalStudents = Convert.ToInt32(countPhython);
                }
            }
            reportDetails.Add(report2);

            Report report3 = new Report();
            foreach (var line in lines)
            {
                var res = line.Split(new char[] { ',' });
                if (res[5] == "Networking")
                {
                    countNetworking++;
                    report3.CourseName = "Networking";
                    report3.TotalStudents = Convert.ToInt32(countNetworking);
                }
            }
            reportDetails.Add(report3);

            Report report4 = new Report();
            foreach (var line in lines)
            {
                var res = line.Split(new char[] { ',' });
                if (res[5] == "Database")
                {
                    countDatabase++;
                    report4.CourseName = "Database";
                    report4.TotalStudents = Convert.ToInt32(countDatabase);
                }
            }
            reportDetails.Add(report4);

            Report report5 = new Report();
            foreach (var line in lines)
            {
                var res = line.Split(new char[] { ',' });
                if (res[5] == "Wordpress")
                {
                    countWordpress++;
                    report5.CourseName = "Wordpress";
                    report5.TotalStudents = Convert.ToInt32(countWordpress);
                }
            }
            reportDetails.Add(report5);
            dg4th.ItemsSource = reportDetails;
        }
    }
}

