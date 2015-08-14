using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyOa.Common;

namespace EasyOa.Web.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
           Response.Write(EncryptHelper.FileMd5(AppConfig.basePath + @"WebResource\uploadfile\css3.chm")+"<br>");
           Response.Write(EncryptHelper.FileMd5(AppConfig.basePath + @"WebResource\uploadfile\css3.chw") + "<br>");
           Response.Write(EncryptHelper.FileMd5(AppConfig.basePath + @"WebResource\uploadfile\HTML5中文参考手册.chm") + "<br>");
           Response.Write(EncryptHelper.FileMd5(AppConfig.basePath + @"WebResource\uploadfile\jQuery-api-1.7.1_20120209.chm") + "<br>");
           Response.Write(EncryptHelper.FileMd5(AppConfig.basePath + @"WebResource\uploadfile\W3CSchool.chm") + "<br>");
            
            return View();
        }

    }
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    
}
