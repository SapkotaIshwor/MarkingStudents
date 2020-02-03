using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem
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
                if (values[4] == "Application Development")
                {
                    countAD++;
                }
                else if (values[4] == "Advanced Database")
                {
                    countADB++;
                }
                else if (values[4] == "Artificial Intelligence")
                {
                    countAI++;
                }
            }
          

            Add(new ChartData("AI", countAI));
            Add(new ChartData("AD", countAD));
            Add(new ChartData("ADB", countADB));

        }

    }

}

