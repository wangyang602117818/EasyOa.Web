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

namespace EasyOa.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Cat cat)
        {
            return View();
        }
    }

    public class Cat
    {
        [Required(ErrorMessage = "name is required")]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "范围错误")]
        public string Name { get; set; }
        [Range(10,50,ErrorMessage = "数据范围错误")]
        public int Age { get; set; }
        [Required(ErrorMessage = "必填想")]
        public string Email { get; set; }
    }
}
