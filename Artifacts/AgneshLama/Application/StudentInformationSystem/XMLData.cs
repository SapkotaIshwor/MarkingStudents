using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace StudentInformationSystem
{
    class XMLData
    {
        public static void RecordData(object obj, string filename)
        {
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            FileStream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
            ser.Serialize(stream, obj);
            stream.Close();
        }
    }
}
