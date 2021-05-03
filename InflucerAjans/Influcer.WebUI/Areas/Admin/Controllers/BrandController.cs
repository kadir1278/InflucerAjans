using InflucerEntity.Entity;
using InflucerEntity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Influcer.WebUI.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddBrand()
        {
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBrand(tblBrand brand, HttpPostedFileBase LogoPath)
        {
            var MCB = db.tblBrands.Where(x => x.ID == brand.LangID).FirstOrDefault();
            if (ModelState.IsValid)
            {

                if (LogoPath != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + LogoPath.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/brands/" + photoName));
                    LogoPath.SaveAs(url);
                    brand.LogoPath = photoName;
                    brand.IsActive = true;
                    brand.LastDateTime = DateTime.Now;
                    db.tblBrands.Add(brand);
                    db.SaveChanges();
                    return RedirectToAction("Brand", "Dashboard");
                }
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang", brand.LangID);
            return View(brand);
        }
        #endregion
        #region Update
        public ActionResult UpdateBrand(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBrand brand = db.tblBrands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View(brand);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateBrand(int id, tblBrand brand, HttpPostedFileBase LogoPath)
        {
            var AU = db.tblBrands.Find(id);
            if (ModelState.IsValid)
            {
                if (LogoPath != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Image/Brands/" + brand.LogoPath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Image/Brands/" + brand.LogoPath));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + LogoPath.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/Brands/" + photoName));
                    LogoPath.SaveAs(url);
                    AU.LogoPath = photoName;
                    AU.Name = brand.Name;
                    AU.Content = brand.Content;
                    AU.LangID = brand.LangID;
                    #region seo
                    AU.seoTitle = brand.seoTitle;
                    AU.seoKeywords = brand.seoKeywords;
                    AU.seoDescription = brand.seoDescription;
                    AU.seoAuthor = brand.seoAuthor;
                    AU.seoCopyright = brand.seoCopyright;
                    AU.seoDesign = brand.seoDesign;
                    AU.seoReply = brand.seoReply;
                    AU.seoSubject = brand.seoSubject;
                    AU.seoTwitterDescription = brand.seoTwitterDescription;
                    AU.seoTwitterKeywords = brand.seoTwitterKeywords;
                    AU.seoTwitterTitle = brand.seoTwitterTitle;
                    AU.seoTwitterUrl = brand.seoTwitterUrl;
                    AU.seoFacebookDescription = brand.seoFacebookDescription;
                    AU.seoFacebookKeywrods = brand.seoFacebookKeywrods;
                    AU.seoFacebookTitle = brand.seoFacebookTitle;
                    AU.seoFacebookUrl = brand.seoFacebookUrl;
                    #endregion

                    AU.ShortContent = brand.ShortContent;
                    AU.IsActive = brand.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Brand", "Dashboard");
                }
            }
            ViewBag.LangID = new SelectList(db.tblLangs.Where(x => x.IsActive == true), "ID", "Lang");

            return View(brand);
        }
        #endregion
        #region Delete
        public ActionResult DeleteBrand(int ID)
        {
            tblBrand brand = db.tblBrands.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/Brands/" + brand.LogoPath)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/Brands/" + brand.LogoPath));
            }
            db.tblBrands.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Brand", "Dashboard");
        }
        #endregion

    }
}