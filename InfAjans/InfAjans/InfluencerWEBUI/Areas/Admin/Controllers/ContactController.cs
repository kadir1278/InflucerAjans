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
    public class ContactController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddContact(Contact Contact)
        {
            if (ModelState.IsValid)
            {
                Contact.IsActive = true;
                Contact.LastDateTime = DateTime.Now;
                db.Contacts.Add(Contact);
                db.SaveChanges();
                return RedirectToAction("Contact", "Dashboard");
            }
            return View(Contact);
        }
        #endregion
        #region Update
        public ActionResult UpdateContact(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact Contact = db.Contacts.Find(id);
            if (Contact == null)
            {
                return HttpNotFound();
            }
            return View(Contact);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateContact(int id, Contact Contact)
        {
            var AU = db.Contacts.Find(id);
            if (ModelState.IsValid)
            {
                AU.Address = Contact.Address;
                AU.Phone = Contact.Phone;
                AU.EMail = Contact.EMail;
                AU.IsActive = Contact.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Contact", "Dashboard");
            }
            return View(Contact);
        }
        #endregion
        #region Delete
        public ActionResult DeleteContact(int ID)
        {
            Contact Contact = db.Contacts.Where(x => x.ID == ID).SingleOrDefault();
            db.Contacts.Remove(Contact);
            db.SaveChanges();
            return RedirectToAction("Contact", "Dashboard");
        }
        #endregion
    }
}