using DataHandler;
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
        string xmlPath = System.IO.Path.Combine(Environment.CurrentDirectory, "studentCWData.xml");

        int computing;
        int mt;
        int nis;

        int computing2;
        int mt2;
        int nis2;
        public List<Program> Data { get; set; }
        public ViewModel()
        {

            loadData();
            Data = new List<Program>()
            {
                 new Program { Week=$"{DateTime.Now.AddDays(-14).ToString("dd/MM/yyyy")}",Computing= computing2 ,MT=mt2, NIS= nis2},

            };
        }
        private void loadData()
        {
            var handler = new Handler();

            var dataSet = handler.CreateDataSet();


            if (System.IO.File.Exists(xmlPath))
            {


                dataSet.ReadXml(xmlPath);

                DataTable stdReportTbl = dataSet.Tables["Student"];
                DataTable dv = stdReportTbl.Select("").CopyToDataTable();
                //filtering date of one week

                //counting total number of student registered in a week
                computing = stdReportTbl.Select("CourseEnroll = 'Computing' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                mt = stdReportTbl.Select("CourseEnroll = 'Multimedia Technologies' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                nis = stdReportTbl.Select("CourseEnroll = 'Networks and IT Security' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();


                computing2 = stdReportTbl.Select("CourseEnroll = 'Computing' AND RegistrationDate>='" + DateTime.Today.AddDays(-14) + "'").Count<DataRow>();
                mt2 = stdReportTbl.Select("CourseEnroll = 'Multimedia Technologies' AND RegistrationDate>='" + DateTime.Today.AddDays(-14) + "'").Count<DataRow>();
                nis2 = stdReportTbl.Select("CourseEnroll = 'Networks and IT Security' AND RegistrationDate>='" + DateTime.Today.AddDays(-14) + "'").Count<DataRow>();


            }

        }


    }
}