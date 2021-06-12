using CNR.WEBUI.Content.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InfluencerWEBUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();
            HttpException httpException = exception as HttpException;
            if (httpException != null)
            {
                LogInfo log = new LogInfo
                {
                    Url = Request.Url.ToString(),
                    HataMesajı = httpException.Message,
                    EklenmeTarihi = DateTime.Now,
                    Tarayici = Request.Browser.Browser,
                    Dil = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2)
                };

                switch (httpException.GetHashCode())
                {
                    case 400:
                        Response.Redirect("/Error/NotFound400/");
                        break;
                    case 403:
                        Response.Redirect("/Error/NotFound403/");
                        break;
                    case 404:
                        Response.Redirect("/Error/NotFound404/");
                        break;
                    case 500:
                        Response.Redirect("/Error/NotFound500/");
                        break;
                    case 503:
                        Response.Redirect("/Error/NotFound503/");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
