using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Application_Dev
{
    public class StudentInfo
    {

        public StudentInfo(string studentString)
        {
            this.ConvertToObject(studentString);
        }
        public string RegistrationNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string ProgramEnrolled { get; set; }
        public string RegistrationDate { get; set; }


        public override string ToString()
        {
            return $"{this.RegistrationNo}:{this.FirstName}:{this.LastName}:{this.Address}:{this.Contact}:{this.Email}:{this.ProgramEnrolled}:{this.RegistrationDate}";
        }

        private void ConvertToObject(string studentString)
        {
            var splitedStrings = studentString.Split(',');
            this.RegistrationNo = splitedStrings[0];
            this.FirstName = splitedStrings[1];
            this.LastName = splitedStrings[2];
            this.Address = splitedStrings[3];
            this.Contact = splitedStrings[4];
            this.Email = splitedStrings[5];
            this.ProgramEnrolled = splitedStrings[6];
            this.RegistrationDate = splitedStrings[7];
        }

        public StudentInfo(XmlNode node )
        {
            this.ConvertToObject(node);
        }

        private void ConvertToObject(XmlNode node)
        {
            this.RegistrationNo = node.SelectSingleNode("RegistrationNo").InnerText;
            this.FirstName = node.SelectSingleNode("FirstName").InnerText;
            this.LastName = node.SelectSingleNode("LastName").InnerText;
            this.Address = node.SelectSingleNode("Address").InnerText;
            this.Contact = node.SelectSingleNode("ContactNo").InnerText;
            this.Email = node.SelectSingleNode("Email").InnerText;
            this.ProgramEnrolled = node.SelectSingleNode("CourseEnroll").InnerText;
            this.RegistrationDate = node.SelectSingleNode("RegistrationDate").InnerText;
        }


    }
}
