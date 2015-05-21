using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    public static class FileHelper
    {
        /// <summary>
        /// 读取文本文件，返回字典,其中文本中的第一个字符串作为key，后面的作为value
        /// </summary>
        /// <param name="fullpath">文件绝对路径</param>
        /// <param name="sign">文件分隔符</param>
        /// <returns></returns>
        public static Dictionary<string, string[]> ReadFileSplit(string fullpath, string sign = " ")
        {
            if (!File.Exists(fullpath)) return null;
            string[] lines = File.ReadAllLines(fullpath);
            Dictionary<string, string[]> dict = new Dictionary<string, string[]>();
            foreach (string line in lines)
            {
                string[] sword = line.Split(new string[] { sign }, StringSplitOptions.RemoveEmptyEntries);
                string[] word = new string[sword.Length - 1];
                Array.Copy(sword, 1, word, 0, sword.Length - 1);
                dict.Add(sword[0], word);
            }
            return dict;
        }
        /// <summary>
        /// 把字符串写入文件
        /// </summary>
        /// <param name="fullpath"></param>
        /// <param name="filename"></param>
        /// <param name="msg"></param>
        public static void WriteString(string fullpath, string filename, string msg)
        {
            if (!Directory.Exists(fullpath)) Directory.CreateDirectory(fullpath);
            string fileName = Path.Combine(fullpath, filename);
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(msg);
            }
        }
    }
}
