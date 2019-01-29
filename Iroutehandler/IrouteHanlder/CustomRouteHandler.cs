using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Iroutehandler.IrouteHanlder
{
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
            if(context.Application["visists"] == null)
            context.Application["visists"] = "0";
            else
                context.Application["visists"] = Convert.ToInt32(context.Application["visists"]) + 1;

            context.Response.Redirect("Default/Index");

            //if(blockingIps.Contains("India"))
            //context.AddError(new Exception("My custom erorr from Iroutehandler"));

        }
    }
}