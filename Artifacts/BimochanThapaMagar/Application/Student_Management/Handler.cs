using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management
{
    public class Handler
    {
        public DataSet GenerateDataSet()
        {
            var dataset = new DataSet();
            dataset.Tables.Add(GenerateStdTable());
            return dataset;
        }


        private DataTable GenerateStdTable()
        {
            var dt = new DataTable("StudentInfo");
            dt.Columns.Add("StudentID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
          
            dt.Columns.Add("StudentPhone", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Program", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("RegistrationDate", typeof(string));
            return dt;
        }

        private void AddSampleData(DataSet dataSet)
        {

            var dr = dataSet.Tables["StudentInfo"].NewRow();
            dr["StudentID"] = "1";
            dr["Name"] = "Yaman Thapa";
            dr["Program"] = "Computing";
            dr["ParentName"] = "a";
            dr["ParentPhone"] = "12";
            dr["StudentPhone"] = "12";
            dr["Email"] = "yaman@gmail.com";
            dr["Gender"] = "Male";
            dr["Address"] = "Nayabazar-28";
            dr["RegistrationDate"] = DateTime.Today;
            dataSet.Tables["StudentInfo"].Rows.Add(dr);

        }
    }

}
