using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EasyOa.Common
{
    public static class XmlSerializeHelper
    {
        public static string Serialize(object obj)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            using (StringWriter writer = new StringWriter())
            {
                xs.Serialize(writer, obj);
                return writer.ToString();
            }
        }
        public static T Deserialize<T>(string str)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(str))
            {
                return (T)xs.Deserialize(sr);
            }
        }
    }
}
