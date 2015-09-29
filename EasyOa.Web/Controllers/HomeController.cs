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
        public ActionResult Index()
        {
            string url = "http://localhost:41859/progress.aspx";
            string fileurl = "http://old.etaoshi.com/WebImage/SupplierImage/215194/s30122014111607.png";
            //string str = HttpRequestHelper.PostAttachLocalFile(url, @"E:\log\canting.txt", "");
            string str = HttpRequestHelper.PostAttachWebFile(url, fileurl, "");
            Response.Write(str);
            
            return View();
        }
    }
}
