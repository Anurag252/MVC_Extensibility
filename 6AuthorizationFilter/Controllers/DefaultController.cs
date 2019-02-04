using _6AuthorizationFilter.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6AuthorizationFilter.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorizeattribute]
        public ActionResult test()
        {
            return View();
        }
    }
}