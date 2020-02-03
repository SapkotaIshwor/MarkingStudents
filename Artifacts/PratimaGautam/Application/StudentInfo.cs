using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem
{
    public class StudentInfo
    {
        public StudentInfo() { }

        public StudentInfo(string studentString)
        {
            this.ConvertToObject(studentString);
        }
        public string RegID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string CourseEnroll { get; set; }
        public string RegistrationDate { get; set; }

        public override string ToString()
        {
            return $"{this.RegID}:{this.FirstName}:{this.LastName}:{this.Address}:{this.ContactNo}:{this.CourseEnroll}:{this.RegistrationDate}";
        }

        private void ConvertToObject(string studentString)
        {
            var splitedStrings = studentString.Split(',');
            RegID = splitedStrings[0];
            FirstName = splitedStrings[1];
            LastName = splitedStrings[2];
            Address = splitedStrings[3];
            ContactNo = splitedStrings[4];
            CourseEnroll = splitedStrings[5];
            RegistrationDate = splitedStrings[6];
        }
    }
}
