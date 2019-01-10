# MVC_Extensibility

# 1) Extending IRouteConstraint
 
 a) Create a custom class inheriting from  IRouteConstraint
 
 b) Code implementation 
    
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
        
 
 C) In RegisterRoutes
       
       var constraintsResolver = new DefaultInlineConstraintResolver();
       constraintsResolver.ConstraintMap.Add("CustomRoute", typeof(CustomRouteConstraint));
       constraintsResolver.ConstraintMap.Add("CustomRouteWithParameter", typeof(CustomRouteWithParams));
       
  d) Use it as :- 
           
        [Route("Mvctest/{name:CustomRouteWithParameter(test)}")]

        public ActionResult Index(string name)
        {
        return View();
        }
