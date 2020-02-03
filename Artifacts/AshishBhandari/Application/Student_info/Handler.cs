using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Student_info
{
    public class Handler
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
            //DataColumn dataColumn = new DataColumn("SN", typeof(int));
            //dataColumn.AutoIncrement = true;
            //dataColumn.AutoIncrementSeed = 1;
            //dataColumn.AutoIncrementStep = 1;

            //dt.Columns.Add(dataColumn);
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("StudentID", typeof(int));
            dt.Columns.Add("Department", typeof(string));
            dt.Columns.Add("Faculty", typeof(string));
            dt.Columns.Add("Program", typeof(string));
            dt.Columns.Add("Phone", typeof(int));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("CurrentAddress", typeof(string));
            dt.Columns.Add("PermanentAddress", typeof(string));
            dt.Columns.Add("Religion", typeof(string));
            dt.Columns.Add("Nationality", typeof(string));
            dt.Columns.Add("MaritalStatus", typeof(string));
            dt.Columns.Add("RegistrationDate", typeof(string));
            return dt;
        }

        private void AddSampleData(DataSet dataSet)
        {

           var dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = "Ashish Bhandari";
            dr["StudentID"] = 17031918;
            dr["Depaertment"] = "IT";
            dr["Faculty"] = "BIT";
            dr["Program"] = "Networking";
            dr["Phone"] =  986911390;
            dr["Email"] = "ashish@gmail.com";
            dr["Gender"] = "Male";
            dr["CurrentAddress"] = "Ratnachowk-07";
            dr["PermanentAddress"] = "Kalika-28";
            dr["Reiligion"] = "Hindu";
            dr["Nationality"] = "Nepali";
            dr["MarritalStatus"] = "Unmarried";
            dr["RegistrationDate"] = DateTime.Today;
            dataSet.Tables["Student"].Rows.Add(dr);
         
        }
    }
}
