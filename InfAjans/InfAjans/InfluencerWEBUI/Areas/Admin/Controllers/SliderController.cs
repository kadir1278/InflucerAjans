using CNR.WEBUI.Content.Helper;
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
    public class SliderController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddSlider()
        {
            ViewBag.MainSliderID = new SelectList(db.MainSliders.Where(x => x.IsActive == true), "ID", "Title");


            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddSlider(Slider slider, HttpPostedFileBase ImageVideoPath)
        {
            if (ModelState.IsValid)
            {
                if (ImageVideoPath != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageVideoPath.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/Sliders/" + photoName));
                    ImageVideoPath.SaveAs(url);
                    slider.ImageVideoPath = photoName;
                    slider.IsActive = true;
                    slider.Slug = StringHelper.StringReplacer(slider.Title.ToLower());

                    slider.LastDateTime = DateTime.Now;
                    db.Sliders.Add(slider);
                    db.SaveChanges();
                    return RedirectToAction("Slider", "Dashboard");

                }
            }
            ViewBag.MainSliderID = new SelectList(db.MainSliders.Where(x => x.IsActive == true), "ID", "Title");


            return View(slider);
        }
        #endregion
        #region Update
        public ActionResult UpdateSlider(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainSliderID = new SelectList(db.MainSliders.Where(x => x.IsActive == true), "ID", "Title");


            return View(slider);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateSlider(int id, Slider slider, HttpPostedFileBase ImageVideoPath)
        {
            var AU = db.Sliders.Find(id);
            if (ModelState.IsValid)
            {
                if (ImageVideoPath != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Image/Sliders/" + slider.ImageVideoPath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Image/Sliders/" + slider.ImageVideoPath));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageVideoPath.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/Sliders/" + photoName));
                    ImageVideoPath.SaveAs(url);
                    AU.Title = slider.Title;
                    AU.ImageVideoPath = photoName;
                    AU.Content = slider.Content;
                    AU.IsActive = slider.IsActive;
                    AU.Rank = slider.Rank;
                    AU.Slug = StringHelper.StringReplacer(slider.Title.ToLower());

                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Slider", "Dashboard");
                }
            }
            ViewBag.MainSliderID = new SelectList(db.MainSliders.Where(x => x.IsActive == true), "ID", "Title");


            return View(slider);
        }
        #endregion
        #region Delete
        public ActionResult DeleteSlider(int ID)
        {
            Slider slider = db.Sliders.Where(x => x.ID == ID).SingleOrDefault();
            db.Sliders.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Slider", "Dashboard");
        }
        #endregion
    }
}