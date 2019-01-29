using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4ActionInvoker.CustomActionInvoker
{
    public class CustomActionInvoker : IActionInvoker
    {
      public  CustomActionInvoker()
        {

        }
        public  bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (actionName.ToUpper().Equals("INDEX"))
            {
                ViewResult result = new ViewResult();
                result.View = result.ViewEngineCollection.FindView(controllerContext, "NotIndex", null).View;
                controllerContext.HttpContext.Response.Write("This is from custom action");
                // InvokeActionResult(controllerContext, result);
                return true;
            }
            else
            {
                return false;
                //return base.InvokeAction(controllerContext, actionName);
            }
        }
    }
}