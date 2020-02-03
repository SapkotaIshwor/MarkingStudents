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
using System.Windows.Shapes;
using System.Xml;


namespace Application_Dev
{

    public partial class WeeklyTable : Window
    {
        string xmlPath = System.IO.Path.Combine(Environment.CurrentDirectory, "studentCWData.xml");

        public WeeklyTable()
        {
            InitializeComponent();
            var data = readData();
            weeklyReport.ItemsSource = data;
        }


        public List<WeeklyData> readData()
        {
            string fileName = xmlPath;
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Student Info file doesn't exist");
            }
            List<StudentInfo> students = new List<StudentInfo>();   
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/NewDataSet/Student");
            foreach (XmlNode node in nodeList)
            {
                var studentInfo = new StudentInfo(node);
                students.Add(studentInfo);
            }
            int ComputingTotal = 0;
            int multiMediaTotal = 0;
            int networkingTotal = 0;
            foreach (StudentInfo info in students) {
                if (info.ProgramEnrolled == "Computing") {
                    ComputingTotal++;
                }
                if (info.ProgramEnrolled == "Multimedia Technologies")
                {
                    multiMediaTotal++;
                }
                if (info.ProgramEnrolled == "Networks and IT Security")
                {
                    networkingTotal++;
                }
            }

            List<WeeklyData> weeklyDatas = new List<WeeklyData>();
            weeklyDatas.Add(new WeeklyData("Computing", ComputingTotal));
            weeklyDatas.Add(new WeeklyData("Multimedia Technologies", multiMediaTotal));
            weeklyDatas.Add(new WeeklyData("Networks and IT Security", networkingTotal));

            return weeklyDatas;

        }
    }
}
