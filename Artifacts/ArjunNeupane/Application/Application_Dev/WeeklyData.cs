using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Dev
{
    public class WeeklyData
    {
        public WeeklyData()
        { 
        }

        public WeeklyData(string course, int total)
        {
            Course = course;
            Total = total;
        }

        public string Course { get; set; }


        public int Total { get; set; }
    }
}
