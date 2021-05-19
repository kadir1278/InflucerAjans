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
    public class ApplicationFormController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddApplicationForm()
        {
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddApplicationForm(ApplicationForm API, HttpPostedFileBase FilePath)
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
                    db.ApplicationForms.Add(API);
                    db.SaveChanges();
                    return RedirectToAction("ApplicationForm", "Dashboard");
                }
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

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
            ApplicationForm about = db.ApplicationForms.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(about);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateApplicationForm(int id, ApplicationForm about, HttpPostedFileBase FilePath)
        {
            var AU = db.ApplicationForms.Find(id);
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
                    AU.LangTableID = about.LangTableID;
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
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View(about);
        }
        #endregion
        #region Delete
        public ActionResult DeleteApplicationForm(int ID)
        {
            ApplicationForm API = db.ApplicationForms.Where(x => x.ID == ID).SingleOrDefault();
            db.ApplicationForms.Remove(API);
            db.SaveChanges();
            return RedirectToAction("ApplicationForm", "Dashboard");
        }
        #endregion
    }
}