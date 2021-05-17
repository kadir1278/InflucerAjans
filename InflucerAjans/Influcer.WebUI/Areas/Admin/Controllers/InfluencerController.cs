using InflucerEntity.Entity;
using InflucerEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Influcer.WebUI.Areas.Admin.Controllers
{
    public class InfluencerController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddInfluencer()
        {
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddInfluencer(tblInfluencer Influencer)
        {

            var MCB = db.tblInfluencers.Where(x => x.ID == Influencer.LangID).FirstOrDefault();
            if (ModelState.IsValid)
            {

                Influencer.InfluencerCode = "INF-00" + db.tblInfluencers.Max(x=>x.ID+1);
                Influencer.IsActive = true;
                Influencer.LastDateTime = DateTime.Now;
                db.tblInfluencers.Add(Influencer);
                db.SaveChanges();
                return RedirectToAction("Influencer", "Dashboard");
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang", Influencer.LangID);
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
            tblInfluencer Influencer = db.tblInfluencers.Find(id);
            if (Influencer == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View(Influencer);
        }
        [HttpPost, ValidateInput(false)]

        public ActionResult UpdateInfluencer(int id, tblInfluencer Influencer)
        {
            var AU = db.tblInfluencers.Find(id);
            if (ModelState.IsValid)
            {

                AU.Name = Influencer.Name;
                AU.Surname = Influencer.Surname;
                AU.InstagramAddress = Influencer.InstagramAddress;
                AU.TwitterAddress = Influencer.TwitterAddress;
                AU.FacebookAddress = Influencer.FacebookAddress;
                AU.InstagramFollower = Influencer.InstagramFollower;
                AU.TwitterFollower = Influencer.TwitterFollower;
                AU.FacebookFollower = Influencer.FacebookFollower;
                AU.LangID = Influencer.LangID;
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

            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View(Influencer);
        }
        #endregion
        #region Delete
        public ActionResult DeleteInfluencer(int ID)
        {
            tblInfluencer Influencer = db.tblInfluencers.Where(x => x.ID == ID).SingleOrDefault();
            db.tblInfluencers.Remove(Influencer);
            db.SaveChanges();
            return RedirectToAction("Influencer", "Dashboard");
        }
        #endregion
    }
}