using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfluencerWEBUI.Controllers
{
    public class HakkimizdaController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region TR
        // GET: Hakkimizda
        public ActionResult TR()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageName == "Hakkımızda").FirstOrDefault();
            return View(db.Abouts.Where(x => x.IsActive == true && x.LangTableID == 1).FirstOrDefault());
        }
        #endregion
        #region EN
        public ActionResult EN()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageName == "About").FirstOrDefault();
            return View(db.Abouts.Where(x => x.IsActive == true && x.LangTableID == 2).FirstOrDefault());
        }
        #endregion
    }
}