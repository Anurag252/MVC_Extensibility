using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6AuthorizationFilter.Authorize
{
    public class CustomAuthorizeattribute : AuthorizeAttribute
    {
        Entities context = new Entities(); // my entity  
        private readonly string[] allowedroles = { "Admin" };
        public CustomAuthorizeattribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var role in allowedroles)
            {
                var user = context.AppUser.Where(m => m.ToString() == HttpContext.Current.User.Identity.Name/* getting user form current context */);
                 
                if (user.Count() > 0)
                {
                    authorize = true; /* return true if Entity has current user(active) with specific role */
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }

     public class Entities
    {
       public List<string> AppUser = new List<string>();
        public Entities()
        { AppUser.Add("TestUser"); }
    }
}