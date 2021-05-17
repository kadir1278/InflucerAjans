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
    public class InNewController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddInNew()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddInNew(tblInNew InNew, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + Image.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/InNews/" + photoName));
                    Image.SaveAs(url);
                    InNew.Image = photoName;
                    InNew.IsActive = true;
                    InNew.LastDateTime = DateTime.Now;
                    db.tblInNews.Add(InNew);
                    db.SaveChanges();
                    return RedirectToAction("InNew", "Dashboard");
                }
            }
            return View(InNew);
        }
        #endregion
        #region Update
        public ActionResult UpdateInNew(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInNew InNew = db.tblInNews.Find(id);
            if (InNew == null)
            {
                return HttpNotFound();
            }
            return View(InNew);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateInNew(int id, tblInNew InNew, HttpPostedFileBase Image)
        {
            var AU = db.tblInNews.Find(id);
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Image/InNews/" + InNew.Image)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Image/InNews/" + InNew.Image));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + Image.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/InNews/" + photoName));
                    Image.SaveAs(url);
                    AU.Image = photoName;

                }

                AU.Title = InNew.Title;
                AU.Content = InNew.Content;
                #region seo
                AU.seoTitle = InNew.seoTitle;
                AU.seoKeywords = InNew.seoKeywords;
                AU.seoDescription = InNew.seoDescription;
                AU.seoAuthor = InNew.seoAuthor;
                AU.seoCopyright = InNew.seoCopyright;
                AU.seoDesign = InNew.seoDesign;
                AU.seoReply = InNew.seoReply;
                AU.seoSubject = InNew.seoSubject;
                AU.seoTwitterTitle = InNew.seoTwitterTitle;
                AU.seoTwitterKeywords = InNew.seoTwitterKeywords;
                AU.seoTwitterDescription = InNew.seoTwitterDescription;
                AU.seoTwitterUrl = InNew.seoTwitterUrl;
                AU.seoFacebookTitle = InNew.seoFacebookTitle;
                AU.seoFacebookKeywrods = InNew.seoFacebookKeywrods;
                AU.seoFacebookDescription = InNew.seoFacebookDescription;
                AU.seoFacebookUrl = InNew.seoFacebookUrl;
                AU.IsActive = InNew.IsActive;
                #endregion
                AU.IsActive = InNew.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("InNew", "Dashboard");
            }
            return View(InNew);
        }
        #endregion
        #region Delete
        public ActionResult DeleteInNew(int ID)
        {
            tblInNew InNew = db.tblInNews.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/InNews/" + InNew.Image)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/InNews/" + InNew.Image));
            }
            db.tblInNews.Remove(InNew);
            db.SaveChanges();
            return RedirectToAction("InNew", "Dashboard");
        }
        #endregion
    }
}