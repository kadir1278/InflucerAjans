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
    public class AboutController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddAbout()
        {
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAbout(tblAbout about, HttpPostedFileBase ImageVideoPath)
        {
            var AA = db.tblAbouts.Count();
            if (ModelState.IsValid)
            {
                if (AA > 1)
                {
                    ViewBag.Mesaj = "Sistemde En fazla 1 Adet Hakkımızda Bulunur";
                    return View(about);
                }
                else
                {
                    if (ImageVideoPath != null)
                    {
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageVideoPath.FileName);
                        var url = Path.Combine(Server.MapPath("~/Image/Abouts/" + photoName));
                        ImageVideoPath.SaveAs(url);
                        about.ImageVideoPath = photoName;
                        about.IsActive = true;
                        about.LastDateTime = DateTime.Now;
                        db.tblAbouts.Add(about);
                        db.SaveChanges();
                        return RedirectToAction("About", "Dashboard");
                    }
                }
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View(about);
        }
        #endregion
        #region Update
        public ActionResult UpdateAbout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAbout about = db.tblAbouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateAbout(int id, tblAbout about, HttpPostedFileBase ImageVideoPath)
        {
            var AU = db.tblAbouts.Find(id);
            if (ModelState.IsValid)
            {
                if (ImageVideoPath != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Image/Abouts/" + about.ImageVideoPath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Image/Abouts/" + about.ImageVideoPath));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageVideoPath.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/Abouts/" + photoName));
                    ImageVideoPath.SaveAs(url);
                    AU.Title = about.Title;
                    AU.ImageVideoPath = photoName;
                    AU.Content = about.Content;
                    AU.ShortContent = about.ShortContent;
                    AU.IsActive = about.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("About", "Dashboard");
                }
            }
            return View(about);
        }
        #endregion
        #region Delete
        public ActionResult DeleteAbout(int ID)
        {
            tblAbout about = db.tblAbouts.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/Abouts/" + about.ImageVideoPath)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/Abouts/" + about.ImageVideoPath));
            }
            db.tblAbouts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("About", "Dashboard");
        }
        #endregion

    }
}