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
    public class SkillController : Controller
    {
        private EZWorkDbContext db = new EZWorkDbContext();
        // GET: Skill
        public ActionResult Index()
        {
            return View(db.Skills.ToList());
        }
        public ActionResult CreateSkill()
        {
            ViewBag.CareerId = new SelectList(db.Careers, "CareerId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSkill([Bind(Include = "Name,Description,UrlSlug,CareerId")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Skills.Add(skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CareerId = new SelectList(db.Careers, "CareerId", "Name", skill.CareerId);
            return View(skill);
        }
        public ActionResult UpdateSkill(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            ViewBag.CareerId = new SelectList(db.Careers, "CareerId", "Name", skill.CareerId);
            return View(skill);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSkill([Bind(Include = "Name,Description,UrlSlug,CareerId")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CareerId = new SelectList(db.Careers, "CareerId", "Name", skill.CareerId);
            return View(skill);
        }

       
        public ActionResult DeleteSkill(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skill skill = db.Skills.Find(id);
            db.Skills.Remove(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        [ChildActionOnly]
        public ActionResult GetSkill()
        {
            return PartialView("_SkillPartial");
        }
    }
}