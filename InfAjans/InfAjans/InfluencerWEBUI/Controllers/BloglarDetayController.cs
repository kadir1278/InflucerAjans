using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace InfluencerWEBUI.Controllers
{
    public class BloglarDetayController : Controller
    {
        private InfluencerContext db = new InfluencerContext();
        // GET: BloglarDetay
        #region TR
        public ActionResult TR(string SeoLink)
        {
            ViewBag.Seo = db.Blogs.Where(x => x.IsActive == true && x.Slug == SeoLink).FirstOrDefault();
            return View(db.Blogs.Include(x => x.BlogCategory).Include(x => x.BlogDetails).Where(x => x.IsActive == true && x.Slug == SeoLink).FirstOrDefault());
        }
        #endregion
        #region EN
        public ActionResult EN(string SeoLink)
        {
            ViewBag.Seo = db.Blogs.Where(x => x.IsActive == true && x.Slug == SeoLink).FirstOrDefault();
            return View(db.Blogs.Include(x => x.BlogCategory).Include(x => x.BlogDetails).Where(x => x.IsActive == true && x.Slug == SeoLink).FirstOrDefault());
        }
        #endregion
    }
}