using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyOa.Web.Extentions
{
    public class MyParamsValidatorProvider: DataAnnotationsModelValidatorProvider
    {
        public IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context,
            IEnumerable<Attribute> attributes)
        {
            var obj = base.GetValidators(metadata, context, attributes);
            return obj;
        }
    }
}