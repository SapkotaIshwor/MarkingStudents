using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;

namespace Student_Information_System
{
    class ChartData
    {
        public ChartData(string CourseName, int TotalStudents)    // Constructor
        {
            this.CourseName = CourseName;
            this.TotalStudents = TotalStudents;
        }
        public string CourseName                // Name Property
        {
            get;
            set;
        }
        public long TotalStudents                // Population Property
        {
            get;
            set;
        }
    }
}
