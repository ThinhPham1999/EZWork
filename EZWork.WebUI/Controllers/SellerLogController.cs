using EZWork.Core.DBContext;
using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Controllers
{
    public class SellerLogController : Controller
    {
        private EZWorkDbContext db = new EZWorkDbContext();
        // GET: SellerLog
        public ActionResult Index()
        {
            return View(db.Sellers.ToList());
        }
        public ActionResult UpdateProfile(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
           // ViewBag.CareerId = new SelectList(db.Careers, "CareerId", "Name", skill.CareerId);
            return View(seller);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile([Bind(Include = "SellerId,ShortDescription")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Id = new SelectList(db.EZUsers, "FullName",seller.SellerId);
            return View(seller);
        }
    }
}