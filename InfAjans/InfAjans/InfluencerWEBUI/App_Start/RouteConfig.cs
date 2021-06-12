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
                defaults: new { controller = "Servisler", action = "EN"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "TRServislerDetay",
                url: "tr/servislerimiz/{SeoLink}",
                defaults: new { controller = "ServisDetay", action = "TR", SeoLink = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ENServislerDetay",
                url: "en/services/{SeoLink}",
                defaults: new { controller = "ServisDetay", action = "EN", SeoLink = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ENInfluencers",
                url: "en/our-managers",
                defaults: new { controller = "Influencers", action = "EN"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "TRInfluencers",
                url: "tr/menajerlerimiz",
                defaults: new { controller = "Influencers", action = "TR"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "TRCozumOrtaklarimiz",
                url: "tr/cozum-ortaklarimiz",
                defaults: new { controller = "CozumOrtaklarimiz", action = "TR"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "ENCozumOrtaklarimiz",
                url: "en/our-solution-partners",
                defaults: new { controller = "CozumOrtaklarimiz", action = "EN"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "TRBloglar",
                url: "tr/bloglar",
                defaults: new { controller = "Bloglar", action = "TR"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "ENBloglar",
                url: "en/blogs",
                defaults: new { controller = "Bloglar", action = "EN"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "TRBloglarDetay",
                url: "tr/bloglar/{SeoLink}",
                defaults: new { controller = "Bloglar", action = "TR", SeoLink = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ENBloglarDetay",
                url: "en/blogs/{SeoLink}",
                defaults: new { controller = "BloglarDetay", action = "EN", SeoLink = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TRIletisim",
                url: "tr/iletisim",
                defaults: new { controller = "Iletisim", action = "TR"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "TRContact",
                url: "en/contacts",
                defaults: new { controller = "Iletisim", action = "EN"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "TRBasvuruForm",
                url: "tr/basvuru-formu",
                defaults: new { controller = "BasvuruForm", action = "TR"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "ENApplicationForm",
                url: "en/application-form",
                defaults: new { controller = "BasvuruForm", action = "EN"/*, id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                name: "ENMenajerDetay",
                url: "en/our-managers/{SeoLink}",
                defaults: new { controller = "MenajerDetay", action = "EN", SeoLink = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TRMenajerDetay",
                url: "tr/menajerlerimiz/{SeoLink}",
                defaults: new { controller = "MenajerDetay", action = "TR", SeoLink = UrlParameter.Optional }
            );
            #endregion
            #region PartialView
            routes.MapRoute(
               name: "TRPartialSliderList",
               url: "TRPartialSliderList",
               defaults: new { controller = "Anasayfa", action = "TRPartialSliderList"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "TRPartialServiceList",
               url: "TRPartialServiceList",
               defaults: new { controller = "Anasayfa", action = "TRPartialServiceList"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "TRPartialAbout",
               url: "TRPartialAbout",
               defaults: new { controller = "Anasayfa", action = "TRPartialAbout"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "TRPartialOurSolitionPartnerList",
               url: "TRPartialOurSolitionPartnerList",
               defaults: new { controller = "Anasayfa", action = "TRPartialOurSolitionPartnerList"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "ENPartialSliderList",
               url: "ENPartialSliderList",
               defaults: new { controller = "Anasayfa", action = "ENPartialSliderList"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "ENPartialServiceList",
               url: "ENPartialServiceList",
               defaults: new { controller = "Anasayfa", action = "ENPartialServiceList"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "ENPartialAbout",
               url: "ENPartialAbout",
               defaults: new { controller = "Anasayfa", action = "ENPartialAbout"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "ENPartialOurSolitionPartnerList",
               url: "ENPartialOurSolitionPartnerList",
               defaults: new { controller = "Anasayfa", action = "ENPartialOurSolitionPartnerList"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "TRPartialBlogCategory",
               url: "TRPartialBlogCategory",
               defaults: new { controller = "Bloglar", action = "TRPartialBlogCategory"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "TRPartialBlogList",
               url: "TRPartialBlogList",
               defaults: new { controller = "Bloglar", action = "TRPartialBlogList"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "ENPartialBlogCategory",
               url: "ENPartialBlogCategory",
               defaults: new { controller = "Bloglar", action = "ENPartialBlogCategory"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "ENPartialBlogList",
               url: "ENPartialBlogList",
               defaults: new { controller = "Bloglar", action = "ENPartialBlogList"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "PartialContact",
               url: "PartialContact",
               defaults: new { controller = "Iletisim", action = "PartialContact"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "ENPartialContact",
               url: "ENPartialContact",
               defaults: new { controller = "Iletisim", action = "ENPartialContact"/*, id = UrlParameter.Optional*/ }
           );
            routes.MapRoute(
               name: "PartialSocialMedia",
               url: "PartialSocialMedia",
               defaults: new { controller = "Anasayfa", action = "PartialSocialMedia"/*, id = UrlParameter.Optional*/ }
           );
            #endregion
            routes.MapRoute(
                name: "NotFound404",
                url: "{*url}",
                defaults: new { controller = "Error", action = "NotFound404" }
            );
        }
    }
}
