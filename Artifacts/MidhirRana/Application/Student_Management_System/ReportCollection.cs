using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class ReportCollection : Collection<ChartData>
    {
        int countCP = 0;
        int countMT = 0;
        int countNIT = 0;
        public ReportCollection()
        {
            var csvData = System.IO.File.ReadAllText("studentDetails.csv");
            var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in lines)
            {
                var values = item.Split(',');
                if (values[6] == "Computing")
                {
                    countCP++;
                }
                else if (values[6] == "Multimedia Technologies")
                {
                    countMT++;
                }
                else if (values[6] == "Networks and IT Security")
                {
                    countNIT++;
                }
            }
           

            Add(new ChartData("COMP", countCP));
            Add(new ChartData("MT", countMT));
            Add(new ChartData("NIT", countNIT));

        }
    }
}
