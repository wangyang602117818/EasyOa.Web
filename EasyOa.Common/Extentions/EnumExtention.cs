using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    public static class EnumExtention
    {
        /// <summary>
        /// 获取枚举的description
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            Type enumType = value.GetType();
            string name = Enum.GetName(enumType, value);
            if (!string.IsNullOrEmpty(name))
            {
                FieldInfo fi = enumType.GetField(name);
                if (fi != null)
                {
                    DescriptionAttribute description = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute), false);
                    return description.Description;
                }
            }
            
            return null;
        }
    }
}
