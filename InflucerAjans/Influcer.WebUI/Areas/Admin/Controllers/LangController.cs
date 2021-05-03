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
        public ActionResult AddLang(tblLang API)
        {
            var x = db.tblLangs.Count();
            if (ModelState.IsValid)
            {
                API.IsActive = true;
                API.LastDateTime = DateTime.Now;
                db.tblLangs.Add(API);
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
            tblLang API = db.tblLangs.Find(id);
            if (API == null)
            {
                return HttpNotFound();
            }
            return View(API);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateLang(int id, tblLang API)
        {
            var x = db.tblLangs.Find(id);
            if (ModelState.IsValid)
            {

                x.Lang = API.Lang;
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
            tblLang API = db.tblLangs.Where(x => x.ID == ID).SingleOrDefault();
            db.tblLangs.Remove(API);
            db.SaveChanges();
            return RedirectToAction("Lang", "Dashboard");
        }
        #endregion
    }
}