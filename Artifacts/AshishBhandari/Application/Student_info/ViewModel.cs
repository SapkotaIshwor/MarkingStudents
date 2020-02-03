using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_info
{
    class ViewModel
    {
        string path = @"D:\Student_Management\StudentRegistrationData.xml";
        int ITData;
        int mgtData;
        int eduData;

        int ITData2;
        int mgtData2;
        int eduData2;
        public List<Sales> Data { get; set; }
        public ViewModel()
        {

            loadData();
            Data = new List<Sales>()
            {
                new Sales { Week=$"{DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy")}",ITA= ITData ,EducationB=eduData, ManagementC= mgtData},
                new Sales { Week=$"{DateTime.Now.AddDays(-14).ToString("dd/MM/yyyy")}",ITA= ITData2 ,EducationB=eduData2, ManagementC= mgtData2},
              
            };
        }
        private void loadData()
        {
            var handler = new Handler();

            var dataSet = handler.CreateDataSet();


            if (System.IO.File.Exists(path))
            {
                
                dataSet.ReadXml(path);

                DataTable stdReportTbl = dataSet.Tables["Student"];
                DataTable dv = stdReportTbl.Select("").CopyToDataTable();
                //filtering date of one week

                //counting total number of student registered in a week
                ITData = stdReportTbl.Select("Department = 'IT' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                mgtData = stdReportTbl.Select("Department = 'Management' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                eduData = stdReportTbl.Select("Department = 'Education' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();


                ITData2 = stdReportTbl.Select("Department = 'IT' AND RegistrationDate>='" + DateTime.Today.AddDays(-14) + "'").Count<DataRow>();
                mgtData2 = stdReportTbl.Select("Department = 'Management' AND RegistrationDate>='" + DateTime.Today.AddDays(-14) + "'").Count<DataRow>();
                eduData2 = stdReportTbl.Select("Department = 'Education' AND RegistrationDate>='" + DateTime.Today.AddDays(-14) + "'").Count<DataRow>();


            }

        }

      
    }
}
