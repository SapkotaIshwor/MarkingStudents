using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Infromation_System
{

     public class StudentDetails
     {
        public StudentDetails() { }

        public StudentDetails(string std_ID, string std_Name, string std_Address, string std_Contact, string std_Course, string std_Registration_Date)
        {
            StudentID = std_ID;
            StudentName = std_Name;
            StudentAddress = std_Address;
            StudentContact = std_Contact;
            Course = std_Course;
            RegistrationDate = std_Registration_Date;
        }

        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentAddress { get; set; }
        public string Course { get; set; }
        public string StudentContact { get; set; }
        public string RegistrationDate { get; set; }
    }
}
