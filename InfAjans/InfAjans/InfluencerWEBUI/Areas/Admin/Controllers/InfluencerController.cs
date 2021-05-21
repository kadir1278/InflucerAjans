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
    public class InfluencerController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddInfluencer()
        {
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddInfluencer(Inflencer Influencer, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/Influencers/" + photoName));
                    File.SaveAs(url);
                    Influencer.File = photoName;
                    try
                    {
                        Influencer.InfluencerCode = "INF-00" + db.Inflencers.Max(x => x.ID + 1);
                    }
                    catch (Exception)
                    {
                        Influencer.InfluencerCode = "INF-00" + 1;
                    }
                    Influencer.IsActive = true;
                    Influencer.LastDateTime = DateTime.Now;
                    db.Inflencers.Add(Influencer);
                    db.SaveChanges();
                    return RedirectToAction("Influencer", "Dashboard");
                }
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(Influencer);
        }
        #endregion
        #region Update
        public ActionResult UpdateInfluencer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inflencer Influencer = db.Inflencers.Find(id);
            if (Influencer == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(Influencer);
        }
        [HttpPost, ValidateInput(false)]

        public ActionResult UpdateInfluencer(int id, Inflencer Influencer, HttpPostedFileBase File)
        {
            var AU = db.Inflencers.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Image/Influencers/" + Influencer.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Image/Influencers/" + Influencer.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/Influencers/" + photoName));
                    AU.Name = Influencer.Name;
                    AU.Surname = Influencer.Surname;
                    AU.InstagramAddress = Influencer.InstagramAddress;
                    AU.TwitterAddress = Influencer.TwitterAddress;
                    AU.FacebookAddress = Influencer.FacebookAddress;
                    AU.InstagramFollower = Influencer.InstagramFollower;
                    AU.TwitterFollower = Influencer.TwitterFollower;
                    AU.FacebookFollower = Influencer.FacebookFollower;
                    AU.LangTableID = Influencer.LangTableID;
                    AU.Content = Influencer.Content;
                    AU.File = photoName;
                    #region seo
                    AU.seoTitle = Influencer.seoTitle;
                    AU.seoKeywords = Influencer.seoKeywords;
                    AU.seoDescription = Influencer.seoDescription;
                    AU.seoAuthor = Influencer.seoAuthor;
                    AU.seoCopyright = Influencer.seoCopyright;
                    AU.seoDesign = Influencer.seoDesign;
                    AU.seoReply = Influencer.seoReply;
                    AU.seoSubject = Influencer.seoSubject;
                    AU.seoTwitterDescription = Influencer.seoTwitterDescription;
                    AU.seoTwitterKeywords = Influencer.seoTwitterKeywords;
                    AU.seoTwitterTitle = Influencer.seoTwitterTitle;
                    AU.seoTwitterUrl = Influencer.seoTwitterUrl;
                    AU.seoFacebookDescription = Influencer.seoFacebookDescription;
                    AU.seoFacebookKeywrods = Influencer.seoFacebookKeywrods;
                    AU.seoFacebookTitle = Influencer.seoFacebookTitle;
                    AU.seoFacebookUrl = Influencer.seoFacebookUrl;
                    #endregion
                    AU.IsActive = Influencer.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Influencer", "Dashboard");
                }

            }

            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(Influencer);
        }
        #endregion
        #region Delete
        public ActionResult DeleteInfluencer(int ID)
        {
            Inflencer Influencer = db.Inflencers.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/Influencers/" + Influencer.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/Influencers/" + Influencer.File));
            }
            db.Inflencers.Remove(Influencer);
            db.SaveChanges();
            return RedirectToAction("Influencer", "Dashboard");
        }
        #endregion
    }
}