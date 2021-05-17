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
    public class MainGoogleSeoController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddGoogleSeo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddGoogleSeo(tblMainGoogleSeo googleSeo)
        {
            var GS = db.tblMainGoogleSeos.Where(x => x.PageName.ToLower().ToUpper() == googleSeo.PageName.ToLower().ToUpper() || x.PageUrl == googleSeo.PageUrl).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (GS != null)
                {
                    ViewBag.Mesaj = "Girdiğiniz değerler ile sistemde eşleşen kayıt olduğu için yeni kayıt oluşturulamadı.";
                    return View(googleSeo);
                }
                else
                {
                    googleSeo.IsActive = true;
                    googleSeo.LastDateTime = DateTime.Now;
                    db.tblMainGoogleSeos.Add(googleSeo);
                    db.SaveChanges();
                    return RedirectToAction("MainGoogleSeo", "Dashboard");
                }

            }
            return View(googleSeo);
        }
        #endregion
        #region Update
        public ActionResult UpdateGoogleSeo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMainGoogleSeo googleSeo = db.tblMainGoogleSeos.Find(id);
            if (googleSeo == null)
            {
                return HttpNotFound();
            }
            return View(googleSeo);
        }
        [HttpPost]
        public ActionResult UpdateGoogleSeo(int id, tblMainGoogleSeo googleSeo)
        {
            var GS = db.tblMainGoogleSeos.Where(x => x.PageName.ToLower().ToUpper() == googleSeo.PageName.ToLower().ToUpper() || x.PageUrl == googleSeo.PageUrl && x.ID != id).FirstOrDefault();
            var AU = db.tblMainGoogleSeos.Find(id);
            if (ModelState.IsValid)
            {
                if (GS != null)
                {
                    ViewBag.Mesaj = "Girdiğiniz değerler ile sistemde eşleşen kayıt olduğu için güncelleme işlemi oluşturulamadı.";
                    return View(googleSeo);
                }
                else
                {
                    AU.PageName = googleSeo.PageName;
                    AU.PageUrl = googleSeo.PageUrl;
                    AU.seoTitle = googleSeo.seoTitle;
                    AU.seoKeywords = googleSeo.seoKeywords;
                    AU.seoDescription = googleSeo.seoDescription;
                    AU.seoAuthor = googleSeo.seoAuthor;
                    AU.seoCopyright = googleSeo.seoCopyright;
                    AU.seoDesign = googleSeo.seoDesign;
                    AU.seoReply = googleSeo.seoReply;
                    AU.seoSubject = googleSeo.seoSubject;
                    AU.seoTwitterTitle = googleSeo.seoTwitterTitle;
                    AU.seoTwitterKeywords = googleSeo.seoTwitterKeywords;
                    AU.seoTwitterDescription = googleSeo.seoTwitterDescription;
                    AU.seoTwitterUrl = googleSeo.seoTwitterUrl;
                    AU.seoFacebookTitle = googleSeo.seoFacebookTitle;
                    AU.seoFacebookKeywrods = googleSeo.seoFacebookKeywrods;
                    AU.seoFacebookDescription = googleSeo.seoFacebookDescription;
                    AU.seoFacebookUrl = googleSeo.seoFacebookUrl;
                    AU.IsActive = googleSeo.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("MainGoogleSeo", "Dashboard");
                }
            }
            return View(googleSeo);
        }
        #endregion
        #region Delete
        public ActionResult DeleteGoogleSeo(int ID)
        {

            tblMainGoogleSeo googleSeo = db.tblMainGoogleSeos.Where(x => x.ID == ID).SingleOrDefault();
            db.tblMainGoogleSeos.Remove(googleSeo);
            db.SaveChanges();
            return RedirectToAction("MainGoogleSeo", "Dashboard");
        }
        #endregion
    }
}