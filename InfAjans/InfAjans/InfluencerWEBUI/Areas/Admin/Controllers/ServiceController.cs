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
    public class ServiceController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddService()
        {
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddService(Service service, HttpPostedFileBase ImageVideoPath)
        {
            var AA = db.Services.Count();
            if (ModelState.IsValid)
            {
                
                    if (ImageVideoPath != null)
                    {
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageVideoPath.FileName);
                        var url = Path.Combine(Server.MapPath("~/Image/Services/" + photoName));
                        ImageVideoPath.SaveAs(url);
                        service.ImageVideoPath = photoName;
                        service.IsActive = true;
                        service.LastDateTime = DateTime.Now;
                        db.Services.Add(service);
                        db.SaveChanges();
                        return RedirectToAction("Service", "Dashboard");
                    }
                
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(service);
        }
        #endregion
        #region Update
        public ActionResult UpdateService(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(service);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateService(int id, Service service, HttpPostedFileBase ImageVideoPath)
        {
            var AU = db.Services.Find(id);
            if (ModelState.IsValid)
            {
                if (ImageVideoPath != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Image/Services/" + service.ImageVideoPath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Image/Services/" + service.ImageVideoPath));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageVideoPath.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/Services/" + photoName));
                    ImageVideoPath.SaveAs(url);
                    AU.Title = service.Title;
                    AU.ImageVideoPath = photoName;
                    AU.Content = service.Content;
                    AU.ShortContent = service.ShortContent;
                    AU.LangTableID = service.LangTableID;
                    #region seo
                    AU.seoTitle = service.seoTitle;
                    AU.seoKeywords = service.seoKeywords;
                    AU.seoDescription = service.seoDescription;
                    AU.seoAuthor = service.seoAuthor;
                    AU.seoCopyright = service.seoCopyright;
                    AU.seoDesign = service.seoDesign;
                    AU.seoReply = service.seoReply;
                    AU.seoSubject = service.seoSubject;
                    AU.seoTwitterDescription = service.seoTwitterDescription;
                    AU.seoTwitterKeywords = service.seoTwitterKeywords;
                    AU.seoTwitterTitle = service.seoTwitterTitle;
                    AU.seoTwitterUrl = service.seoTwitterUrl;
                    AU.seoFacebookDescription = service.seoFacebookDescription;
                    AU.seoFacebookKeywrods = service.seoFacebookKeywrods;
                    AU.seoFacebookTitle = service.seoFacebookTitle;
                    AU.seoFacebookUrl = service.seoFacebookUrl;
                    #endregion

                    AU.IsActive = service.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Service", "Dashboard");
                }
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(service);
        }
        #endregion
        #region Delete
        public ActionResult DeleteService(int ID)
        {
            Service service = db.Services.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/Services/" + service.ImageVideoPath)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/Services/" + service.ImageVideoPath));
            }
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Service", "Dashboard");
        }
        #endregion

    }
}