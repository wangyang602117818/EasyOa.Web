using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Services.Description;
using EasyOa.Common;
using EasyOa.Common.Properties;

namespace EasyOa.Web.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index(
            [MinLength(3, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
            string name,
            int? age 
        )
        {
            
            Response.Write("<br>ok");

            return View();
        }

        public ActionResult M1()
        {
            ModelMetadata metadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(string));
            RangeAttribute sla = new RangeAttribute(1, 10) { ErrorMessage = "fanweicuowu" };
            RangeAttributeAdapter range = new RangeAttributeAdapter(metadata, ControllerContext, sla);

            IEnumerable<ModelValidationResult> results = range.Validate(22);


            return Content("123");
        }

    }
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

}
