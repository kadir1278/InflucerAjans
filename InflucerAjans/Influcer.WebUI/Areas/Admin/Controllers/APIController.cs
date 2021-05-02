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
        public ActionResult AddAPI(tblAPI API)
        {
            var x = db.tblAPIs.Count();
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
                    db.tblAPIs.Add(API);
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
            tblAPI API = db.tblAPIs.Find(id);
            if (API == null)
            {
                return HttpNotFound();
            }
            return View(API);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateAPI(int id, tblAPI API)
        {
            var x = db.tblAPIs.Find(id);
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
            tblAPI API = db.tblAPIs.Where(x => x.ID == ID).SingleOrDefault();
            db.tblAPIs.Remove(API);
            db.SaveChanges();
            return RedirectToAction("API", "Dashboard");
        }
        #endregion
    }
}