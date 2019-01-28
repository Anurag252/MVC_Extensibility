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
# 2) Extending IRoutehanlder

earlier in asp.net webforms , httphanlders were registered based on extension of files for example :-
   
    <httpHandlers>
    <add verb="*" path="*.jpg" type="MyJpgHandler"/>
    </httpHandlers>
    
In MVC , hanlders can work on custom logic based on different routes . also they excute once per request unlike action methods which may execute multiple times
    
Steps to register the handlers .
Step 1 :
 Implement IRouteHandler:-
 
     public class CustomRouteHandler :  IRouteHandler 
     {
      public  List<string> blockingIps;
       public CustomRouteHandler(List<string> blockingIps)
        {
            this.blockingIps = blockingIps;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            BlockIpsHttpHandler handler = new BlockIpsHttpHandler(blockingIps);
            return handler;
        }
    }
    
 Step2:- Custom write your own handler :-
  
    public class BlockIpsHttpHandler : IHttpHandler
    {
        private List<string> blockingIps;

        public BlockIpsHttpHandler(List<string> blockingIps)
        {
            this.blockingIps = blockingIps;
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            string ipaddress = context.Request.UserHostAddress;

           // if(blockingIps.Contains("India"))
            //context.AddError(new Exception("My custom erorr from Iroutehandler"));
            
        }
    }
    
 Step 3:-
 register in routeconfig.cs
 
     RouteTable.Routes.Add(new Route("testmycustomRoute", new CustomRouteHandler(new List<string>() { "India"})));

