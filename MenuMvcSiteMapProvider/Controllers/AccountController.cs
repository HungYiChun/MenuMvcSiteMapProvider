using MenuMvcSiteMapProvider.Models;
using MvcSiteMapProvider.Web.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MenuMvcSiteMapProvider.Controllers
{
    public class AccountController : Controller
    {
        private MenuModel db = new MenuModel();

        [HttpPost]
        [SiteMapCacheRelease]
        public ActionResult Login(Account Post_Account)
        {
            Session.RemoveAll();

            Account account = db.Account.FirstOrDefault(x => x.Username == Post_Account.Username);

            if (account == null || string.IsNullOrEmpty(Post_Account.Username) || string.IsNullOrEmpty(Post_Account.Password) || account.Password != Post_Account.Password)
            {
                return RedirectToAction("Index", "Home");
            }
            Session["UserName"] = account.Username;
            Session["Role"] = account.Role;
            return View("Success");
        }

        [SiteMapCacheRelease]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        [SiteMapCacheRelease]
        public ActionResult Success()
        {
            return View();
        }
    }
}