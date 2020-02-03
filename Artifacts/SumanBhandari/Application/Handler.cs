using System;
using System.Data;

namespace DataHandler
{
    class datahandler
    {
        //this method is used to design xml file by adding tags for xml
        public DataSet CreateDataSet()
        {
            var ds = new DataSet();
            ds.Tables.Add(CreateCourseTable());
            ds.Tables.Add(CreateStudentTable());        
            return ds;
        }
        //this method is used to design student table 
        private DataTable CreateStudentTable()
        {
            var dt = new DataTable("Student");         
            dt.Columns.Add("stdId", typeof(string));
            dt.Columns.Add("firstname", typeof(string));
            dt.Columns.Add("lastname", typeof(string));
            dt.Columns.Add("gender", typeof(string));
            dt.Columns.Add("ContactNo", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("CourseEnroll", typeof(string));
            dt.Columns.Add("zone", typeof(string));
            dt.Columns.Add("District", typeof(string));
            dt.Columns.Add("Tole", typeof(string));
            dt.Columns.Add("guardianNo", typeof(string));
            dt.Columns.Add("RegistrationDate", typeof(DateTime));          
            return dt;
        }

        //this method is used to design course table
        private DataTable CreateCourseTable()
        {
            var dt = new DataTable("Course");
            DataColumn dataColumn = new DataColumn("ID", typeof(int));
            dataColumn.AutoIncrement = true;
            dataColumn.AutoIncrementSeed = 1;
            dataColumn.AutoIncrementStep = 1;
            dt.Columns.Add(dataColumn);

            dt.Columns.Add("CourseName", typeof(string));
            dt.Columns.Add("CreditHours", typeof(string));
            dt.Columns.Add("CourseFee", typeof(string));         
            return dt;
        }
    }
}
