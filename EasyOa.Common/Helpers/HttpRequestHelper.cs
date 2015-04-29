using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    public static class HttpRequestHelper
    {
        public static string Post(string url, string paras)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "post";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] bs = Encoding.UTF8.GetBytes(paras);
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bs, 0, bs.Length);
            }
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        public static string Get(string url, string paras)
        {
            WebRequest request = WebRequest.Create(url + "?" + paras);
            request.Method = "get";
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        public static string BuildParas(NameValueCollection nv)
        {
            if (nv == null) return "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < nv.Keys.Count; i++)
            {
                sb.Append(nv.Keys[i] + "=" + nv[nv.Keys[i]] + "&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
}
