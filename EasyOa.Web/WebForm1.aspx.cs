using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyOa.Common;

namespace EasyOa.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogEnqueue.Enqueue("xxxxx");
            Response.Write("xx");
        }
    }
}