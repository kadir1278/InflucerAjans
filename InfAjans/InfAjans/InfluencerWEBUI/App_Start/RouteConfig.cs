using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InfluencerWEBUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "TurkishAnasayfa",
                url: "tr/",
                defaults: new { controller = "Anasayfa", action = "TR"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "TurkishAnasayfa2",
                url: "",
                defaults: new { controller = "Anasayfa", action = "TR"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "ENAnasayfa",
                url: "en/",
                defaults: new { controller = "Anasayfa", action = "EN"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "TurkishHakkimizda",
                url: "tr/hakkimizda",
                defaults: new { controller = "Hakkimizda", action = "TR"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "ENHakkimizda",
                url: "en/about",
                defaults: new { controller = "Hakkimizda", action = "EN"/*, id = UrlParameter.Optional*/ }
            );
        }
    }
}
