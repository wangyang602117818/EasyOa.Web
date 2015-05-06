using EasyOa.Common;
using EasyOa.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyOa.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            try
            {
                int a = 1;
                int b = 0;
                int c = a / b;
            }
            catch (Exception ex) {
                LogHelper.WriteException(ex);
            }
            return View();
        }

    }
}
