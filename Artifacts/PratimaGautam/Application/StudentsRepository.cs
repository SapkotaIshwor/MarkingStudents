using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentInformationSystem
{
    class StudentsRepository
    {
        private List<Students> _studentsList = new List<Students>();
        //File location to save object state. It's the  path of Project's location -> bin\Debug\
        private string filePath = System.AppDomain.CurrentDomain.BaseDirectory;


        //start: private methods of this class

        //gets object data from file location and converts to c# list.
        private void DeSerializeStudentData()
        {
            try
            {
                //step 1: check if file exists
                if (File.Exists(@filePath + "\\students.dat"))
                {
                    //step 2 : opens a stream to open the file
                    Stream stream = File.Open(@filePath + "\\students.dat", FileMode.Open);

                    //step 3: check if file is null or emtpy.
                    if (stream != null && stream.Length > 0)
                    {
                        //BinaryFormatter class has method to convert .dat file to a c# list. i.e. deserialization.
                        BinaryFormatter binaryFormatter = new BinaryFormatter();

                        //Step 4: Convert object state to c# list.
                        _studentsList = (List<Students>)binaryFormatter.Deserialize(stream);

                        MessageBox.Show("Students Detail retrieved from file");
                    }
                    //step 5: close the stream. after opening a stream it should always be closed.
                    stream.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not able to get students data. Please Try Again later");
            }


        }

        //saves c# list object, converts to object data and saves in the file location.
        private void SerializeStudentData(List<Students> students)
        {
            //step 1: create a new file/ opens the file if it already exisits.
            Stream str = File.Open(filePath + "\\students.dat", FileMode.Create);
            //BinaryFormatter class has method to convert  c# list to .dat file. i.e. serialization.
            BinaryFormatter bF = new BinaryFormatter();
            //step 2: convert c# list to .dat file.
            bF.Serialize(str, students);
            //step 3: writes to the file.
            str.Flush();
            //step 4: close the stream.
            str.Close();
            MessageBox.Show("Students Detail Saved!");
        }

        //end: private methods of this class

        //read from a csv file and conver it to c# object.
        public List<Students> ReadFromCSV(string csvString)
        {
            var studentList = new List<Students>();
            try
            {
                //1st row contains property name so skipping the first row.
                var lines = csvString.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    var student = new Students();
                    student.ID = Convert.ToInt32(values[0]);
                    student.FirstName = values[1];
                    student.LastName = values[2];
                    student.Address = values[3];
                    student.ContactNo = values[4];
                    student.CourseEnroll = values[5];
                    student.RegistrationDate = Convert.ToDateTime(values[6]);

                    studentList.Add(student);
                }
                _studentsList = studentList;

            }
            catch (Exception)
            {
                MessageBox.Show("Not able to save student data. Please try later");
            }
            return studentList;
        }

        public void SaveStudent(List<Students> students)
        {
            SerializeStudentData(students);
        }

        //reads student data from object source and returns a list
        public List<Students> GetStudents()
        {
            //step 1: get data from the file.
            DeSerializeStudentData();
            //check if it is null or empty.
            if (_studentsList != null && _studentsList.Count > 0)
            {
                return _studentsList;
            }
            else
            {
                _studentsList = new List<Students>();
                return _studentsList;
            }

        }

        //gets the latest identity id.
        public int GenerateId()
        {
            int id = 0;
            //checks if list is null or empty
            if (_studentsList != null && _studentsList.Count > 0)
            {
                id = _studentsList.Max(a => a.ID);
            }

            return id + 1;
        }

        //export the list to csv
        public void ExportToCSV(List<Students> students, string filePath)
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

        //bubble sort example
        public List<Students> SortUsingMakeYear()
        {
            for (int i = 0; i < _studentsList.Count; i++)
            {
                for (int j = 0; j < _studentsList.Count - 1; j++)
                {
                    var val1 = Convert.ToInt32(_studentsList[j].ID);
                    var val2 = Convert.ToInt32(_studentsList[j + 1].ID);
                    if (val1 > val2)
                    {
                        var temp = _studentsList[j + 1];
                        _studentsList[j + 1] = _studentsList[j];
                        _studentsList[j] = temp;
                    }
                }
            }
            return _studentsList;
        }
    }
}
