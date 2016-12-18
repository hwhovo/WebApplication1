using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CookieController : Controller
    {
        // GET: Cookie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendCookie()
        {
            HttpContext.Response.Cookies["name"].Value = "Poxos";

            return RedirectToAction("ReceiveCookie1");
        }

        public ActionResult ReceiveCookie1()
        {
            string Cookie = HttpContext.Request.Cookies["name"].Value;

            ViewBag.Cookie = Cookie;

            return View();
        }

        public ActionResult ReceiveCookie2()
        {
            string Cookie = HttpContext.Request.Cookies["name"].Value;

            ViewBag.Cookie = Cookie;

            return View();
        }

        public ActionResult SendSession()
        {
            Session["name1"] = "Poxos1";

            return RedirectToAction("ReceiveSession1");
        }

        public ActionResult ReceiveSession1()
        {
            string Cookie = Session["name1"].ToString();

            ViewBag.Cookie = Cookie;

            return View();
        }

        public ActionResult ReceiveSession2()
        {
            string Cookie = Session["name1"].ToString();

            ViewBag.Cookie = Cookie;

            return View();
        }

    }
}