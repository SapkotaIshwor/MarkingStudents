using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable()]
    public class Student : ISerializable
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        
        public string Email { get; set; }
        public string ProgramEnroll { get; set; }
        public DateTime RegistrationDate { get; set; }
        [NonSerialized] public double Count1;
       
        //needed for Serialization

        //making key value pairs

        public static string Key = "StudentId";
        public static string Key1 = "Name";
        public static string Key2= "Address";
        public static string Key3 = "ContactNumber";
        public static string Key4 = "Email";
        public static string Key5 = "ProgramEnroll";
        public static string Key6 = "RegistrationDate";

        //constructor
        public Student()
        {

        }

        //Deserialization constructor
        //gets value from object and converts to c# property

        public Student(SerializationInfo serial, StreamingContext context)
        {
            //Get the values from info and assign them to the appropriate properties

            StudentId = (int)serial.GetValue(Key, typeof(int));
            Name = (string)serial.GetValue(Key1, typeof(string));
            Address = (string)serial.GetValue(Key2, typeof(string));
            ContactNumber = (string)serial.GetValue(Key3, typeof(string));
            Email = (string)serial.GetValue(Key4, typeof(string));
            ProgramEnroll = (string)serial.GetValue(Key5, typeof(string));
            RegistrationDate = (DateTime)serial.GetValue(Key6, typeof(DateTime));

        }



        //Serialize Method
        //this method converts the properties to object data using key value mentioned above
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            

            info.AddValue(Key, StudentId);
            info.AddValue(Key1, Name);
            info.AddValue(Key2, Address);
            info.AddValue(Key3, ContactNumber);
            info.AddValue(Key4, Email);
            info.AddValue(Key5, ProgramEnroll);
            info.AddValue(Key6, RegistrationDate);
        }
    }
}
