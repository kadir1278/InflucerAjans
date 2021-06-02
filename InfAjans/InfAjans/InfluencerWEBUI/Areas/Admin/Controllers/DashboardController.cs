using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace InfluencerWEBUI.Areas.Admin.Controllers
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
            var x = db.Abouts.ToList();
            return View(x);
        }
        #endregion
        #region API
        public ActionResult API()
        {
            var x = db.APIs.ToList();
            return View(x);
        }
        #endregion
        #region Başvuru Formu
        public ActionResult ApplicationForm()
        {
            var x = db.ApplicationForms.ToList();
            return View(x);
        }
        #endregion
        #region Marka
        public ActionResult Brand()
        {
            var x = db.Brands.ToList();
            return View(x);
        }
        #endregion
        #region Influencer
        public ActionResult Influencer()
        {
            var x = db.Inflencers.ToList();
            return View(x);
        }
        public ActionResult InfluencerVideo()
        {
            var x = db.InfluencerVideos.ToList();
            return View(x);
        }
        #endregion
        #region Dil
        public ActionResult Languages()
        {
            var x = db.Langs.ToList();
            return View(x);
        }
        #endregion
        #region Servis
        public ActionResult Service()
        {
            var x = db.Services.ToList();
            return View(x);
        }
        #endregion
        #region Slider
        public ActionResult Slider()
        {
            var a = db.Sliders.Include(x=>x.MainSlider).ToList();
            return View(a);
        }
        public ActionResult MainSlider()
        {
            var x = db.MainSliders.ToList();
            return View(x);
        }
        #endregion
        #region KullanıcıBilgileri
        public ActionResult UserMember()
        {
            var umL = db.UserMembers.ToList();
            return View(umL);
        }
        #endregion
        #region MainGoogleSeo
        public ActionResult MainGoogleSeo()
        {
            var x = db.MainGoogleSeos.ToList();
            return View(x);
        }
        #endregion
        #region Blog
        public ActionResult BlogCategory()
        {
            var x = db.BlogCategories.ToList();
            return View(x);
        }
        public ActionResult Blog()
        {
            var x = db.Blogs.ToList();
            return View(x);
        }
        public ActionResult BlogDetails()
        {
            var x = db.BlogDetails.Include(y=>y.Blog).ToList();
            return View(x);
        }
        #endregion
        #region Basında Biz
        public ActionResult InNew()
        {
            var x = db.InNews.ToList();
            return View(x);
        }
        #endregion
        #region Sosyal Medya
        public ActionResult SocialMedia()
        {
            var x = db.SocialMedias.ToList();
            return View(x);
        }
        #endregion
        #region İletişim
        public ActionResult Contact()
        {
            var x = db.Contacts.ToList();
            return View(x);
        }
        public ActionResult ContactMail()
        {
            var x = db.ContactMails.ToList();
            return View(x);
        }
        #endregion

    }
}