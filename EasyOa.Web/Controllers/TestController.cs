using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyOa.Common;

namespace EasyOa.Web.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            List<Person> list = new List<Person>()
                {
                    new Person(){Age=12,Name = "张三"},
                    new Person(){Age = 13,Name = "李四"}
                };
            for (int i = 1; i <= 2; i++)
            {
                LogEnqueue.Enqueue(BinarySerializerHelper.ObjectToByteArray("aaaanbbccc"));
            }

            for (int i = 0; i < 5; i++)
            {
                LogEnqueue.Enqueue(list);
            }
            return View();
        }

    }
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    
}
