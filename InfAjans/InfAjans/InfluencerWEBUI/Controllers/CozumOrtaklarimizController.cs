using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfluencerWEBUI.Controllers
{
    public class CozumOrtaklarimizController : Controller
    {
        private InfluencerContext db = new InfluencerContext();
        // GET: CozumOrtaklarimiz
        #region TR
        public ActionResult TR()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageName == "Çözüm Ortaklarımız").FirstOrDefault();
            return View(db.Brands.Where(x => x.IsActive == true && x.LangTableID == 1).ToList().OrderByDescending(x => x.ID));
        }
        #endregion
        #region EN
        public ActionResult EN()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageName == "Our Solution Partners").FirstOrDefault();
            return View(db.Brands.Where(x => x.IsActive == true && x.LangTableID == 1).ToList().OrderByDescending(x => x.ID));
        }
        #endregion
    }
}