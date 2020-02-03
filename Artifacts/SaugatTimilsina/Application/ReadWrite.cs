using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentInformationSystem
{
    class ReadWrite
    {
        private const String FILE_NAME = "file.dat";
        private String[,] managedRecords = null;
        public string[,] Read()
        {
            string[] lines = {""};
            if (File.Exists(FILE_NAME))
            {
                lines = File.ReadAllLines(FILE_NAME, Encoding.UTF8);
                managedRecords = new String[lines.Length, 8];
                //Storing data from the file in variable
                for (int i = 0; i < lines.Length; i++)
                {
                    //Splitting and storing the variables in list
                    List<string> names = lines[i].Split(',').ToList();
                    for (int j = 0; j < names.Count; j++)
                    {
                        //assigning the values from rows, columns to a multidimensional array
                        managedRecords[i, j] = names[j];
                        Console.WriteLine("Names{i,j}: {"+ i + ", " + j +"} " + names[j]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Sorry! No record exists", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return managedRecords;
        }

        public string[] getLines()
        {
            string[] lines = File.ReadAllLines(FILE_NAME, Encoding.UTF8);
            return lines;
        }

        public int getLength()
        {
            int lengthInFile = File.ReadAllLines(FILE_NAME, Encoding.UTF8).Length;
            return lengthInFile;
        }

        public void Write(String toStore)
        {
            if (File.Exists(FILE_NAME))
            {
                Console.WriteLine($"{FILE_NAME} already exists!");
                using (StreamWriter w = File.AppendText(FILE_NAME))
                {
                    w.WriteLine(toStore);
                }
            }
            else
            {
                using (StreamWriter stream = new StreamWriter(FILE_NAME, true))
                {
                    stream.WriteLine(toStore);
                }
            }
        }
    }
}
