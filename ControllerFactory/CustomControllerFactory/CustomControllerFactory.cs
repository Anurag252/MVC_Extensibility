using ControllerFactory.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ControllerFactory.CustomControllerFactory
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {

            Ilogger logger = new DefaultLogger();
            DefaultController controller = new DefaultController(logger);
            Type controllerType = Type.GetType(string.Concat("ControllerFactory.Controllers", ".", controllerName, "Controller"));
            IController controllerGeneric = Activator.CreateInstance(controllerType, new[] { logger }) as Controller;
            return controller;
          //  return controllerGeneric;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}