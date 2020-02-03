using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System
{
    public class FinalReportCollection : Collection<ChartGetSet>
    {
        int countAD = 0;
        int countAI = 0;
        int countADB = 0;
        int countWRL = 0;
        public FinalReportCollection()
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
                else if (values[4] == "Artificial Intelligence")
                {
                    countAI++;
                }
                else if (values[4] == "Advanced Database")
                {
                    countADB++;
                }
                else if (values[4] == "Work Related Learning")
                {
                    countWRL++;
                }


            }
           
            Add(new ChartGetSet("AD", countAD));
            Add(new ChartGetSet("ADB", countADB));
            Add(new ChartGetSet("AI", countAI));
            Add(new ChartGetSet("WRL", countWRL));
           

        }

    }
}
