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
            LogRabbitMq.Enqueue("aaaabbbbcccc");
            return View();
        }

    }
    
}
