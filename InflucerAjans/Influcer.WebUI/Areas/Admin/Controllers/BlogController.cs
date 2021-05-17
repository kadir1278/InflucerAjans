using InflucerEntity.Entity;
using InflucerEntity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Influcer.WebUI.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddBlog()
        {
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlog(tblBlog Blog, HttpPostedFileBase File)
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
                    db.tblBlogs.Add(Blog);
                    db.SaveChanges();
                    return RedirectToAction("Blog", "Dashboard");
                }
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

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
            tblBlog Blog = db.tblBlogs.Find(id);
            if (Blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View(Blog);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateBlog(int id, tblBlog Blog, HttpPostedFileBase File)
        {
            var AU = db.tblBlogs.Find(id);
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
                    AU.LangID = Blog.LangID;
                    AU.File = photoName;
                    AU.Content = Blog.Content;
                    AU.ShortContent = Blog.ShortContent;
                    AU.IsActive = Blog.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Blog", "Dashboard");
                }
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View(Blog);
        }
        #endregion
        #region Delete
        public ActionResult DeleteBlog(int ID)
        {
            tblBlog Blog = db.tblBlogs.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/Blogs/" + Blog.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/Blogs/" + Blog.File));
            }
            db.tblBlogs.Remove(Blog);
            db.SaveChanges();
            return RedirectToAction("Blog", "Dashboard");
        }
        #endregion
    }
}