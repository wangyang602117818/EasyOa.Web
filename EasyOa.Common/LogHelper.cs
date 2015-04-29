using log4net;
using log4net.Layout;
using log4net.Layout.Pattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    public static class LogHelper
    {
        private static readonly ILog exceptionLog = null;
        private static readonly ILog mailLog = null;
        private static readonly ILog operateLog = null;
        static LogHelper()
        {
            exceptionLog = LogManager.GetLogger("FileAppender");
            mailLog = LogManager.GetLogger("MailAppender");
            operateLog = LogManager.GetLogger("SqlServerAppender");
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="ex">异常信息</param>
        public static void WriteException(Exception ex)
        {
            exceptionLog.Error(ex);
        }
        /// <summary>
        /// 邮件日志
        /// </summary>
        /// <param name="ex"></param>
        public static void MailException(Exception ex)
        {
            mailLog.Error(ex);
        }
        /// <summary>
        /// 操作日志(数据库)
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="log"></param>
        public static void WriteLog<T>(T log)
        {
            operateLog.Info(log);
        }
        /// <summary>
        /// 文本日志
        /// </summary>
        /// <param name="path">绝对路口</param>
        /// <param name="name">文件名</param>
        /// <param name="logInfo">文件类容</param>
        public static void WriteLog(string path, string name, string logInfo)
        {

            string fileName = Path.Combine(path, name);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(logInfo);
            }
        }
    }
    /// <summary>
    /// 自定义日志输出类型
    /// </summary>
    public class MyLayout : PatternLayout
    {
        public MyLayout()
        {
            this.AddConverter("property", typeof(MyMessagePatternConverter));
        }
    }
    public class MyMessagePatternConverter : PatternLayoutConverter
    {
        protected override void Convert(System.IO.TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
        {
            if (Option != null)
            {
                WriteObject(writer, loggingEvent.Repository, LookupProperty(Option, loggingEvent));
            }
            else
            {
                WriteDictionary(writer, loggingEvent.Repository, loggingEvent.GetProperties());
            }
        }
        private object LookupProperty(string property, log4net.Core.LoggingEvent loggingEvent)
        {
            object propertyValue = string.Empty;
            PropertyInfo propertyInfo = loggingEvent.MessageObject.GetType().GetProperty(property);
            if (propertyInfo != null)
                propertyValue = propertyInfo.GetValue(loggingEvent.MessageObject, null);
            return propertyValue;
        }
    }
}
