using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    public static class EncryptHelper
    {
        private static MD5 md5 = null;
        static EncryptHelper()
        {
            md5 = MD5.Create();
        }
        /// <summary>
        /// 字符串md5计算
        /// </summary>
        /// <param name="str">要计算的字符串</param>
        /// <returns></returns>
        public static string Md5String(string str)
        {
            byte[] md5bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in md5bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 文件MD5计算
        /// </summary>
        /// <param name="path">要计算的文件的路径</param>
        /// <returns></returns>
        public static string Md5File(string path)
        {
            if (!File.Exists(path)) return "";
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                byte[] md5Bytes = md5.ComputeHash(fs);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in md5Bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

    }
}
