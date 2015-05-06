using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    public static class MailHelper
    {
        private static string smtphost;
        private static string port;
        private static string timeout;
        private static string sendemail;
        private static string username;
        private static string userpwd;
        private static SmtpClient client;
        /// <summary>
        /// 初始化参数
        /// </summary>
        static MailHelper()
        {
            smtphost = ConfigurationManager.AppSettings["smtphost"];
            port = ConfigurationManager.AppSettings["port"];
            timeout = ConfigurationManager.AppSettings["timeout"];
            sendemail = ConfigurationManager.AppSettings["sendemail"];
            username = ConfigurationManager.AppSettings["username"];
            userpwd = ConfigurationManager.AppSettings["userpwd"];
            initClient();
        }
        /// <summary>
        /// 初始化SmtpClient对象
        /// </summary>
        private static void initClient()
        {
            client = new SmtpClient(smtphost, int.Parse(port));
            client.Credentials = new NetworkCredential(username, userpwd);
            client.Timeout = int.Parse(timeout);
        }
        /// <summary>
        /// 发邮件
        /// </summary>
        /// <param name="subject">邮件主题</param>
        /// <param name="message">邮件内容</param>
        /// <param name="to">接收人列表</param>
        /// <returns></returns>
        public static bool Send(string subject, string message, params string[] to)
        {
            return Send(subject, message, false, null, to);
        }
        /// <summary>
        /// 发邮件
        /// </summary>
        /// <param name="subject">邮件主题</param>
        /// <param name="message">邮件内容</param>
        /// <param name="isHtml">是否是html邮件</param>
        /// <param name="to">接收人列表</param>
        /// <returns></returns>
        public static bool Send(string subject, string message, bool isHtml, params string[] to)
        {
            return Send(subject, message, isHtml, null, to);
        }
        /// <summary>
        /// 发邮件
        /// </summary>
        /// <param name="subject">邮件主题</param>
        /// <param name="message">邮件内容</param>
        /// <param name="isHtml">是否是html邮件</param>
        /// <param name="fileCollection">附件列表</param>
        /// <param name="to">接收人列表</param>
        /// <returns></returns>
        public static bool Send(string subject, string message, bool isHtml, List<string> fileCollection, params string[] to)
        {
            MailMessage mailMessage = new MailMessage() { From = new MailAddress(sendemail), Body = message, Subject = subject, IsBodyHtml = isHtml };
            if (fileCollection != null)
            {
                foreach (string file in fileCollection)
                {
                    if (File.Exists(file)) mailMessage.Attachments.Add(new Attachment(file));
                }
            }
            Array.ForEach(to, t => mailMessage.To.Add(t));
            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (SmtpException ex)
            {
                LogHelper.WriteException(ex);
            }
            return false;
        }
    }
}
