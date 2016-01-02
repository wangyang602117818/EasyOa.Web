using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyOa.Common;

namespace EasyOa.Web.Filters
{
    ///<summary>
    ///自定义mvc异常处理
    ///</summary>
    public class MyHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //设置错误已处理
            //filterContext.ExceptionHandled = true;
            //记录错误日志
            //LogHelper.ErrorLog(filterContext.Exception);
            //返回
            
        }
    }
}