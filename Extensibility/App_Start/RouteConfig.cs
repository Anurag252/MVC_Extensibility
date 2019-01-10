using Extensibility.CustomRoute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace Extensibility
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("CustomRoute", typeof(CustomRouteConstraint));
            constraintsResolver.ConstraintMap.Add("CustomRouteWithParameter", typeof(CustomRouteWithParams));
            routes.MapMvcAttributeRoutes(constraintsResolver);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
