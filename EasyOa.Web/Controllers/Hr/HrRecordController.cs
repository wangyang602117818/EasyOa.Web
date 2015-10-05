using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyOa.Web.Controllers.Hr
{
    public class HrRecordController : Controller
    {
        /// <summary>
        /// 人员列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Employee()
        {
            return View();
        }
        /// <summary>
        /// 合同列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Contract()
        {
            return View();
        }

    }
}
