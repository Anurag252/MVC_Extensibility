using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4ActionInvoker.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
      public  DefaultController()
        {
            this.ActionInvoker = new CustomActionInvoker.CustomActionInvoker();
        }

        public ActionResult Index()
        {
           
            return View();
        }
    }
}