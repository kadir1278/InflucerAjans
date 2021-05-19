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
    public class LangController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddLang()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddLang(LangTable API)
        {
            var x = db.Langs.Count();
            if (ModelState.IsValid)
            {
                API.IsActive = true;
                API.LastDateTime = DateTime.Now;
                db.Langs.Add(API);
                db.SaveChanges();
                return RedirectToAction("Languages", "Dashboard");
            }
            return View(API);
        }
        #endregion
        #region Update
        public ActionResult UpdateLang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LangTable API = db.Langs.Find(id);
            if (API == null)
            {
                return HttpNotFound();
            }
            return View(API);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateLang(int id, LangTable API)
        {
            var x = db.Langs.Find(id);
            if (ModelState.IsValid)
            {

                x.LangName = API.LangName;
                x.LangCode = API.LangCode;
                x.IsActive = API.IsActive;
                x.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Languages", "Dashboard");

            }
            return View(API);
        }
        #endregion
        #region Delete
        public ActionResult DeleteLang(int ID)
        {
            LangTable API = db.Langs.Where(x => x.ID == ID).SingleOrDefault();
            db.Langs.Remove(API);
            db.SaveChanges();
            return RedirectToAction("Lang", "Dashboard");
        }
        #endregion
    }
}