using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace InfluencerWEBUI.Controllers
{
    public class BloglarController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        // GET: Bloglar
        #region TR
        public ActionResult TR()
        {
            return View();
        }

        public ActionResult TRPartialBlogCategory()
        {
            return PartialView(db.BlogCategories.Where(x => x.IsActive == true && x.LangTableID == 1).ToList());
        }

        public ActionResult TRPartialBlogList()
        {
            return PartialView(db.Blogs.Include(x => x.BlogCategory).Where(x => x.IsActive == true).ToList().OrderBy(x=>x.Title));
        }

        #endregion
        #region EN
        public ActionResult EN()
        {
            return View();
        }
        public ActionResult ENPartialBlogCategory()
        {
            return PartialView(db.BlogCategories.Where(x => x.IsActive == true && x.LangTableID == 2).ToList());
        }

        public ActionResult ENPartialBlogList()
        {
            return PartialView(db.Blogs.Include(x => x.BlogCategory).Where(x => x.IsActive == true).ToList().OrderBy(x => x.Title));
        }
        #endregion
    }
}