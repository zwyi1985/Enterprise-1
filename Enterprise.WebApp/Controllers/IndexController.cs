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
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult CreateImg()
        {
            string codeStr = code.CreateRandomCode();
            byte[] buffer = code.CreateImg(codeStr);
            return File(buffer, @"image/jpeg");
        }
    }
}