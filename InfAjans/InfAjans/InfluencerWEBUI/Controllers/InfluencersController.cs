using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfluencerWEBUI.Controllers
{
    public class InfluencersController : Controller
    {
        private InfluencerContext db = new InfluencerContext();
        #region TR
        public ActionResult TR()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageName == "Menajerlerimiz").FirstOrDefault();
            return View(db.Inflencers.Where(x => x.IsActive == true && x.LangTableID == 1).ToList().OrderBy(x => x.Name + " " + x.Surname));
        }
        #endregion
        #region EN
        public ActionResult EN()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageName == "Our Managers").FirstOrDefault();
            return View(db.Inflencers.Where(x => x.IsActive == true && x.LangTableID == 2).ToList().OrderBy(x => x.Name + " " + x.Surname));
        }
        #endregion
    }
}