using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    public static class AppConfig
    {
        /// <summary>
        /// 网站跟目录
        /// </summary>
        public static string basePath = AppDomain.CurrentDomain.BaseDirectory; //AppDomain.CurrentDomain.SetupInformation.ApplicationBase
        public static string GetConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
