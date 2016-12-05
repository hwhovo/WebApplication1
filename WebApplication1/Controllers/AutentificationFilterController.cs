using AuthFilterApp.Filters;
using BookStore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class AutentificationFilterController:Controller
    {

        [MyAuthorize(Roles = "admin, moderator", Users = "eugene, sergey")]
        public ActionResult Index()
        {
            return View();
        }
    }
}