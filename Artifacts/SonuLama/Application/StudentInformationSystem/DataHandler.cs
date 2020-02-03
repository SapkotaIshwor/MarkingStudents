using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem
{
    class DataHandler
    {
        public DataSet CreateDataSet()
        {
            var ds = new DataSet();
            ds.Tables.Add(CreateStudentTable());
            return ds;
        }

        private DataTable CreateStudentTable()
        {
            var dt = new DataTable("Student");
            dt.Columns.Add("studentId", typeof(string));
            dt.Columns.Add("studentName", typeof(string));
            dt.Columns.Add("studentAddress", typeof(string));
            dt.Columns.Add("studentContact", typeof(string));
            dt.Columns.Add("courseEnrol", typeof(string));
            dt.Columns.Add("registrationDate", typeof(DateTime));
            return dt;
        }
    }
}
