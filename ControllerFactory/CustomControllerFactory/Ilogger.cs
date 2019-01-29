using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerFactory.CustomControllerFactory
{
    public interface Ilogger
    {
        void log();
    }

    public class DefaultLogger : Ilogger
    {
        public void log()
        {
            HttpContext.Current.Response.Redirect("Test/test");
        }
    }
}