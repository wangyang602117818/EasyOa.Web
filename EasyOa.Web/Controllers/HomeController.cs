using EasyOa.Common;
using EasyOa.Common.Util;
using EasyOa.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyOa.Common.Properties;

namespace EasyOa.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var url = "http://127.0.0.1:1111/Handler1.ashx?a=111&b=222";
            //var url = "http://127.0.0.1:1111/WebForm1.aspx?a=111&b=222";
            var url = "http://127.0.0.1:1111/Home/Test?a=111&b=222";
            HttpRequestHelper.Post(url, "c=333&d=444",null,RequestContentType.UrlEncoded,null);
            //HttpRequestHelper.Get("http://localhost:26530/rtfapi/imageDMZ.ashx", "aid=111&fid=222");
            return View();
        }

        [HttpPost]
        public ActionResult Test(string a,string b,string c,string d)
        {
            return null;
        }
        public ActionResult Index1(
            [Required(ErrorMessage = "name is required")]
            string Name)
        {
            string str = null;
            RequiredAttribute requiredAttribute = new RequiredAttribute(){ ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required" };
            bool b = requiredAttribute.IsValid(str);
            ValidationContext validationContext=new ValidationContext(typeof(string));
            ValidationResult validation = requiredAttribute.GetValidationResult(str, validationContext);
            return Content("ok");
        }
    }

    public class Cat
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(3, MinimumLength = 2, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLength")]
        public string Name { get; set; }
        [Range(10, 50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Range")]
        public int Age { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        public string Email { get; set; }
    }
}
