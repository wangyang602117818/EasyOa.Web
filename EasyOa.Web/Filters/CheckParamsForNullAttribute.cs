using System;
using System.Collections.Generic;
using System.Linq;
using EasyOa.Common;
using EasyOa.Model;
using System.Web.Mvc;

namespace EasyOa.Web.Filters
{
    /// <summary>
    /// 检测方法的参数是否为null
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CheckParamsForNullAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Action运行前，如果验证不通过，
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            string userIp = actionContext.HttpContext.Request.UserHostAddress;  //用户ip地址
            string controller = actionContext.RouteData.Values["controller"].ToString();  //用户访问的controller
            string action = actionContext.RouteData.Values["action"].ToString();  //用户访问的action 
            // actionContext.Result=new ContentResult(){Content = ""};
            //访问日志，遇到不合法的Json格式，参数也会是null
            LogHelper.InfoLog("用户[" + userIp + "]请求[/" + controller + "/" + action + "],参数:" + JsonSerializerHelper.Serialize(actionContext.ActionParameters));

            Dictionary<string, string> valid_result = CheckParams(actionContext.ActionParameters);

            var s = "";
            //IEnumerable<HttpFilter> filters = FilterProviders.Providers.GetFilters(actionContext.ActionDescriptor.ControllerDescriptor, actionContext.ActionDescriptor);
            //if (valid_result.Count > 0)
            //{

            //   // throw new ParamsException(ErrorCode.General.invalid_params, valid_result);
            //}

        }
        /// <summary>
        /// 传入请求参数，返回不合法的参数列表
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public Dictionary<string, string> CheckParams(IDictionary<string, object> dictionary)
        {
            Dictionary<string, string> invalid_params = new Dictionary<string, string>();
            foreach (KeyValuePair<string, object> keyValuePair in dictionary)
            {
                if (keyValuePair.Value == null) invalid_params.Add(keyValuePair.Key, keyValuePair.Value.ToString());
            }
            return invalid_params;
        }
        /// <summary>
        /// Action方法运行结束后返回值
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        //public override void OnExecuted(ActionExecutedContext actionExecutedContext)
        //{
        //    //if (actionExecutedContext.Response != null)
        //    //{
        //    //    var httpContext = (actionExecutedContext.Response.Content as ObjectContent).Value;
        //    //    //返回日志
        //    //    LogHelper.InfoLog("响应:" + JsonSerializerHelper.Serialize(httpContext));
        //    //}


        //}
    }
}