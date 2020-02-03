using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CourseworkAppDevelopment
{
    public class XmlRecord
    {
        public static void XmlRecordMethod(object obj, string filename) {

            XmlSerializer serialize = new XmlSerializer(obj.GetType());
            
            FileStream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
            
            serialize.Serialize(stream, obj);
            
            stream.Close();
        }
    }
}
