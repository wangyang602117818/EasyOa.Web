using EasyOa.Common;
using EasyOa.Model;
using System;
using System.Collections.Generic;
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
            //SysLog sysLog = new SysLog { name = "张三", remark = "登录成功" };
            //EasyOa.Common.LogHelper.WriteLog(sysLog);
            LogHelper.WriteException(new Exception("错误"));
            
            return View();
        }

    }
}
