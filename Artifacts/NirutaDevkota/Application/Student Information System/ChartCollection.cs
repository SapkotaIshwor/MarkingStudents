using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;

namespace Student_Information_System
{
    class ChartCollection : Collection<ChartData>
    {

        public ChartCollection()
        {

            var dataSet = new DataSet();
            dataSet.ReadXml(@"D:\student.xml");

            DataTable studentReport = dataSet.Tables[0];


            int total_Computing = 0;
            int total_Network = 0;
            int total_Multimedia = 0;

            DataTable dataTable = new DataTable("table");
            dataTable.Columns.Add("Course Enroll", typeof(String));
            dataTable.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < studentReport.Rows.Count; i++)
            {
                String col = studentReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    total_Computing++;
                }
                else if (col == "Networks and IT Security")
                {
                    total_Network++;
                }
                else if (col == "Multimedia Technologies")
                {
                    total_Multimedia++;
                }
            }

            Add(new ChartData("Multimedia Technologies", total_Multimedia));
            Add(new ChartData("Networks and IT Security", total_Network));
            Add(new ChartData("Computing", total_Computing));
           
            

    }
    }
}

                 





