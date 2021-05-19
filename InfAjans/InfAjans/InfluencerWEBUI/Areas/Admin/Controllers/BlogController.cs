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
    public class BlogController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddBlog()
        {
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlog(Blog Blog, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/Blogs/" + photoName));
                    File.SaveAs(url);
                    Blog.File = photoName;
                    Blog.IsActive = true;
                    Blog.LastDateTime = DateTime.Now;
                    db.Blogs.Add(Blog);
                    db.SaveChanges();
                    return RedirectToAction("Blog", "Dashboard");
                }
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(Blog);
        }
        #endregion
        #region Update
        public ActionResult UpdateBlog(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog Blog = db.Blogs.Find(id);
            if (Blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(Blog);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateBlog(int id, Blog Blog, HttpPostedFileBase File)
        {
            var AU = db.Blogs.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Image/Blogs/" + Blog.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Image/Blogs/" + Blog.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/Blogs/" + photoName));
                    File.SaveAs(url);
                    AU.Title = Blog.Title;
                    AU.File = photoName;
                    AU.Content = Blog.Content;
                    AU.ShortContent = Blog.ShortContent;
                    AU.IsActive = Blog.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Blog", "Dashboard");
                }
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(Blog);
        }
        #endregion
        #region Delete
        public ActionResult DeleteBlog(int ID)
        {
            Blog Blog = db.Blogs.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/Blogs/" + Blog.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/Blogs/" + Blog.File));
            }
            db.Blogs.Remove(Blog);
            db.SaveChanges();
            return RedirectToAction("Blog", "Dashboard");
        }
        #endregion
    }
}