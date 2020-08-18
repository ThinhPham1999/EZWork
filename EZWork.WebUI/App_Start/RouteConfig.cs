using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EZWork.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                , new[] { "EZWork.WebUI.Controllers" }
            );

            routes.MapRoute(null,
                "",
                new
                    {
                        controller = "Seller",
                        action = "ListSeller",
                        category = (string)null,
                        page = 1
                    }
            );

            routes.MapRoute(null,
                "Page{page}",
                new { controller = "Seller", action = "ListSeller", category = (string)null },
                new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{category}",
                new { controller = "Seller", action = "ListSeller", page = 1 }
            );

            routes.MapRoute(null,
            "{category}/Page{page}",
            new { controller = "Seller", action = "ListSeller" },
            new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
