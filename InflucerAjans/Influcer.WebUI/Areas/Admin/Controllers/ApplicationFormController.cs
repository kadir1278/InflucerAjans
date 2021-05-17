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
    public class ApplicationFormController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddApplicationForm()
        {
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddApplicationForm(tblApplicationForm API, HttpPostedFileBase FilePath)
        {
            if (ModelState.IsValid)
            {
                if (FilePath != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + FilePath.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/ApplicationForms/" + photoName));
                    FilePath.SaveAs(url);
                    API.FilePath = photoName;
                    API.IsActive = true;
                    API.LastDateTime = DateTime.Now;
                    db.tblApplicationForms.Add(API);
                    db.SaveChanges();
                    return RedirectToAction("ApplicationForm", "Dashboard");
                }
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

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
            tblApplicationForm about = db.tblApplicationForms.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateApplicationForm(int id, tblApplicationForm about, HttpPostedFileBase FilePath)
        {
            var AU = db.tblApplicationForms.Find(id);
            if (ModelState.IsValid)
            {
                if (FilePath != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/ApplicationForms/" + about.FilePath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/ApplicationForms/" + about.FilePath));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + FilePath.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/ApplicationForms/" + photoName));
                    FilePath.SaveAs(url);
                    AU.FilePath = photoName;
                    AU.Name = about.Name;
                    AU.Surname= about.Surname;
                    AU.City = about.City;
                    AU.District = about.District;
                    AU.Address = about.Address;
                    AU.Subject = about.Subject;
                    AU.Message = about.Message;
                    AU.IsActive = about.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("ApplicationForm", "Dashboard");
                }
            }
            return View(about);
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