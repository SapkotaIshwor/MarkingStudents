using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System
{
    public class AddingStudentDetails { 
        private string std_reg_id;
        private string std_fullname;
        private string std_address;
        private string std_contact;
        private string std_course_enroll;
        private string std_registration_date;
        
       

        public string studentRegistrationID
        {
            get { return std_reg_id; }
            set { std_reg_id = value; }
        }

        public string studentFullname
        {
            get { return std_fullname; }
            set { std_fullname = value; }
        }

        public string studentAddress
        {
            get { return std_address; }
            set { std_address = value; }
        }

        public string studentContact
        {
            get { return std_contact; }
            set { std_contact = value; }
        }

        public string studentCourseEnroll
        {
            get { return std_course_enroll; }
            set { std_course_enroll = value; }
        }

        public string studentRegistrationDate
        {
            get { return std_registration_date; }
            set { std_registration_date = value; }
        }

     
    }
}

