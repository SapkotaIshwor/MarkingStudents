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
        Report report = new Report();
        List<Report> reportDetails = new List<Report>();
        int countAD = 0;
        int countLogic = 0;
        int countProgramming = 0;
        public WeeklyReport()
        {
            InitializeComponent();
        }

        private void ButtonReport_Click(object sender, RoutedEventArgs e)
        {
            List<string> resLines = new List<string>();
            var lines = File.ReadLines("studentDetails.csv");
            Report[] report = new Report[3];

            foreach (var line in lines)
            {
                var res = line.Split(new char[] { ',' });

                if (res[5] == "Application Development")
                {
                    countAD++;
                } else if (res[5] == "Programming")
                {
                    countProgramming++;
                }
                else if (res[5] == "Logic and Problem Solving")
                {
                    countLogic++;
                }
            }

            for(int i = 0; i < 3; i++)
            {
                report[i] = new Report();
            }

            report[0].CourseName = "Application Development";
            report[0].TotalStudents = Convert.ToInt32(countAD);

            report[1].CourseName = "Programming";
            report[1].TotalStudents = Convert.ToInt32(countProgramming);

            report[2].CourseName = "Logic and Problem Solving";
            report[2].TotalStudents = Convert.ToInt32(countLogic);

            for (int i = 0; i < 3; i++)
            {
                reportDetails.Add(report[i]);
            }

            

                      
            dgFourth.ItemsSource = reportDetails;
            }
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> resLines = new List<string>();
            var lines = File.ReadLines("studentDetails.csv");
            Report report = new Report();
            foreach (var line in lines)
            {

            }
        }*/
    }
