using CNR.WEBUI.Content.Helper;
using Influencer.Entities.Entity;
using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InfluencerWEBUI.Areas.Admin.Controllers
{
    public class SocialMediaController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia social)
        {
            if (ModelState.IsValid)
            {
                social.Slug = StringHelper.StringReplacer(social.Title.ToLower());

                social.IsActive = true;
                social.LastDateTime = DateTime.Now;
                db.SocialMedias.Add(social);
                db.SaveChanges();
                return RedirectToAction("SocialMedia", "Dashboard");
            }
            return View(social);
        }
        #endregion
        #region Update
        public ActionResult UpdateSocialMedia(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia social = db.SocialMedias.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateSocialMedia(int id, SocialMedia social)
        {
            var AU = db.SocialMedias.Find(id);
            if (ModelState.IsValid)
            {
                AU.Title = social.Title;
                AU.Icon = social.Icon;
                AU.URL = social.URL;
                AU.Slug = StringHelper.StringReplacer(social.Title.ToLower());

                AU.IsActive = social.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("SocialMedia", "Dashboard");
            }
            return View(social);
        }
        #endregion
        #region Delete
        [HttpGet]
        public ActionResult DeleteSocialMedia(int ID)
        {
            SocialMedia socialMedia = db.SocialMedias.Where(x => x.ID == ID).SingleOrDefault();
            db.SocialMedias.Remove(socialMedia);
            db.SaveChanges();
            return RedirectToAction("SocialMedia", "Dashboard");
        }
        #endregion
    }
}