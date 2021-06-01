using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfluencerWEBUI.Controllers
{
    public class ServislerController : Controller
    {
        private InfluencerContext db = new InfluencerContext();
        // GET: Servisler
        #region TR
        public ActionResult TR()
        {
            return View(db.Services.Where(x => x.IsActive == true && x.LangTableID == 1).ToList().OrderByDescending(x => x.ID));
        }
        #endregion
        #region EN
        public ActionResult EN()
        {
            return View(db.Services.Where(x => x.IsActive == true && x.LangTableID == 2).ToList().OrderByDescending(x => x.ID));
        }
        #endregion
    }
}