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