using MvcSiteMapProvider.Web.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MenuMvcSiteMapProvider.Controllers
{
    public class HomeController : Controller
    {
        [SiteMapCacheRelease]
        public ActionResult Index()
        {
            return View();
        }
    }
}