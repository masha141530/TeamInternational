using MvcUi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcUi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new
                {
                    customConstraint = new UserAgentConstraint("Chrome")
                }
            );
            routes.MapRoute("ChromeRoute", "{*catchall}",
            new { controller = "Home", action = "Index" },
            new
            {
                customConstraint = new UserAgentConstraint("Chrome")
            }
            );
        }
    }
}
