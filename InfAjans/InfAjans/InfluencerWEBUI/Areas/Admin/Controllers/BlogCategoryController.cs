using Influencer.Entities.Entity;
using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InfluencerWEBUI.Areas.Admin.Controllers
{
    public class BlogCategoryController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddBlogCategory()
        {
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlogCategory(BlogCategory BlogCategory)
        {
            if (ModelState.IsValid)
            {
                BlogCategory.IsActive = true;
                BlogCategory.LastDateTime = DateTime.Now;
                db.BlogCategories.Add(BlogCategory);
                db.SaveChanges();
                return RedirectToAction("BlogCategory", "Dashboard");
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(BlogCategory);
        }
        #endregion
        #region Update
        public ActionResult UpdateBlogCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCategory BlogCategory = db.BlogCategories.Find(id);
            if (BlogCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(BlogCategory);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateBlogCategory(int id, BlogCategory BlogCategory)
        {
            var AU = db.BlogCategories.Find(id);
            if (ModelState.IsValid)
            {
                AU.Title = BlogCategory.Title;
                AU.LangTableID = BlogCategory.LangTableID;
                AU.Description = BlogCategory.Description;
                AU.IsActive = BlogCategory.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("BlogCategory", "Dashboard");

            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");
            return View(BlogCategory);
        }
        #endregion
        #region Delete
        public ActionResult DeleteBlogCategory(int ID)
        {
            BlogCategory BlogCategory = db.BlogCategories.Where(x => x.ID == ID).SingleOrDefault();
            db.BlogCategories.Remove(BlogCategory);
            db.SaveChanges();
            return RedirectToAction("BlogCategory", "Dashboard");
        }
        #endregion
    }
}