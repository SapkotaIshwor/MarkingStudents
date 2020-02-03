using System;
using System.Data;

namespace DataHandler
{
    public class Handler
    {
        public DataSet CreateDataSet()
        {
            var ds = new DataSet();
            //ds.Tables.Add(CreateCourseTable());            
            ds.Tables.Add(CreateStudentTable());
           // ds.Tables.Add(CreateStudentReportTable());
            
            //ForeignKeyConstraint courseWorkFK = new ForeignKeyConstraint("courseWorkFK",
            //ds.Tables["Course"].Columns["ID"],
            //ds.Tables["Student"].Columns["CourseEnroll"]);
            //courseWorkFK.DeleteRule = Rule.None;
            //ds.Tables["Student"].Constraints.Add(courseWorkFK);
            return ds;
        }

        private DataTable CreateStudentTable()
        {
            var dt = new DataTable("Student");
            DataColumn dataColumn = new DataColumn("ID", typeof(int));
            dataColumn.AutoIncrement = true;
            dataColumn.AutoIncrementSeed = 1;
            dataColumn.AutoIncrementStep = 1;

            dt.Columns.Add(dataColumn);

            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("ContactNo", typeof(string));
            dt.Columns.Add("CourseEnroll", typeof(string));
            dt.Columns.Add("RegistrationDate", typeof(DateTime));
            //dt.Columns.Add("PermanentAddress", typeof(string));
            //dt.Columns.Add("ParentsName", typeof(string));
            //dt.Columns.Add("ParentsContact", typeof(string));
            //dt.Columns.Add("", typeof(string));
            //dt.Columns.Add("Address", typeof(string));
            //dt.Columns.Add("Address", typeof(string));
            //dt.Columns.Add("Address", typeof(string));
            
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
            return dt;
        }

        //private DataTable CreateCourseTable()
        //{
        //    var dt = new DataTable("Course");
        //    DataColumn dataColumn = new DataColumn("ID", typeof(int));
        //    dataColumn.AutoIncrement = true;
        //    dataColumn.AutoIncrementSeed = 1;
        //    dataColumn.AutoIncrementStep = 1;
        //    dt.Columns.Add(dataColumn);

        //    dt.Columns.Add("Name", typeof(string));
        //    dt.Columns.Add("DisplayText", typeof(string));
        //   // dt.Columns.Add("CourseDuration", typeof(string));
           
        //    dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
        //    return dt;
        //}

        //private DataTable CreateStudentReportTable()
        //{
        //    var dt = new DataTable("StudentReport");
        //    DataColumn dataColumn = new DataColumn("ID", typeof(int));
        //    dataColumn.AutoIncrement = true;
        //    dataColumn.AutoIncrementSeed = 1;
        //    dataColumn.AutoIncrementStep = 1;

        //    dt.Columns.Add(dataColumn);

        //    dt.Columns.Add("RegNo", typeof(string));
        //    dt.Columns.Add("Name", typeof(string));
        //    dt.Columns.Add("Email", typeof(string));
        //    dt.Columns.Add("Address", typeof(string));
        //    dt.Columns.Add("ContactNo", typeof(string));
        //    dt.Columns.Add("CourseEnroll", typeof(string));
        //    dt.Columns.Add("RegistrationDate", typeof(DateTime));
           

        //    //dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
        //    return dt;
        //}
    }
}
