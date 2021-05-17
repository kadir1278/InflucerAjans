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
    public class BlogDetailsController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddBlogDetails()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlogDetails(tblBlogDetail BlogDetail, HttpPostedFileBase File)
        {
            var AA = db.tblBlogDetails.Count();
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
                    db.tblBlogDetails.Add(BlogDetail);
                    db.SaveChanges();
                    return RedirectToAction("BlogDetails", "Dashboard");
                }
            }
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
            tblBlogDetail BlogDetail = db.tblBlogDetails.Find(id);
            if (BlogDetail == null)
            {
                return HttpNotFound();
            }
            return View(BlogDetail);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateBlogDetails(int id, tblBlogDetail BlogDetail, HttpPostedFileBase File)
        {
            var AU = db.tblBlogDetails.Find(id);
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
                    AU.Title = BlogDetail.Title;
                    AU.File = photoName;
                    AU.Content = BlogDetail.Content;
                    AU.ShortContent = BlogDetail.ShortContent;
                    AU.IsActive = BlogDetail.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("BlogDetails", "Dashboard");
                }
            }
            return View(BlogDetail);
        }
        #endregion
        #region Delete
        public ActionResult DeleteBlogDetails(int ID)
        {
            tblBlogDetail BlogDetail = db.tblBlogDetails.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/BlogDetails/" + BlogDetail.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/BlogDetails/" + BlogDetail.File));
            }
            db.tblBlogDetails.Remove(BlogDetail);
            db.SaveChanges();
            return RedirectToAction("BlogDetail", "Dashboard");
        }
        #endregion
    }
}