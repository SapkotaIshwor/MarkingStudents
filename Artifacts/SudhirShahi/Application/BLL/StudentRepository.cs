using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;

namespace BLL
{
    public class StudentRepository
    {
        private List<Student> _studentList = new List<Student>();
        //file location to save  object state.It is path of {project location}\bin\Debug
        private string filePath = Path.GetDirectoryName(Application.ExecutablePath);

        //start: private methods of this class

        //gets object data from file location and converts to c# list

        private void DeSerializeStudentData()
        {
            try
            {
                //step 1: check if file exists
                if (File.Exists(filePath + @"\studentDetails.dat"))
                {
                    //step 2: opens a stream to open the file
                    Stream stream = File.Open(filePath + @"\studentDetails.dat", FileMode.Open);

                    //step 3 : check if file is null or empty

                    if (stream != null && stream.Length > 0)
                    {
                        //BinaryFormatter class has mothod to convert .dat file to a c# list i.e. deserialization
                        BinaryFormatter binaryFormatter = new BinaryFormatter();

                        //step 4: convert object state to c# list

                        _studentList = (List<Student>)binaryFormatter.Deserialize(stream);

                    }
                    //step 5: Close the stream after opening a stream it should always be closed
                    stream.Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Not able to get student data.Please try again");
            }

        }

        //saves c# list object, converts to object data and saves in the file location.
        private void SerializeStudentData(List<Student> students)
        {
            //step 1: create a new file/ opens the file if it already exisits.
            Stream str = File.Open(filePath + @"\studentDetails.dat", FileMode.Create);
            //BinaryFormatter class has method to convert  c# list to .dat file. i.e. serialization.
            BinaryFormatter bF = new BinaryFormatter();
            //step 2: convert c# list to .dat file.
            bF.Serialize(str, students);
            //step 3: writes to the file.
            str.Flush();
            //step 4: close the stream.
            str.Close();
            MessageBox.Show("Student Details saved to file");
        }

        //end: private methods of this class


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
                    var student = new Student();
                    student.StudentId = Convert.ToInt32(values[0]);
                    student.Name = values[1];
                    student.Address = values[2];
                    student.ContactNumber = values[3];
                    student.Email = values[4];

                    student.ProgramEnroll = values[5];
                    student.RegistrationDate = Convert.ToDateTime(values[6]);

                    studentList.Add(student);
                }
                _studentList = studentList;

            }
            catch (Exception)
            {
                MessageBox.Show("Not able to save student data. Please try later");
            }
            return studentList;

        }

        //export the list to csv
        public void ExportToCSV(List<Student> students, string filePath)
        {
            try
            {
                if (students.Count > 0)
                {
                    var propList = students[0].GetType().GetProperties().Select(prop => prop.Name).ToList();
                    //TextWriter is used to create outputand streamWriter is used to read file location

                    using (TextWriter TW = new StreamWriter(filePath, append: true))
                    {
                        //writes header
                        foreach (var prop in propList)
                        {
                            TW.Write(prop.ToString() + ",");
                        }
                        TW.WriteLine();
                        //writes values
                        foreach (var val in students)
                        {
                            foreach (PropertyInfo prop in val.GetType().GetProperties())
                            {
                                TW.Write(prop.GetValue(val, null).ToString() + ",");
                            }
                            TW.WriteLine();

                        }
                    }
                    MessageBox.Show("Your records is saved successfully.");
                    Process.Start(filePath);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save records.");
            }

        }

        //reads vechicle data from object source and returns a list
        public List<Student> GetStudents()
        {
            //step 1: get data from the file.
            DeSerializeStudentData();
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

        //accepts list of vehicle and serializes the data to save as a object state.
        public void SaveStudents(List<Student> students)
        {
            //call this method to save the file.
            SerializeStudentData(students);
        }

        //gets the latest identity id.
        public int GenerateId()
        {
            int id = 0;
            //checks if list is null or empty
            if (_studentList != null && _studentList.Count > 0)
            {
                id = _studentList.Max(a => a.StudentId);
            }

            return id + 1;
        }

       
        //public List<Student> SortUsingName()
        //{
        //    //for (int i = 0; i < _studentList.Count; i++)
        //    //{
        //    //    for (int j = 0; j < _studentList.Count - 1; j++)
        //    //    {
        //    //        var val1 = Convert.ToString(_studentList[j].Name);
        //    //        var val2 = Convert.ToString(_studentList[j + 1].Name);
        //    //        if (val1 > val2)
        //    //        {
        //    //            var temp = _studentList[j + 1];
        //    //            _studentList[j + 1] = _studentList[j];
        //    //            _studentList[j] = temp;
        //    //        }
        //    //    }

        //    GFG gg = new GFG();

        //    _studentList.Sort(gg);
        //    return _studentList;
        //}


        public List<Student> SortUsingDate()
        {
            for (int i = 0; i < _studentList.Count; i++)
            {
                for (int j = 0; j < _studentList.Count - 1; j++)
                {
                    var val1 = Convert.ToDateTime(_studentList[j].RegistrationDate);
                    var val2 = Convert.ToDateTime(_studentList[j + 1].RegistrationDate);
                    if (val1 > val2)
                    {
                        var temp = _studentList[j + 1];
                        _studentList[j + 1] = _studentList[j];
                        _studentList[j] = temp;
                    }
                }
            }
            return _studentList;
        }


        public List<Student> GetWeeksData()
        {
            DeSerializeStudentData();
            if (_studentList != null && _studentList.Count > 0)
            {
                
                var startOfWeek = DateTime.Now.AddDays(((int)DateTime.Now.DayOfWeek * -1) + 1);
              
                startOfWeek = new DateTime(startOfWeek.Year, startOfWeek.Month, startOfWeek.Day, 00, 0, 0);

               
                var endOfWeek = startOfWeek.AddDays(6);
               
                endOfWeek = new DateTime(endOfWeek.Year, endOfWeek.Month, endOfWeek.Day, 18, 0, 0);
                

               
                var weeklyData = (from student in _studentList 
                               where student.RegistrationDate >= startOfWeek
                                  && student.RegistrationDate <= endOfWeek
                               group student by student.ProgramEnroll into g
                               let count = g.Count()
                               orderby count descending
                               select new Student
                               { Name = g.Key, Count1 = count, StudentId = g.First().StudentId }).ToList();
                return weeklyData;
            }
            else
            {
                _studentList = new List<Student>();
                return _studentList;
            }
        }

        public List<Student> GetAllData()
        {
            DeSerializeStudentData();
            if (_studentList != null && _studentList.Count > 0)
            {          
                var currentDate = DateTime.Now;
                currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 00, 0, 0);

                var allData = (from student in _studentList
                        where
                                 student.RegistrationDate <=currentDate
                        group student by student.ProgramEnroll into g
                        let count = g.Count()
                        orderby count descending
                        select new Student 
                        { Name = g.Key, Count1 = count, StudentId = g.First().StudentId }).ToList();
                return allData;

            }
            else
            {
                _studentList = new List<Student>();
                return _studentList;
            }
        }

      

    }
}
