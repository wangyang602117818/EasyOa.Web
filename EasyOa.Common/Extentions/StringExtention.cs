using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    public static class StringExtention
    {
        /// <summary>
        /// Md5计算
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMD5(this string str)
        {
            return EncryptHelper.Md5String(str);
        }
        /// <summary>
        /// 拼音转换
        /// </summary>
        /// <param name="str"></param>
        /// <param name="simple"></param>
        /// <returns></returns>
        public static string ToSpell(this string str, bool simple = false)
        {
            if (string.IsNullOrEmpty(str)) return "";
            string fullPath = AppConfig.basePath + AppConfig.GetConfig("pinypath");
            Dictionary<string, string[]> dict = FileHelper.ReadFileSplit(fullPath, "|");
            if (dict != null && dict.Count > 0)
            {
                foreach (string key in dict.Keys)
                {
                    string[] value = dict[key];
                    if (str.Contains(key))
                    {
                        if (simple)
                        {
                            if (value.Length > 1)
                            {
                                str = str.Replace(key, value[1]);
                            }
                            else
                            {
                                str = str.Replace(key, value[0].Substring(0, 1));
                            }
                        }
                        else
                        {
                            str = str.Replace(key, value[0]);
                        }
                    }
                }
            }
            List<string> res = new List<string>();
            foreach (char c in str)
            {
                if (ChineseChar.IsValidChar(c))
                {
                    string piny = new ChineseChar(c).Pinyins[0];
                    piny = piny.Substring(0, piny.Length - 1);
                    res.Add(piny.ToLower());
                }
                else
                {
                    res.Add(c.ToString());
                }
            }
            return simple ? string.Join("", res.Select(r => r.Substring(0, 1))) : string.Join("", res);
        }
        /// <summary>
        /// 字符串正则替换扩展
        /// </summary>
        /// <param name="str"></param>
        /// <param name="regexp"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string RegexReplace(this string str, string regexp, string replacement)
        {
            return Regex.Replace(str, regexp, replacement);
        }
        /// <summary>
        /// 将字符串中非ascii编码转unicode编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringNotAsciiToUnicode(this string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((int)c > 127)
                {
                    sb.Append("\\u" + ((int)c).ToString("x"));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 把字符串中unicode编码转成字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringUnicodeToChar(this string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            return Regex.Unescape(str);  //方式一
            //return Regex.Replace(str, @"\\u(\w{4})", (match) => ((char)int.Parse(match.Groups[1].Value, NumberStyles.HexNumber)).ToString());   //方式二
            
        }
    }
}
