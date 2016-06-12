using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvc05
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{i1}/{i2}/{remarks}",
                defaults: new
                {
                    controller = "Cal",
                    action = "CalAction",
                    i1 = UrlParameter.Optional,
                    i2 = UrlParameter.Optional,
                    remarks = UrlParameter.Optional
                }
            );
        }
    }
}
