using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace InfluencerWEBUI.Controllers
{
    public class AnasayfaController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region TR
        // GET: Anasayfa
        public ActionResult TR()
        {
            return View();
        }
        public ActionResult TRPartialSliderList()
        {
            return PartialView(db.Sliders.Include(x => x.MainSlider).Where(x => x.IsActive == true && x.MainSlider.LangTableID == 1).ToList());
        }
        public ActionResult TRPartialAbout()
        {
            return PartialView(db.Abouts.Where(x => x.IsActive == true && x.LangTableID == 1).FirstOrDefault());
        }
        #endregion
        #region EN
        public ActionResult EN()
        {
            return View();
        }
        public ActionResult ENPartialSliderList()
        {
            return PartialView(db.Sliders.Include(x => x.MainSlider).Where(x => x.IsActive == true && x.MainSlider.LangTableID == 2).ToList());
        }
        public ActionResult ENPartialAbout()
        {
            return PartialView(db.Abouts.Where(x => x.IsActive == true && x.LangTableID == 2).FirstOrDefault());
        }
        #endregion
    }
}