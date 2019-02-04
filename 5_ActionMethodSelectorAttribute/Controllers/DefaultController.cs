using _5_ActionMethodSelectorAttribute.ActionMethodSelectorAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5_ActionMethodSelectorAttribute.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        [CustomActionMethodSelectorAttribute]
        //http://localhost:62416/default/index
        public ActionResult Index()
        {
            return View();
        }
    }
}