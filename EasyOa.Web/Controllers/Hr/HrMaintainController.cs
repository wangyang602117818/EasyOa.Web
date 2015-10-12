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
        [HttpGet]
        public ActionResult EmpAdd()
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
        /// <summary>
        /// 教育信息添加
        /// </summary>
        /// <returns></returns>
        public ActionResult EmpEducation()
        {
            return View();
        }
        /// <summary>
        /// 工作经历
        /// </summary>
        /// <returns></returns>
        public ActionResult EmpWorkExperience()
        {
            return View();
        }
        /// <summary>
        /// 合同添加
        /// </summary>
        /// <returns></returns>
        public ActionResult HrContract()
        {
            return View();
        }
        /// <summary>
        /// 奖惩信息添加
        /// </summary>
        /// <returns></returns>
        public ActionResult HrAward()
        {
            return View();
        }
        /// <summary>
        /// 培训信息添加
        /// </summary>
        /// <returns></returns>
        public ActionResult HrLearn()
        {
            return View();
        }
        /// <summary>
        /// 添加调用信息
        /// </summary>
        /// <returns></returns>
        public ActionResult HrTransfer()
        {
            return View();
        }
    }
}
