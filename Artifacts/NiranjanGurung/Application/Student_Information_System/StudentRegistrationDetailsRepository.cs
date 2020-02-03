using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Student_Information_System
{
    public class StudentRegistrationDetailsRepository
    {
        private List<Student> _studentList = new List<Student>();
        
        private string filePath = (@"E:\applicaiton development\github\course-work-1-Niranjan-26\Student_Information_System\bin\Debug\visit.csv");
        //start: private methods of this class
        //gets object data from file location and converts to c# list.
        private void DeSerializeRegistrationDetails()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    Stream stream = File.Open(filePath, FileMode.Open);
                    if (stream != null && stream.Length > 0)
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        _studentList = (List<Student>)binaryFormatter.Deserialize(stream);
                        MessageBox.Show("Visit Details retrieved from file");
                    }
                    stream.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not able to get visit data. Please try again");
            }
        }
        private void SerializeRegistrationDetails(List<Student> students)
        {
            Stream str = File.Open(filePath, FileMode.Create);
            BinaryFormatter bF = new BinaryFormatter();
            bF.Serialize(str, students);
            str.Flush();
            str.Close();
            MessageBox.Show("Visit Details saved to file");

           /* Student student = new Student();
            AddStudents addStudents = new AddStudents();

            XmlSerializer xs = new XmlSerializer(typeof(Student));

            FileStream fsout = new FileStream("individual.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    xs.Serialize(fsout, student);
                    MessageBox.Show("Successfully Saved", "Info");
                    addStudents.txtId.Text = String.Empty;
                    addStudents.txtfullname.Text = String.Empty;
                    addStudents.txtAddress.Text = String.Empty;
                    addStudents.txtAddress.Text = String.Empty;
                    addStudents.txtContact.Text = String.Empty;
                    addStudents.cbcourseEnroll.Text = String.Empty;
                    addStudents.dpRegistrationDate.Text = String.Empty;

                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
            */
        }
        //end: private methods of this class

        //start: public methods of this class. only these methods can be accessed by other classes

        //accepts list of visitor and serializes the data to save as a object state.
        public void SaveStudents(List<Student> students)
        {
            //call this method to save the file.
            SerializeRegistrationDetails(students);
        }


        //start: public methods of this class. only these methods can be accessed by other classes

        //read from a csv file and conver it to c# object.
        public List<Student> ReadFromCSV(string csvString)
        {
            var studentList = new List<Student>();
            try
            {
                //1st row contains property name so skipping the first row.
                var lines = csvString.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    var visitor = new Student();
                    visitor.ID = values[0];
                    visitor.Fullname = values[1];
                    visitor.Address = values[2];
                    visitor.Contact = values[3];
                    visitor.courseEnroll = values[4];
                    visitor.RegistrationDate = values[3];
                    studentList.Add(visitor);

                }
                _studentList = studentList;
                MessageBox.Show("Successfully saved visitor data.");

            }
            catch (Exception)
            {
                MessageBox.Show("Not able to save visitor data. Please try later");
            }
            return studentList;

        }

        //reads visitor data from object source and returns a list
        public List<Student> GetStudents()
        {
            //step 1: get data from the file.
            DeSerializeRegistrationDetails();
            //check if it is null or empty.
            if (_studentList != null && _studentList.Count > 0)
            {
                return _studentList;
            }
            else
            {
                _studentList = new List<Student>();
                return _studentList;
            }

        }

        //accepts list of visitor and serializes the data to save as a object state.
        public void SaveStudent(List<Student> students)
        {
            //call this method to save the file.
            SerializeRegistrationDetails(students);
        }

      

    }
}

