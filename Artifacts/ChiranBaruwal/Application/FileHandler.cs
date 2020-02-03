﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Collections.ObjectModel;

namespace Student_Information_System
{
    class FileHandler
    {
        public static ObservableCollection<StudentDetails> Students { get; set; }


        private string filePath = Directory.GetCurrentDirectory() + @"\students.dat";
        private BinaryFormatter bf = new BinaryFormatter();

        public FileHandler()
        {
            Students = new ObservableCollection<StudentDetails>();

            Students = getData();
        }

        public void saveData(int studentID, string studentName, string studentAddress, string studentPhone, string courseEnrolled, DateTime regDate)
        {
            Students.Add(new StudentDetails(studentID, studentName, studentAddress, studentPhone, courseEnrolled, regDate));

            using (Stream stream = new FileStream(filePath, FileMode.Create))
            {
                bf.Serialize(stream, Students);

                stream.Close();
            }

                
        }

        public ObservableCollection<StudentDetails> getData()
        {
            if (File.Exists(filePath) && new FileInfo(filePath).Length != 0)
            {
                Stream stream = File.Open(filePath, FileMode.Open);
                
                Students = (ObservableCollection<StudentDetails>)bf.Deserialize(stream);

                stream.Close();
                                
            }

            return Students;
        }

        public void exportCSV(string path)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < Students.Count; i++)
                    {
                        file.WriteLine(Students[i].StudentID + "," + Students[i].StudentName + "," + Students[i].StudentAddress + "," + Students[i].StudentPhone + "," + Students[i].CourseEnrolled + "," + Students[i].RegistrationDate);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("File cannot be saved.", ex);
            }
        }

        public void importCSV(string path)
        {

            string[] data = System.IO.File.ReadAllLines(path);

            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    string[] details = data[i].Split(',');

                    saveData(int.Parse(details[0]), details[1], details[2], details[3], details[4], DateTime.Parse(details[5]));
                }

                MessageBox.Show("Imported successfully!");
            } catch
            {
                MessageBox.Show("Error importing data!");
            }
            
        }
    }
}
