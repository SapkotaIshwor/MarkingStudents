using System.Data;

namespace DataHandler
{
    public class Handler
    {
        public DataSet CreateDataSet()
        {
            var dataSet = new DataSet();           
            dataSet.Tables.Add(CreateStudentTable());
            dataSet.Tables.Add(StudentReportTable());

            return dataSet;
        }

        private DataTable CreateStudentTable()
        {
            var dataTable = new DataTable("Student");
            DataColumn dataColumn = new DataColumn("ID", typeof(int));
            dataColumn.AutoIncrement = true;
            dataColumn.AutoIncrementSeed = 1;
            dataColumn.AutoIncrementStep = 1;

            dataTable.Columns.Add(dataColumn);

            dataTable.Columns.Add("RegistrationNo", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("ContactNo", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("CourseEnroll", typeof(string));
            dataTable.Columns.Add("RegistrationDate", typeof(string));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ID"] };
            return dataTable;
        }

        private DataTable StudentReportTable()
        {
            var dataTable = new DataTable("StudentReport");
            DataColumn dataColumn = new DataColumn("ID", typeof(int));
            dataColumn.AutoIncrement = true;
            dataColumn.AutoIncrementSeed = 1;
            dataColumn.AutoIncrementStep = 1;

            dataTable.Columns.Add(dataColumn);

            dataTable.Columns.Add("RegistrationNo", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("ContactNo", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("CourseEnroll", typeof(string));
            dataTable.Columns.Add("RegistrationDate", typeof(string));

            return dataTable;
        }

    }
}
