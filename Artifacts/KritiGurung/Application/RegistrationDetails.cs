using System;

public class Class1
{
    public class RegistrationDetials
    {
        private string std_reg_id;
        private string std_reg_date;
        private string std_id;
        private string std_name;
        private string txtData5;
        private string txtData6;
        private string txtData7;
        private string txtData8;

        public string studentRegistrationID
        {
            get { return std_reg_id; }
            set { std_reg_date = value; }
        }

        public string studentRegistrationDate
        {
            get { return std_reg_date; }
            set { std_reg_date = value; }
        }

        public string studentID
        {
            get { return std_id; }
            set { std_std_id = value; }
        }

        public string studentName
        {
            get { return std_name; }
            set { std_name = value; }
        }

        public string studentAddress
        {
            get { return std_address; }
            set { std_address = value; }
        }

        public string studentEmail
        {
            get { return std_email; }
            set { std_email = value; }
        }

        public string studentContact
        {
            get { return std_contact; }
            set { std_contact = value; }
        }

        public string studentCourse
        {
            get { return std_course; }
            set { std_course = value; }
        }
    }
}