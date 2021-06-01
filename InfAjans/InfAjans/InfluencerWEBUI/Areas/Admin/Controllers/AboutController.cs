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
    public class AboutController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddAbout()
        {
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAbout(About about, HttpPostedFileBase ImageVideoPath)
        {
            var AA = db.Abouts.Count();
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
                        about.Slug = StringHelper.StringReplacer(about.Title.ToLower());
                        about.LastDateTime = DateTime.Now;
                        db.Abouts.Add(about);
                        db.SaveChanges();
                        return RedirectToAction("About", "Dashboard");
                    }
                }
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName",about.LangTableID);

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
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName", about.LangTableID);
            return View(about);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateAbout(int id, About about, HttpPostedFileBase ImageVideoPath)
        {
            var AU = db.Abouts.Find(id);
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
                    AU.ImageVideoPath = photoName;
                }
                AU.Title = about.Title;
                AU.LangTableID = about.LangTableID;
                AU.Content = about.Content;
                AU.Slug = StringHelper.StringReplacer(about.Title.ToLower());
                AU.ShortContent = about.ShortContent;
                AU.IsActive = about.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("About", "Dashboard");
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName", about.LangTableID);
            return View(about);
        }
        #endregion
        #region Delete
        public ActionResult DeleteAbout(int ID)
        {
            About about = db.Abouts.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/Abouts/" + about.ImageVideoPath)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/Abouts/" + about.ImageVideoPath));
            }
            db.Abouts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("About", "Dashboard");
        }
        #endregion

    }
}