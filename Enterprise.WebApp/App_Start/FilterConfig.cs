using Enterprise.WebApp.Models;
using System.Web;
using System.Web.Mvc;

namespace Enterprise.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //ErrorExceptionAttribute
            // 在最终需要改为使用自定义错误处理器
            filters.Add(new HandleErrorAttribute());
        }
    }
}
