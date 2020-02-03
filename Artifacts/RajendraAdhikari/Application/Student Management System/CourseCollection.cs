using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class CourseCollection : Collection<Data>
    {
        int java, python, networking, database, wordpress = 0;
        public CourseCollection()
        {
            var getData = System.IO.File.ReadAllText("studentDetails.csv");
            var text = getData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var newText in text)
            {
                var newData = newText.Split(',');
                if(newData[5] == "Java")
                {
                    java++;
                }
                else if (newData[5] == "Python")
                {
                    python++;
                }
                else if (newData[5] == "Networking")
                {
                    networking++;
                }
                else if (newData[5] == "Database")
                {
                    database++;
                }
                else if (newData[5] == "Wordpress")
                {
                    wordpress++;
                }

            }
            Add(new Data("Java", java));
            Add(new Data("Python", python));
            Add(new Data("Database", database));
            Add(new Data("Networking", networking));
            Add(new Data("Wordpress", wordpress));
        }
    }
}
