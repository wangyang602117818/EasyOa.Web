using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common.Helpers
{
    public static class SMSHelper
    {
        private static string baseurl;
        private static string accountsid;
        private static string autotoken;
        private static string appid;
        static SMSHelper()
        {
            baseurl = ConfigurationManager.AppSettings["baseurl"];
            accountsid = ConfigurationManager.AppSettings["accountsid"];
            autotoken = ConfigurationManager.AppSettings["autotoken"];
            appid = ConfigurationManager.AppSettings["appid"];
        }
        public static string Send(string to,string content)
        {

        }
    }
}
