using CNR.WEBUI.Content.Helper;
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
    public class BrandController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddBrand()
        {
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBrand(Brand brand, HttpPostedFileBase LogoPath)
        {
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
                    brand.Slug = StringHelper.StringReplacer(brand.Name.ToLower());

                    db.Brands.Add(brand);
                    db.SaveChanges();
                    return RedirectToAction("Brand", "Dashboard");
                }
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName",brand.LangTableID);

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
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName", brand.LangTableID);

            return View(brand);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateBrand(int id, Brand brand, HttpPostedFileBase LogoPath)
        {
            var AU = db.Brands.Find(id);
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
                }
                AU.Name = brand.Name;
                AU.LangTableID = brand.LangTableID;
                AU.Slug = StringHelper.StringReplacer(brand.Name.ToLower());
                AU.IsActive = brand.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Brand", "Dashboard");
            }
            ViewBag.LangTableID = new SelectList(db.Langs.Where(x => x.IsActive == true), "ID", "LangName", brand.LangTableID);

            return View(brand);
        }
        #endregion
        #region Delete
        public ActionResult DeleteBrand(int ID)
        {
            Brand brand = db.Brands.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/Brands/" + brand.LogoPath)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/Brands/" + brand.LogoPath));
            }
            db.Brands.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Brand", "Dashboard");
        }
        #endregion

    }
}