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
        public static Dictionary<string, string> ReadFileSpaceSplit(string fullpath)
        {
            if (!File.Exists(fullpath)) return null;
            string[] lines = File.ReadAllLines(fullpath);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                string[] sword = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                dict.Add(sword[0], sword[1]);
            }
            return dict;
        }
    }
}
