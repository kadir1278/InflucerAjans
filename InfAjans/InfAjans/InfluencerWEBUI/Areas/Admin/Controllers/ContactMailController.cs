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
    public class ContactMailController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddContactMail()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddContactMail(ContactMail ContactMail)
        {
            if (ModelState.IsValid)
            {
                ContactMail.IsActive = true;
                ContactMail.LastDateTime = DateTime.Now;
                db.ContactMails.Add(ContactMail);
                db.SaveChanges();
                return RedirectToAction("ContactMail", "Dashboard");
            }
            return View(ContactMail);
        }
        #endregion
        #region Update
        public ActionResult UpdateContactMail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMail ContactMail = db.ContactMails.Find(id);
            if (ContactMail == null)
            {
                return HttpNotFound();
            }
            return View(ContactMail);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateContactMail(int id, ContactMail ContactMail)
        {
            var AU = db.ContactMails.Find(id);
            if (ModelState.IsValid)
            {
                AU.NameSurname = ContactMail.NameSurname;
                AU.Phone = ContactMail.Phone;
                AU.Email = ContactMail.Email;
                AU.Subject = ContactMail.Subject;
                AU.Content = ContactMail.Content;
                AU.IsActive = ContactMail.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("ContactMail", "Dashboard");
            }
            return View(ContactMail);
        }
        #endregion
        #region Delete
        public ActionResult DeleteContactMail(int ID)
        {
            ContactMail ContactMail = db.ContactMails.Where(x => x.ID == ID).SingleOrDefault();
            db.ContactMails.Remove(ContactMail);
            db.SaveChanges();
            return RedirectToAction("ContactMail", "Dashboard");
        }
        #endregion

    }
}