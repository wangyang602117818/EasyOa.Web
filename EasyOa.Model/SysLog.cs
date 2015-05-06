using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyOa.Model
{
    public class SysLog
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string remark { get; set; }
        public DateTime logDate { get; set; }
        public string M1(string i)
        {
            return "M1" + i;
        }
    }
}