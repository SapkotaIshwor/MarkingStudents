using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System
{
    public class ChartGetSet
    {
        public ChartGetSet(string cEnrolledName, int totalStudentsEnrolled)
        {
            this.cEnrolledName = cEnrolledName;
            this.totalStudentsEnrolled = totalStudentsEnrolled;
        }
        public string cEnrolledName { get; set; }
        public int totalStudentsEnrolled { get; set; }
    }
}
