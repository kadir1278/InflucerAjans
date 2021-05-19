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
    public class MainSliderController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddMainSlider()
        {
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddMainSlider(MainSlider MainSlider)
        {
            if (ModelState.IsValid)
            {
                MainSlider.IsActive = true;
                MainSlider.LastDateTime = DateTime.Now;
                db.MainSliders.Add(MainSlider);
                db.SaveChanges();
                return RedirectToAction("MainSlider", "Dashboard");
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(MainSlider);
        }
        #endregion
        #region Update
        public ActionResult UpdateMainSlider(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainSlider MainSlider = db.MainSliders.Find(id);
            if (MainSlider == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(MainSlider);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateMainSlider(int id, MainSlider MainSlider)
        {
            var AU = db.MainSliders.Find(id);
            if (ModelState.IsValid)
            {

                AU.Title = MainSlider.Title;
                AU.Description = MainSlider.Description;
                AU.IsActive = MainSlider.IsActive;
                AU.LangTableID = MainSlider.LangTableID;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("MainSlider", "Dashboard");

            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(MainSlider);
        }
        #endregion
        #region Delete
        public ActionResult DeleteMainSlider(int ID)
        {
            MainSlider MainSlider = db.MainSliders.Where(x => x.ID == ID).SingleOrDefault();
            db.MainSliders.Remove(MainSlider);
            db.SaveChanges();
            return RedirectToAction("MainSlider", "Dashboard");
        }
        #endregion
    }
}