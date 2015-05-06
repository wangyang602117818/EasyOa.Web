using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EasyOa.Common
{
    public class JsonHelper
    {
        private static JavaScriptSerializer jss = new JavaScriptSerializer();
        public static string Serialize(object obj)
        {
            return jss.Serialize(obj);
        }
        public static T Deserialize<T>(string str)
        {
            return jss.Deserialize<T>(str);
        }
    }
}
