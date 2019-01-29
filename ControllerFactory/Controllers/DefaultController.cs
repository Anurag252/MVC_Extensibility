using ControllerFactory.CustomControllerFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerFactory.Controllers
{
    public class DefaultController : Controller
    {
        Ilogger _log;
        // GET: Default
      public  DefaultController(Ilogger log)
        {
            _log = log;
           
        }
        public ActionResult Index()
        {
            _log.log();
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}