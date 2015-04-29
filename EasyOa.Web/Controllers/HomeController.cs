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
            //057ab0699290b52e4b0c2544fbed43ca
            //b36a77323d66fa69e3aa6a94be575304
            NameValueCollection nv = new NameValueCollection { 
               {"PartnerId","4"},
                {"OrderNumber","[\"1036349423\"]"},
                {"Sn","575b94b81eb90471bd195e783c52c552"}
            };
            string url = "http://openapi.etaoshi.com:8080/v1/api/Orders/Status";
            string paras = HttpRequestHelper.BuildParas(nv);
            string res = HttpRequestHelper.Get(url, paras);
            
            Response.Write(res);
            return View();
        }

    }
}
