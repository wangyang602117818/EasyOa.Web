using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EasyOa.Common
{
    public class BinarySerializerHelper
    {
        /// <summary>
        /// 对象序列化成 byte[]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ObjectToByteArray(object obj)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                xs.Serialize(stream, obj);
                return stream.ToArray();
            }
        }
        /// <summary>
        /// 字节数组序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static T ByteArrayToObject<T>(byte[] buffer)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                return (T)xs.Deserialize(stream);
            }
        }
    }
}
