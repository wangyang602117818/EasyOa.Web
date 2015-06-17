using EasyOa.Common;
using EasyOa.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyOa.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {

            return View();
        }
    }
}
