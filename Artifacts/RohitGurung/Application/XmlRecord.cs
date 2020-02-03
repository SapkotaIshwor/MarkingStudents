using System.Xml.Serialization;
using System.IO;

namespace CWAD
{
    class XmlRecord
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
