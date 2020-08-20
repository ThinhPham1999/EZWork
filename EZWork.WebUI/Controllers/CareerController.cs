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
    public class CareerController : Controller
    {
        private EZWorkDbContext db = new EZWorkDbContext();
        // GET: Career
        public ActionResult Index()
        {
            return View(db.Careers.ToList());
        }
        public ActionResult CreateCareer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCareer([Bind(Include = "CareerId,Name,Description,UrlSlug")] Career career)
        {
            if (ModelState.IsValid)
            {
                db.Careers.Add(career);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(career);
        }

        public ActionResult UpdateCareer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = db.Careers.Find(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            return View(career);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCareer([Bind(Include = "CareerId,Name,Description,UrlSlug")] Career career)
        {
            if (ModelState.IsValid)
            {
                db.Entry(career).State = EntityState.Modified;  
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(career);
        }

        public ActionResult DeleteCareer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = db.Careers.Find(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            return View(career);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("DeleteCareer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCareer(int id)
        {
            Career career = db.Careers.Find(id);
            db.Careers.Remove(career);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [ChildActionOnly]
        public ActionResult GetMenu()
        {
            return PartialView("_CareerPartial");
        }
    }
}