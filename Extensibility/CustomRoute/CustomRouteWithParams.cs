using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Extensibility.CustomRoute
{
    public class CustomRouteWithParams : IRouteConstraint
    {
        private readonly string _parameterValue;
        public CustomRouteWithParams(string parameteValue)
        {
            _parameterValue = parameteValue;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                if (value.ToString() == _parameterValue)
                {
                    return true;
                }
            }
            return false;
        }
    }
}