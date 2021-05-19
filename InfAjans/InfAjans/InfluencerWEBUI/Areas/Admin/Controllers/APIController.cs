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
    public class APIController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddAPI()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAPI(API API)
        {
            var x = db.APIs.Count();
            if (ModelState.IsValid)
            {
                if (x > 1)
                {
                    ViewBag.Mesaj = "Sistemde En fazla 1 Adet Hakkımızda Bulunur";
                    return View(API);
                }
                else
                {
                    API.IsActive = true;
                    API.LastDateTime = DateTime.Now;
                    db.APIs.Add(API);
                    db.SaveChanges();
                    return RedirectToAction("API", "Dashboard");

                }
            }
            return View(API);
        }
        #endregion
        #region Update
        public ActionResult UpdateAPI(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            API API = db.APIs.Find(id);
            if (API == null)
            {
                return HttpNotFound();
            }
            return View(API);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateAPI(int id, API API)
        {
            var x = db.APIs.Find(id);
            if (ModelState.IsValid)
            {

                x.Key = API.Key;
                x.SecretKey = API.SecretKey;
                x.Title = API.Title;
                x.IsActive = API.IsActive;
                x.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("API", "Dashboard");

            }
            return View(API);
        }
        #endregion
        #region Delete
        public ActionResult DeleteAPI(int ID)
        {
            API API = db.APIs.Where(x => x.ID == ID).SingleOrDefault();
            db.APIs.Remove(API);
            db.SaveChanges();
            return RedirectToAction("API", "Dashboard");
        }
        #endregion
    }
}