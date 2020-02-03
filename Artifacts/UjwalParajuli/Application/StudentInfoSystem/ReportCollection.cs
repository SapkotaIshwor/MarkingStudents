using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentInfoSystem
{
    public class ReportCollection : Collection<ChartData>
    {
        int countAD = 0;
        int countAI = 0;
        int countADB = 0;
        public ReportCollection()
        {
            var csvData = System.IO.File.ReadAllText("studentDetails.csv");
            var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in lines)
            {
                var values = item.Split(',');
                if (values[5] == "Application Development")
                {
                    countAD++;
                }
                else if (values[5] == "Advanced Database")
                {
                    countADB++;
                }
                else if (values[5] == "Artificial Intelligence")
                {
                    countAI++;
                }
            }

            Add(new ChartData("Artificial Intelligence", countAI));
            Add(new ChartData("Application Development", countAD));
            Add(new ChartData("Advanced Database", countADB));

        }

    }
    
}
