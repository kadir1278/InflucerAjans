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
        public ActionResult AddInfluencer(tblInfluencer brand)
        {
            var MCB = db.tblInfluencers.Where(x => x.ID == brand.LangID).FirstOrDefault();
            if (ModelState.IsValid)
            {
                    brand.IsActive = true;
                    brand.LastDateTime = DateTime.Now;
                    db.tblInfluencers.Add(brand);
                    db.SaveChanges();
                    return RedirectToAction("Influencer", "Dashboard");
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang", brand.LangID);
            return View(brand);
        }
        #endregion
        #region Update
        public ActionResult UpdateInfluencer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInfluencer brand = db.tblInfluencers.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View(brand);
        }
        [HttpPost, ValidateInput(false)]

        public ActionResult UpdateInfluencer(int id, tblInfluencer brand)
        {
            var AU = db.tblInfluencers.Find(id);
            if (ModelState.IsValid)
            {

                AU.Name = brand.Name;
                AU.Surname = brand.Surname;
                AU.InstagramAddress = brand.InstagramAddress;
                AU.TwitterAddress = brand.TwitterAddress;
                AU.FacebookAddress = brand.FacebookAddress;
                AU.InstagramFollower = brand.InstagramFollower;
                AU.TwitterFollower = brand.TwitterFollower;
                AU.FacebookFollower = brand.FacebookFollower;
                AU.LangID = brand.LangID;
                #region seo
                AU.seoTitle = brand.seoTitle;
                AU.seoKeywords = brand.seoKeywords;
                AU.seoDescription = brand.seoDescription;
                AU.seoAuthor = brand.seoAuthor;
                AU.seoCopyright = brand.seoCopyright;
                AU.seoDesign = brand.seoDesign;
                AU.seoReply = brand.seoReply;
                AU.seoSubject = brand.seoSubject;
                AU.seoTwitterDescription = brand.seoTwitterDescription;
                AU.seoTwitterKeywords = brand.seoTwitterKeywords;
                AU.seoTwitterTitle = brand.seoTwitterTitle;
                AU.seoTwitterUrl = brand.seoTwitterUrl;
                AU.seoFacebookDescription = brand.seoFacebookDescription;
                AU.seoFacebookKeywrods = brand.seoFacebookKeywrods;
                AU.seoFacebookTitle = brand.seoFacebookTitle;
                AU.seoFacebookUrl = brand.seoFacebookUrl;
                #endregion
                AU.IsActive = brand.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Influencer", "Dashboard");
            }

            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View(brand);
        }
        #endregion
        #region Delete
        public ActionResult DeleteInfluencer(int ID)
        {
            tblInfluencer brand = db.tblInfluencers.Where(x => x.ID == ID).SingleOrDefault();
            db.tblInfluencers.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Influencer", "Dashboard");
        }
        #endregion
    }
}