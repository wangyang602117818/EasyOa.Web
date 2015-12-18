using System.Web;
using System.Web.Mvc;
using EasyOa.Web.Filters;

namespace EasyOa.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //这是mvc中处理错误的Attribute
            filters.Add(new MyHandleErrorAttribute());
            //这是检测方法参数是否为null的Attribute
            filters.Add(new CheckParamsForNullAttribute());
            //这是检测ModelState的Attribute
            filters.Add(new ValidateModelStateAttribute());

        }
    }
}