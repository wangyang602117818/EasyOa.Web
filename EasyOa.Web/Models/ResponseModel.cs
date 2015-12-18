using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyOa.Web.Models
{
    //用于验证ModelState的结果，呈现到前台
    public class ResponseModel
    {
        public bool IsValid { get; set; }   //验证结果
        public Dictionary<string, string> Results { get; set; }  //验证的内容,只保留不合法的参数
    }
}