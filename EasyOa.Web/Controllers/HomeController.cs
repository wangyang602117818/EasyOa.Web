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
        //
        // GET: /Home/
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Edit()
        {

            Dictionary<string, string[]> dict = FileHelper.ReadFileSplit(AppConfig.basePath + "01.txt");
            foreach (string key in dict.Keys)
            {
                Department de = new Department()
                {
                    De_Name = dict[key][0],
                    De_Code = key,
                    QPin = dict[key][0].ToSpell(),
                    JPin = dict[key][0].ToSpell(true)
                };
                Response.Write(de.Insert() + "<br>");
            }

            return View();
        }
    }
}
