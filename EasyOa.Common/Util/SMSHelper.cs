using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    public class SmsBody
    {
        public string to { get; set; }
        public string appId { get; set; }
        public string templateId { get; set; }
        public string[] datas { get; set; }
    }

    public static class SMSHelper
    {
        private static string baseurl = ConfigurationManager.AppSettings["baseurl"];
        private static string accountsid = ConfigurationManager.AppSettings["accountsid"];
        private static string autotoken = ConfigurationManager.AppSettings["autotoken"];
        private static string appid = ConfigurationManager.AppSettings["appid"];
        private const string appversion = "2013-12-26";
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="to">接收号码 多个号码用,隔开</param>
        /// <param name="contents">替换模板的内容</param>
        /// <returns></returns>
        public static string Send(string to, string[] contents)
        {
            return Send(to, "1", contents, SMSBodyType.json);
        }
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="to">接收号码 多个号码用,隔开</param>
        /// <param name="templateid">使用模板id</param>
        /// <param name="contents">替换模板的内容</param>
        /// <returns></returns>
        public static string Send(string to, string templateid, string[] contents)
        {
            return Send(to, templateid, contents, SMSBodyType.json);
        }
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="to">接收号码 多个号码用,隔开</param>
        /// <param name="templateid">使用模板id</param>
        /// <param name="contents">替换模板的内容</param>
        /// <param name="type">短信内容的格式</param>
        /// <returns></returns>
        public static string Send(string to, string templateid, string[] contents, SMSBodyType? type)
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmss");
            string url = string.Format("{0}/{1}/Accounts/{2}/SMS/TemplateSMS?sig={3}", baseurl, appversion, accountsid, (accountsid + autotoken + date).ToMD5());
            string authorization = Convert.ToBase64String(Encoding.UTF8.GetBytes(accountsid + ":" + date));
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Authorization", authorization);
            if (string.IsNullOrEmpty(templateid)) templateid = "1";
            SmsBody smsBody = new SmsBody { to = to, appId = appid, templateId = templateid, datas = contents };
            if (type == SMSBodyType.json)
            {
                return HttpRequestHelper.Post(url, dict, RequestContentType.json, AcceptType.json, JsonHelper.Serialize(smsBody));
            }
            else
            {
                return HttpRequestHelper.Post(url, dict, RequestContentType.xml, AcceptType.xml, XmlSerializeHelper.Serialize(smsBody));
            }
        }
    }
}
