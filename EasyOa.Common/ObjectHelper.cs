using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EasyOa.Common
{
    public class ObjectHelper
    {
        /// <summary>
        /// 对象转换成 Hashtable
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Hashtable ObjectToHashtable(object obj)
        {
            Hashtable hashtable = new Hashtable();
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                hashtable.Add(property.Name, property.GetValue(obj));
            }
            return hashtable;
        }
    }
}
