using EasyOa.Common;
using EasyOa.Common.Util;
using EasyOa.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EasyOa.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string name ,int? age)
        {
          Response.Write(SMSHelper.Send("18518317472", new[] { "152122", "saa" })); 
            
            return View();
        }
    }
}
