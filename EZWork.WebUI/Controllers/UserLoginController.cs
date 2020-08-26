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
    public class UserLoginController : Controller
    {
        private EZWorkDbContext db = new EZWorkDbContext();
        // GET: UserLog
        public ActionResult Index()
        {
            return View(db.EZUsers.ToList());
        }
        public ActionResult Index1()
        {
            return View(db.EZUsers.ToList());
        }
        public ActionResult UpdateProfileUser(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EZUser eZUser = db.EZUsers.Find(id);
            if (eZUser == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Id = new SelectList(db.EZUsers);
            return View(eZUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfileUser([Bind(Include = "Id,FullName,Gender,Birthday,ImageProfile,CreateAt,ModifierAt,Status,UserName")] EZUser eZUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eZUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // ViewBag.Id = new SelectList(db.EZUsers, "Id", "FullName", "Gender", "Birthday", "ImageProfile", seller.SellerId);
            //ViewBag.Id = new SelectList(db.EZAccounts, "Id", eZUser.Id);
            return View(eZUser);
        }
    }
}