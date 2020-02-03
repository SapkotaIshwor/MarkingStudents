using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Coursework
{
   public class XmlDetails
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
