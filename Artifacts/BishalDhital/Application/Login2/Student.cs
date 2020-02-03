using System;

namespace Login2
{
    [Serializable]
    public class Student
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string CourseName { get; set; }
        public string RegisterDate { get; set; }
    }
}