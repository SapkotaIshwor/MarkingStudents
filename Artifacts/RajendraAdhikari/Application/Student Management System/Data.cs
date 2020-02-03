using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Data
    {
        public Data(string subName, int total)
        {
            this.subName = subName;
            this.total = total;
        }

        public string subName { get; set; }

        public int total { get; set; }
    }
}
