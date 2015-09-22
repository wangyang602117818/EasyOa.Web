using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyOa.Common;

namespace EasyOa.Web.Controllers.Hr
{
    public class HrMaintainController : Controller
    {
        /// <summary>
        /// 员工信息添加
        /// </summary>
        /// <returns></returns>
        public ActionResult EmpAdd()
        {
            return View();
        }
        /// <summary>
        /// 合同添加
        /// </summary>
        /// <returns></returns>
        public ActionResult EmpContract()
        {
            return View();
        }
        /// <summary>
        /// 家庭成员添加
        /// </summary>
        /// <returns></returns>
        public ActionResult EmpFamily()
        {
            return View();
        }
    }
}
