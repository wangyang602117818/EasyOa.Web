using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Http.ModelBinding;
using EasyOa.Common;

namespace EasyOa.Web.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 检测ModelState,对mvc框架自动Model验证以后的结果进行分析
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            List<string> valid_result = new List<string>();
            //if (!actionContext.ModelState.IsValid)
            //{
            //    foreach (KeyValuePair<string, ModelState> item in actionContext.ModelState)
            //    {
            //        if (item.Value.Errors.Count > 0) valid_result.Add(item.Value.Errors[0].ErrorMessage);
            //    }
            //    //throw new ParamsException(ErrorCode.General.params_valid_fault, valid_result);
            //}
        }

    }
}