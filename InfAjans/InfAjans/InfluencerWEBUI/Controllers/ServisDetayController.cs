using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfluencerWEBUI.Controllers
{
    public class ServisDetayController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        // GET: ServisDetay
        #region TR
        public ActionResult TR(string SeoLink)
        {
            ViewBag.Seo = db.Services.Where(x => x.IsActive == true && x.Slug == SeoLink).FirstOrDefault();
            return View(db.Services.Where(x=>x.Slug==SeoLink).FirstOrDefault());
        }
        #endregion
        #region EN
        public ActionResult EN(string SeoLink)
        {
            ViewBag.Seo = db.Services.Where(x => x.IsActive == true && x.Slug == SeoLink).FirstOrDefault();
            return View(db.Services.Where(x => x.Slug == SeoLink).FirstOrDefault());
        }
        #endregion
    }
}