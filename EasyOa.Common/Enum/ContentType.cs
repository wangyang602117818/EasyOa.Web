using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    /// <summary>
    /// 请求contenttype
    /// </summary>
    public enum RequestContentType
    {
        /// <summary>
        /// 适合参数以url编码方式的，post方式但是没有上传文件的
        /// </summary>
        [Description("application/x-www-form-urlencoded")]
        urlencoded,
        /// <summary>
        /// 适合有上传文件的
        /// </summary>
        [Description("multipart/form-data")]
        formdata,
        /// <summary>
        /// 适合特殊情况，以xml方式传参数
        /// </summary>
        [Description("application/xml;charset=utf-8")]
        xml,
        /// <summary>
        /// 适合特殊情况，以json方式传参数
        /// </summary>
        [Description("application/json;charset=utf-8")]
        json,


    }
    /// <summary>
    /// 响应contenttype
    /// </summary>
    public enum ResponseContentType
    {
        /// <summary>
        /// 默认以html方式响应
        /// </summary>
        [Description("text/html;charset=utf-8")]
        html,
        /// <summary>
        /// 以文本方式响应
        /// </summary>
        [Description("text/plain;charset=utf-8")]
        text,
        /// <summary>
        /// 以脚本形式响应
        /// </summary>
        [Description("text/javascript")]
        javascript,
        /// <summary>
        /// 以css形式响应
        /// </summary>
        [Description("text/css")]
        css,
        /// <summary>
        /// 图像形式响应
        /// </summary>
        [Description("image/jpeg")]
        jpg,
        [Description("image/gif")]
        gif,
        [Description("image/png")]
        png,
    }
}
