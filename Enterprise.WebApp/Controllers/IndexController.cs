using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enterprise.WebApp.Controllers
{
    public class IndexController : Controller
    {
        Common.ValidateCode code = new Common.ValidateCode();

        // GET: Index

        [Route("")]
        public ActionResult Index()
        {
            ViewBag.Title = "河南龙翔供电服务有限公司";
           
            return View();
        }

        [Route("about")]
        public ActionResult About()
        {
            ViewBag.Title = "关于我们";
            return View();
        }
    }
}