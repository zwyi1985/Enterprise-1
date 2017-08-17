using Enterprise.WebApp.Models;
using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Enterprise.WebApp
{
    public class MvcApplication :  System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();//读取log4net配置信息

            //华丽的开始分割线
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //华丽的结束分割线


            //获取存放日志文件路径
            string filePath = Server.MapPath("/log/");
            //从线程池调用一个线程
            ThreadPool.QueueUserWorkItem((a)=> {
                while (true) {
                    if (ErrorExceptionAttribute.ExceptionQueue.Count > 0)
                    {
                        Exception Ex = ErrorExceptionAttribute.ExceptionQueue.Dequeue();
                        if (Ex != null)
                        {
                            ILog logger = LogManager.GetLogger("ErrorLog");
                            logger.Error(Ex.ToString());
                        }
                        else {
                            //线程休息3秒
                            Thread.Sleep(3000);
                        }
                    }
                    else {
                        //线程休息3秒
                        Thread.Sleep(3000);
                    }
                }
            }, filePath);
        }
    }
}
