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

        public ActionResult TRPartialServiceList()
        {
            return PartialView(db.Services.Where(x => x.IsActive == true && x.LangTableID == 1).ToList().Take(6));
        }

        public ActionResult TRPartialAbout()
        {
            return PartialView(db.Abouts.Where(x => x.IsActive == true && x.LangTableID == 1).FirstOrDefault());
        }

        public ActionResult TRPartialOurSolitionPartnerList()
        {
            return PartialView(db.Brands.Where(x => x.IsActive == true && x.LangTableID == 1).ToList().OrderByDescending(x=>x.ID).Take(4)) ;
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

        public ActionResult ENPartialServiceList()
        {
            return PartialView(db.Services.Where(x => x.IsActive == true && x.LangTableID == 2).ToList().Take(6));
        }

        public ActionResult ENPartialAbout()
        {
            return PartialView(db.Abouts.Where(x => x.IsActive == true && x.LangTableID == 2).FirstOrDefault());
        }

        public ActionResult ENPartialOurSolitionPartnerList()
        {
            return PartialView(db.Brands.Where(x => x.IsActive == true && x.LangTableID == 2).ToList().OrderByDescending(x => x.ID).Take(4));
        }
        #endregion
    }
}