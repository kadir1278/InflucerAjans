using CNR.WEBUI.Content.Helper;
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
    public class BlogDetailsController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddBlogDetails()
        {
            ViewBag.BlogID = new SelectList(db.Blogs.Where(x => x.IsActive == true), "ID", "Title");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlogDetails(BlogDetail BlogDetail, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {

                if (File != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/BlogDetails/" + photoName));
                    File.SaveAs(url);
                    BlogDetail.File = photoName;
                    BlogDetail.IsActive = true;
                    BlogDetail.LastDateTime = DateTime.Now;
                    BlogDetail.Slug = StringHelper.StringReplacer(BlogDetail.Title.ToLower());

                    db.BlogDetails.Add(BlogDetail);
                    db.SaveChanges();
                    return RedirectToAction("BlogDetails", "Dashboard");
                }
            }
            ViewBag.BlogID = new SelectList(db.Blogs.Where(x => x.IsActive == true), "ID", "Title",BlogDetail.BlogID);
            return View(BlogDetail);
        }
        #endregion
        #region Update
        public ActionResult UpdateBlogDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogDetail BlogDetail = db.BlogDetails.Find(id);
            if (BlogDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogID = new SelectList(db.Blogs.Where(x => x.IsActive == true), "ID", "Title", BlogDetail.BlogID);
            return View(BlogDetail);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateBlogDetails(int id, BlogDetail BlogDetail, HttpPostedFileBase File)
        {
            var AU = db.BlogDetails.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Image/BlogDetails/" + BlogDetail.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Image/BlogDetails/" + BlogDetail.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/BlogDetails/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.Title = BlogDetail.Title;
                AU.Content = BlogDetail.Content;
                AU.IsActive = BlogDetail.IsActive;
                AU.Slug = StringHelper.StringReplacer(BlogDetail.Title.ToLower());
                AU.BlogID = BlogDetail.BlogID;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("BlogDetails", "Dashboard");
            }
            ViewBag.BlogID = new SelectList(db.Blogs.Where(x => x.IsActive == true), "ID", "Title", BlogDetail.BlogID);
            return View(BlogDetail);
        }
        #endregion
        #region Delete
        public ActionResult DeleteBlogDetails(int ID)
        {
            BlogDetail BlogDetail = db.BlogDetails.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/BlogDetails/" + BlogDetail.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/BlogDetails/" + BlogDetail.File));
            }
            db.BlogDetails.Remove(BlogDetail);
            db.SaveChanges();
            return RedirectToAction("BlogDetails", "Dashboard");
        }
        #endregion
    }
}