using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System
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
            var dt = new DataTable("StudentRegistrationDetails");
            dt.Columns.Add("studentRegistrationID", typeof(string));
            dt.Columns.Add("studentFullname", typeof(string));
            dt.Columns.Add("studentAddress", typeof(string));
            dt.Columns.Add("studentContact", typeof(string));
            dt.Columns.Add("studentCourseEnroll", typeof(string));
            dt.Columns.Add("studentRegistrationDate", typeof(string));
            return dt;
        }
    }
}
