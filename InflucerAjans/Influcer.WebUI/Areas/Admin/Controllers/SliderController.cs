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
    public class SliderController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddSlider()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddSlider(tblSlider slider, HttpPostedFileBase ImageVideoPath)
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
                    slider.LastDateTime = DateTime.Now;
                    db.tblSliders.Add(slider);
                    db.SaveChanges();
                    return RedirectToAction("Slider", "Dashboard");

                }
            }
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
            tblSlider slider = db.tblSliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateSlider(int id, tblSlider slider, HttpPostedFileBase ImageVideoPath)
        {
            var AU = db.tblSliders.Find(id);
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
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Slider", "Dashboard");
                }
            }
            return View(slider);
        }
        #endregion
        #region Delete
        public ActionResult DeleteSlider(int ID)
        {
            tblSlider slider = db.tblSliders.Where(x => x.ID == ID).SingleOrDefault();
            db.tblSliders.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Slider", "Dashboard");
        }
        #endregion
    }
}