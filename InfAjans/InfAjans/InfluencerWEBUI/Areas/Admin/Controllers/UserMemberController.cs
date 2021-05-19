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
    public class UserMemberController : Controller
    {
        InfluencerContext db = new InfluencerContext();

        #region Create
        public ActionResult AddUserMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUserMember(UserMember user)
        {
            if (ModelState.IsValid)
            {
                user.IsActive = true;
                user.LastDateTime = DateTime.Now;
                db.UserMembers.Add(user);
                db.SaveChanges();
                return RedirectToAction("UserMember", "Dashboard");
            }
            return View(user);
        }
        #endregion
        #region Update
        public ActionResult UpdateUserMember(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMember user = db.UserMembers.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateUserMember(int id, UserMember user)
        {
            var AU = db.UserMembers.Find(id);
            if (ModelState.IsValid)
            {
                AU.Name = user.Name;
                AU.Surname = user.Surname;
                AU.Username = user.Username;
                AU.Password = user.Password;
                AU.Email = user.Email;
                AU.IsActive = user.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("UserMember", "Dashboard");
            }
            return View(user);
        }
        #endregion
        #region Delete
        [HttpGet]
        public ActionResult DeleteUserMember(int ID)
        {
            UserMember user = db.UserMembers.Where(x => x.ID == ID).SingleOrDefault();
            db.UserMembers.Remove(user);
            db.SaveChanges();
            return RedirectToAction("UserMember", "Dashboard");
        }
        #endregion
    }
}