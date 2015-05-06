using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    [Flags]
    public enum AcceptType
    {
        [Description("text/html")]
        html = 1,
        [Description("application/xhtml+xml")]
        xhtml = 2,
        [Description("application/xml")]
        xml = 4,
        [Description("application/json")]
        json = 8,
        [Description("image/*")]
        img = 16,
        [Description("*/*")]
        all = 32
    }
}
