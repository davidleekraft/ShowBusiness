using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UnhandledExceptionProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "New User",
                url: "SignUp",
                defaults: new { controller = "User", action = "Create" }
                );
            
            routes.MapRoute(
                name: "Create",
                url: "create",
                defaults: new { controller = "Home", action = "Create" }
                );

            routes.MapRoute(
                name: "Browse",
                url: "browse",
                defaults: new { controller = "Home", action = "Browse" }
                );

            routes.MapRoute(
                name: "Props",
                url: "index",
                defaults: new { controller = "Prop", action = "Index" }
                );

            routes.MapRoute(
                name: "Dash",
                url: "dash",
                defaults: new { controller = "Home", action = "Index" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}