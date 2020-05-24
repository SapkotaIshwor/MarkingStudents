using System;
using System.Data;

namespace DataHandler
{
    public class Handler
    {
        public DataSet CreateDataSet()
        {
            var ds = new DataSet();
            
            ds.Tables.Add(CreateStudentInfoTable());
            ds.Tables.Add(CreateStudentReport());
            return ds;
        }

        private DataTable CreateStudentInfoTable()
        {
            var dt = new DataTable("StudentInfo");
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("CourseEnroll", typeof(string));
            dt.Columns.Add("RegistrationDate",typeof(DateTime));
            return dt;
        }

        private DataTable CreateStudentReport()
        {
            var dt = new DataTable("StudentReport");
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("CourseEnroll", typeof(string));
            dt.Columns.Add("RegistrationDate", typeof(DateTime));
            return dt;
        }
    }
}
