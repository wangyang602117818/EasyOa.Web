using EasyOa.Common;
using EasyOa.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyOa.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            string[] str = { " ", "  ", "   ", "    ", "     " };
            string[] lines = System.IO.File.ReadAllLines(Server.MapPath("01.txt"));
            string aname = "", acode = "", sql = "";
            string connStr = "Data Source=127.0.0.1;Initial Catalog=easyoa;User ID=sa;Password=123";
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    foreach (string line in lines)
            //    {
            //        string[] code = line.Split(str, StringSplitOptions.RemoveEmptyEntries);
            //        acode = code[0];
            //        if (code.Length == 2)
            //        {
            //            aname = code[1];
            //        }
            //        else
            //        {
            //            aname = code[2];
            //        }
            //        sql = "insert into sys_area(a_name, a_code, qping, jping)values('" + aname + "'," + acode + ",'" + aname.ToSpell() + "','" + aname.ToSpell(true) + "')";
            //        using (SqlCommand cmd = new SqlCommand(sql, conn))
            //        {
            //            conn.Open();
            //            cmd.ExecuteNonQuery();
            //            System.IO.File.AppendAllText(Server.MapPath("sqls.txt"), sql);
            //            conn.Close();
            //        }
            //    }
            //}

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("我行", "woxing");
            dict.Add("银行", "yinhang");
            string s = "中国人民银行，我行";

            Response.Write(s.ToSpell());
            return View();
        }

    }
}
