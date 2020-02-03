using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentInformationSystem
{
    class XmlRecord
    {
        public static void recordData(object obj, string filename)
        {
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            FileStream fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write);
            ser.Serialize(fileStream, obj);
            fileStream.Close();
        }
    }
}
