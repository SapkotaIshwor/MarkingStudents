using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Student_Information_System
{
    [Serializable()]
    class StudentDetails : ISerializable
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentAddress { get; set; }
        public string StudentPhone { get; set; }
        public string CourseEnrolled { get; set; }
        public DateTime RegistrationDate { get; set; }

        public StudentDetails() { }

        public StudentDetails(int studentID, string studentName, string studentAddress, string studentPhone, string courseEnrolled, DateTime regDate)
        {
            StudentID = studentID;
            StudentName = studentName;
            StudentAddress = studentAddress;
            StudentPhone = studentPhone;
            CourseEnrolled = courseEnrolled;
            RegistrationDate = regDate;

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", StudentID);
            info.AddValue("Name", StudentName);
            info.AddValue("Address", StudentAddress);
            info.AddValue("Phone", StudentPhone);
            info.AddValue("CourseEnrolled", CourseEnrolled);
            info.AddValue("RegistrationDate", RegistrationDate);
        }

        public StudentDetails(SerializationInfo info, StreamingContext context)
        {
            //Get the values from info and assign them to the properties
            StudentID = (int)info.GetValue("ID", typeof(int));
            StudentName = (string)info.GetValue("Name", typeof(string));
            StudentAddress = (string)info.GetValue("Address", typeof(string));
            StudentPhone = (string)info.GetValue("Phone", typeof(string));
            CourseEnrolled = (string)info.GetValue("CourseEnrolled", typeof(string));
            RegistrationDate = (DateTime)info.GetValue("RegistrationDate", typeof(DateTime));
        }
    }
}
