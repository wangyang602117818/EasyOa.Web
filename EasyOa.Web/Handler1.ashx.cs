using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyOa.Web
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.Write("xxx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}