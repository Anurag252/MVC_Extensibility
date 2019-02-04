using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace _5_ActionMethodSelectorAttribute.ActionMethodSelectorAttribute
{
    public class CustomActionMethodSelectorAttribute : System.Web.Mvc.ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {

            return controllerContext.HttpContext.Request.Headers["P-Electronics"] != null;
            //throw new NotImplementedException();
        }
    }
}