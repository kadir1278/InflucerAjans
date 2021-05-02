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
    public class ApplicationFormController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddApplicationForm()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddApplicationForm(tblApplicationForm API)
        {
            var x = db.tblApplicationForms.Count();
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
                    db.tblApplicationForms.Add(API);
                    db.SaveChanges();
                    return RedirectToAction("ApplicationForm", "Dashboard");

                }
            }
            return View(API);
        }
        #endregion
        #region Update
        public ActionResult UpdateApplicationForm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblApplicationForm API = db.tblApplicationForms.Find(id);
            if (API == null)
            {
                return HttpNotFound();
            }
            return View(API);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateApplicationForm(int id, tblApplicationForm API)
        {
            var x = db.tblApplicationForms.Find(id);
            if (ModelState.IsValid)
            {

                x.Name = API.Name;
                x.Surname = API.Surname;
                x.City = API.City;
                x.District = API.District;
                x.Address = API.Address;
                x.FilePath = API.FilePath;
                x.Subject = API.Subject;
                x.Message = API.Message;
                x.IsActive = API.IsActive;
                x.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("ApplicationForm", "Dashboard");

            }
            return View(API);
        }
        #endregion
        #region Delete
        public ActionResult DeleteApplicationForm(int ID)
        {
            tblApplicationForm API = db.tblApplicationForms.Where(x => x.ID == ID).SingleOrDefault();
            db.tblApplicationForms.Remove(API);
            db.SaveChanges();
            return RedirectToAction("ApplicationForm", "Dashboard");
        }
        #endregion
    }
}