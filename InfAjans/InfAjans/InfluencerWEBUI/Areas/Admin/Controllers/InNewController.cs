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
    public class InNewController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddInNew()
        {
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddInNew(InNew InNew, HttpPostedFileBase Image)
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
                    InNew.Slug = StringHelper.StringReplacer(InNew.Title.ToLower());

                    db.InNews.Add(InNew);
                    db.SaveChanges();
                    return RedirectToAction("InNew", "Dashboard");
                }
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

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
            InNew InNew = db.InNews.Find(id);
            if (InNew == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(InNew);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateInNew(int id, InNew InNew, HttpPostedFileBase Image)
        {
            var AU = db.InNews.Find(id);
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
                AU.Slug = StringHelper.StringReplacer(InNew.Title.ToLower());

                AU.Title = InNew.Title;
                AU.Content = InNew.Content;
                AU.LangTableID = InNew.LangTableID;
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
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(InNew);
        }
        #endregion
        #region Delete
        public ActionResult DeleteInNew(int ID)
        {
            InNew InNew = db.InNews.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/InNews/" + InNew.Image)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/InNews/" + InNew.Image));
            }
            db.InNews.Remove(InNew);
            db.SaveChanges();
            return RedirectToAction("InNew", "Dashboard");
        }
        #endregion
    }
}