using System;

namespace StudentInformationSystem
{


    public class RegistrationDetails
    {
        private string std_reg_id;
        private string std_reg_date;
        private string std_id;
        private string std_name;
        private string std_address;
        private string std_email;
        private string std_contact;
        private string std_course;

        public string registrationID
        {
            get { return std_reg_id; }
            set { std_reg_id = value; }
        }

        public string registrationDate
        {
            get { return std_reg_date; }
            set { std_reg_date = value; }
        }

        public string studentID
        {
            get { return std_id; }
            set { std_id = value; }
        }

        public string name
        {
            get { return std_name; }
            set { std_name = value; }
        }

        public string address
        {
            get { return std_address; }
            set { std_address = value; }
        }

        public string email
        {
            get { return std_email; }
            set { std_email = value; }
        }

        public string contact
        {
            get { return std_contact; }
            set { std_contact = value; }
        }

        public string course
        {
            get { return std_course; }
            set { std_course = value; }
        }
    }
}