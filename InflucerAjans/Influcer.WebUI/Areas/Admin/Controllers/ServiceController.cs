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
    public class ServiceController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddService()
        {
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddService(tblService service, HttpPostedFileBase ImageVideoPath)
        {
            var AA = db.tblServices.Count();
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
                        db.tblServices.Add(service);
                        db.SaveChanges();
                        return RedirectToAction("Service", "Dashboard");
                    }
                
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

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
            tblService service = db.tblServices.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateService(int id, tblService service, HttpPostedFileBase ImageVideoPath)
        {
            var AU = db.tblServices.Find(id);
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
                    AU.LangID = service.LangID;
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
            return View(service);
        }
        #endregion
        #region Delete
        public ActionResult DeleteService(int ID)
        {
            tblService service = db.tblServices.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/Services/" + service.ImageVideoPath)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/Services/" + service.ImageVideoPath));
            }
            db.tblServices.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Service", "Dashboard");
        }
        #endregion

    }
}