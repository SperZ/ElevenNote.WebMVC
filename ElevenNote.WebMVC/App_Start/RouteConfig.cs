using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ElevenNote.WebMVC
{
    public class RouteConfig // changes the route of the startup page
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Note", action = "Index", id = UrlParameter.Optional } // here is where to do it change the controller 
            );
        }
    }
}
