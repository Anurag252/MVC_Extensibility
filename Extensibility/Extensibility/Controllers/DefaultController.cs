using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Extensibility.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        [Route("MvcTest/other/{name:CustomRoute}")]
        public ActionResult OtherPage(string name)
        {
            return View();
        }



        [Route("Mvctest/{name:CustomRouteWithParameter(test)}")]

        public ActionResult Index(string name)
        {
        return View();
        }
    }
}