using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class ChartData
    {
        public ChartData(string progName, int totalStudents)
        {
            this.progName = progName;
            this.totalStudents = totalStudents;
        }
        public string progName{ get; set; }
        public int totalStudents { get; set; }
    }
}
