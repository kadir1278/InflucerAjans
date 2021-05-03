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
    public class BrandImageController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        #region Create
        public ActionResult AddBrandImage()
        {
            ViewBag.BrandID = new SelectList(db.tblBrands.Where(x => x.IsActive == true), "ID", "Name");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBrandImage(tblBrandImage brand, HttpPostedFileBase BrandImagePath
)
        {
            var MCB = db.tblBrandImages.Where(x => x.ID == brand.BrandID).FirstOrDefault();
            if (ModelState.IsValid)
            {

                if (BrandImagePath != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + BrandImagePath.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/brands/" + photoName));
                    BrandImagePath.SaveAs(url);
                    brand.BrandImagePath = photoName;
                    brand.IsActive = true;
                    brand.LastDateTime = DateTime.Now;
                    db.tblBrandImages.Add(brand);
                    db.SaveChanges();
                    return RedirectToAction("BrandImage", "Dashboard");
                }
            }
            ViewBag.BrandID = new SelectList(db.tblBrands.Where(x => x.IsActive == true), "ID", "Name");
            return View(brand);
        }
        #endregion
        #region Update
        public ActionResult UpdateBrandImage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBrandImage brand = db.tblBrandImages.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.tblBrands.Where(x => x.IsActive == true), "ID", "Name");

            return View(brand);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateBrandImage(int id, tblBrandImage brand, HttpPostedFileBase BrandImagePath)
        {
            var AU = db.tblBrandImages.Find(id);
            if (ModelState.IsValid)
            {
                if (BrandImagePath != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Image/Brands/" + brand.BrandImagePath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Image/Brands/" + brand.BrandImagePath));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + BrandImagePath.FileName);
                    var url = Path.Combine(Server.MapPath("~/Image/Brands/" + photoName));
                    BrandImagePath.SaveAs(url);
                    AU.BrandImagePath = photoName;
                    AU.BrandID = brand.BrandID;
                    AU.IsActive = brand.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("BrandImage", "Dashboard");
                }
            }
            ViewBag.BrandID = new SelectList(db.tblBrands.Where(x => x.IsActive == true), "ID", "Name");

            return View(brand);
        }
        #endregion
        #region Delete
        public ActionResult DeleteBrandImage(int ID)
        {
            tblBrandImage brand = db.tblBrandImages.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Image/Brands/" + brand.BrandImagePath)))
            {
                System.IO.File.Delete(Server.MapPath("~/Image/Brands/" + brand.BrandImagePath));
            }
            db.tblBrandImages.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("BrandImage", "Dashboard");
        }
        #endregion
    }
}