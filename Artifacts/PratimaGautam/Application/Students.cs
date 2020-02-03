using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem
{
    [Serializable()]
    public class Students : ISerializable
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string CourseEnroll { get; set; }
        public DateTime RegistrationDate { get; set; }

        //needed for serialization
        //making key value pairs.
        public static string KEY = "ID";
        public static string KEY1 = "FirstName";
        public static string KEY2 = "LastName";
        public static string KEY3 = "Address";
        public static string KEY4 = "ContactNo";
        public static string KEY5 = "CourseEnroll";
        public static string KEY6 = "RegistrationDate";

        //default constructor
        public Students() { }

        //Deserialization constructor.
        //gets value from object data and converts to c# property.
        public Students(SerializationInfo serial, StreamingContext context)
        {
            //Get the values from info and assign them to the appropriate properties
            ID = (int)serial.GetValue(KEY, typeof(int));
            FirstName = (string)serial.GetValue(KEY1, typeof(string));
            LastName = (string)serial.GetValue(KEY2, typeof(string));
            Address = (string)serial.GetValue(KEY3, typeof(string));
            ContactNo = (string)serial.GetValue(KEY4, typeof(string));
            CourseEnroll = (string)serial.GetValue(KEY5, typeof(string));
            RegistrationDate = (DateTime)serial.GetValue(KEY6, typeof(DateTime));
        }

        //Serialize Method.
        //this method converts the properties to object data using Key value mentioned above
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue(KEY, ID);
            info.AddValue(KEY1, FirstName);
            info.AddValue(KEY2, LastName);
            info.AddValue(KEY3, Address);
            info.AddValue(KEY4, ContactNo);
            info.AddValue(KEY5, CourseEnroll);
            info.AddValue(KEY6, RegistrationDate);
        }
    }
}
