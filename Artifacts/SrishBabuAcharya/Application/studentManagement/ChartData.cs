using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement
{
    public class ChartData
    {
        public ChartData(string cName, int tStudents)
        {
            this.cName = cName;
            this.tStudents = tStudents;
        }
        public string cName { get; set; }
        public int tStudents { get; set; }
    }
}