using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enterprise.WebApp.Models
{
    public class ErrorExceptionAttribute: HandleErrorAttribute
    {
        //创建队列
        public static Queue<Exception> ExceptionQueue = new Queue<Exception>();

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Exception Ex = filterContext.Exception;
            //把故障写入队列
            ExceptionQueue.Enqueue(Ex);
            //跳转错误页
            filterContext.HttpContext.Response.Redirect("/Error.html");
        }
    }
}