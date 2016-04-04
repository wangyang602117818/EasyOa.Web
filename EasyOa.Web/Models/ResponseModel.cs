using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyOa.Web.Models
{
    public class ResponseBaseModel<T>
    {
        public Enum code { get; set; }
        public string msg { get; set; }
        public T result { get; set; }

    }
}