using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentCw1
{
    public class StudentInfo
    {
        

        public StudentInfo(string studentString)
        {
            this.ConvertToObject(studentString);
        }
        public string id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CourseEnroll { get; set; }
        public string Gender { get; set; }
        public string EnrollDate { get; set; }
        public string District { get; set; }
        public string Zone { get; set; }



        public override string ToString()
        {
            return $"{this.id}:{this.FirstName}:{this.LastName}:{this.Phone}:{this.Email}:{this.CourseEnroll}:{this.Gender}:" +
                $"{this.EnrollDate}:{this.District}:{this.Zone}";
        }

        private void ConvertToObject(string studentString)
        {
            var splitedStrings = studentString.Split(',');
            this.id = splitedStrings[0];
            this.FirstName = splitedStrings[1];
            this.LastName = splitedStrings[2];
            this.Phone = splitedStrings[3];
            this.Email = splitedStrings[4];
            this.CourseEnroll = splitedStrings[5];
            this.Gender = splitedStrings[6];
            this.EnrollDate = splitedStrings[7];
            this.District = splitedStrings[8];
            this.Zone = splitedStrings[9];
           
        }

    }
}
