using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace InfluencerWEBUI.Controllers
{
    public class MenajerDetayController : Controller
    {
        private InfluencerContext db = new InfluencerContext();
        // GET: MenajerDetay
        #region TR
        public ActionResult TR(string SeoLink)
        {
            ViewBag.Seo = db.Inflencers.Where(x => x.IsActive == true && x.Slug == SeoLink).FirstOrDefault();
            return View(db.Inflencers.Include(x=>x.InfluencerVideos).Where(x=>x.IsActive==true && x.LangTableID==1 && x.Slug==SeoLink).FirstOrDefault());
        }
        #endregion
        #region En
        public ActionResult EN(string SeoLink)
        {
            ViewBag.Seo = db.Inflencers.Where(x => x.IsActive == true && x.Slug == SeoLink).FirstOrDefault();
            return View(db.Inflencers.Include(x => x.InfluencerVideos).Where(x => x.IsActive == true && x.LangTableID == 2 && x.Slug == SeoLink).FirstOrDefault());
        }
        #endregion
    }
}