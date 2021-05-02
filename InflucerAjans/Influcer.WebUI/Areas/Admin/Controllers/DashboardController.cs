using InflucerEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Influcer.WebUI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        // GET: Admin/Dashboard
        #region Anasayfa
        public ActionResult Index()
        {
            return View();
        }
        #endregion
        #region Hakkında
        public ActionResult About()
        {
            var x = db.tblAbouts.ToList();
            return View(x);
        }
        #endregion
        #region API
        public ActionResult API()
        {
            var x = db.tblAPIs.ToList();
            return View(x);
        }
        #endregion
        #region Başvuru Formu
        public ActionResult ApplicationForm()
        {
            var x = db.tblApplicationForms.ToList();
            return View(x);
        }
        #endregion
        #region Marka
        public ActionResult Brand()
        {
            var x = db.tblBrands.ToList();
            return View(x);
        }
        public ActionResult BrandImage()
        {
            var x = db.tblBrandImages.ToList();
            return View(x);
        }
        #endregion
        #region Influencer
        public ActionResult Influencer()
        {
            var x = db.tblInfluencers.ToList();
            return View(x);
        }
        public ActionResult InfluencerVideo()
        {
            var x = db.tblInfluencerVideos.ToList();
            return View(x);
        }
        #endregion
        #region Dil
        public ActionResult Languages()
        {
            var x = db.tblLangs.ToList();
            return View(x);
        }
        #endregion
        #region Servis
        public ActionResult Service()
        {
            var x = db.tblServices.ToList();
            return View(x);
        }
        #endregion
        #region Slider
        public ActionResult Slider()
        {
            var x = db.tblSliders.ToList();
            return View(x);
        }
        #endregion
    }
}