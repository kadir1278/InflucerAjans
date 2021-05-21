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
    public class InfluencerVideoController : Controller
    {
        InfluencerContext db = new InfluencerContext();

        #region Create
        public ActionResult AddInfluencerVideo()
        {
            ViewBag.InfluencerID = new SelectList(db.Inflencers.Where(x => x.IsActive == true), "ID", "InfluencerCode");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddInfluencerVideo(InfluencerVideo brand, HttpPostedFileBase InfluencerVideoPath)
        {
            var MCB = db.InfluencerVideos.Where(x => x.ID == brand.InfluencerID).FirstOrDefault();
            if (ModelState.IsValid)
            {

                if (InfluencerVideoPath != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + InfluencerVideoPath.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/InfluencerVideos/" + photoName));
                    InfluencerVideoPath.SaveAs(url);
                    brand.InfluencerVideoPath = photoName;
                    brand.IsActive = true;
                    brand.LastDateTime = DateTime.Now;
                    brand.Slug = StringHelper.StringReplacer(brand.Title.ToLower());

                    db.InfluencerVideos.Add(brand);
                    db.SaveChanges();
                    return RedirectToAction("InfluencerVideo", "Dashboard");
                }
            }
            ViewBag.InfluencerID = new SelectList(db.Inflencers.Where(x => x.IsActive == true), "ID", "InfluencerCode");
            return View(brand);
        }
        #endregion
        #region Update
        public ActionResult UpdateInfluencerVideo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfluencerVideo brand = db.InfluencerVideos.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.InfluencerID = new SelectList(db.Inflencers.Where(x => x.IsActive == true), "ID", "Name");

            return View(brand);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateInfluencerVideo(int id, InfluencerVideo brand, HttpPostedFileBase InfluencerVideoPath)
        {
            var AU = db.InfluencerVideos.Find(id);
            if (ModelState.IsValid)
            {
                if (InfluencerVideoPath != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Image/InfluencerVideos/" + brand.InfluencerVideoPath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Image/InfluencerVideos/" + brand.InfluencerVideoPath));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + InfluencerVideoPath.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/InfluencerVideos/" + photoName));
                    InfluencerVideoPath.SaveAs(url);
                    AU.InfluencerVideoPath = photoName;
                    AU.Content = brand.Content;
                    AU.Title = brand.Title;
                    AU.InfluencerID = brand.InfluencerID;
                    AU.IsActive = brand.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    AU.Slug = StringHelper.StringReplacer(brand.Title.ToLower());

                    db.SaveChanges();
                    return RedirectToAction("InfluencerVideo", "Dashboard");
                }
            }
            ViewBag.InfluencerID = new SelectList(db.Inflencers.Where(x => x.IsActive == true), "ID", "Name");

            return View(brand);
        }
        #endregion
        #region Delete
        public ActionResult DeleteInfluencerVideo(int ID)
        {
            InfluencerVideo brand = db.InfluencerVideos.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/InfluencerVideos/" + brand.InfluencerVideoPath)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/InfluencerVideos/" + brand.InfluencerVideoPath));
            }
            db.InfluencerVideos.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("InfluencerVideo", "Dashboard");
        }
        #endregion

    }
}