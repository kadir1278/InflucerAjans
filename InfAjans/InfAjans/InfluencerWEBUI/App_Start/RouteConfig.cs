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

            #region View
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
            routes.MapRoute(
                name: "TRServisler",
                url: "tr/servislerimiz",
                defaults: new { controller = "Servisler", action = "TR"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "ENServisler",
                url: "en/services",
                defaults: new { controller = "ServisDetay", action = "EN"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "TRServislerDetay",
                url: "tr/servislerimiz/{SeoLink}",
                defaults: new { controller = "ServisDetay", action = "TR", SeoLink = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ENInfluencers",
                url: "en/our-managers",
                defaults: new { controller = "Influencers", action = "EN"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "TRInfluencerlar",
                url: "tr/menajerlerimiz",
                defaults: new { controller = "Influencers", action = "TR"/*, id = UrlParameter.Optional*/ }
            );
            #endregion
            #region PartialView
            routes.MapRoute(
               name: "TRPartialSliderList",
               url: "TRPartialSliderList",
               defaults: new { controller = "Anasayfa", action = "TRPartialSliderList"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "TRPartialAbout",
               url: "TRPartialAbout",
               defaults: new { controller = "Anasayfa", action = "TRPartialAbout"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "ENPartialSliderList",
               url: "ENPartialSliderList",
               defaults: new { controller = "Anasayfa", action = "ENPartialSliderList"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "ENPartialAbout",
               url: "ENPartialAbout",
               defaults: new { controller = "Anasayfa", action = "ENPartialAbout"/*, id = UrlParameter.Optional*/ }
           );
            #endregion
        }
    }
}
