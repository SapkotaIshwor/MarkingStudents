using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Student_Information_System
{
    /// <summary>
    /// Interaction logic for WeeklyReport.xaml
    /// </summary>
    /// 

    

    public partial class WeeklyReport : UserControl
    {
        private FileHandler filehandler = new FileHandler();
        ObservableCollection<StudentDetails> students;
        private IDictionary<string, int> studentCounter = new Dictionary<string, int>();
        public WeeklyReport()
        {
            InitializeComponent();
            fillTable();
        }

        public void countStudents()
        {
            students = filehandler.getData();
            studentCounter["Computing"] = studentCounter["Multimedia"] = studentCounter["Programming"] = 0;

            for (int i = 0; i < students.Count; i++)
            {
                switch (students[i].CourseEnrolled)
                {
                    case "Computing":
                        studentCounter["Computing"]++;
                        break;
                    case "Multimedia":
                        studentCounter["Multimedia"]++;
                        break;
                    case "Programming":
                        studentCounter["Programming"]++;
                        break;
                }
            }
        }

        public void fillTable()
        {
            countStudents();

            courseCountTable.Items.Add(new { CourseName = "Computing", StudentsCount = studentCounter["Computing"] });
            courseCountTable.Items.Add(new { CourseName = "Multimedia", StudentsCount = studentCounter["Multimedia"] });
            courseCountTable.Items.Add(new { CourseName = "Programming", StudentsCount = studentCounter["Programming"] });
        }
    }
}
