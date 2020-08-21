using EZWork.Core.DBContext;
using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Controllers
{
    public class SellerController : Controller
    {
        private EZWorkDbContext db = new EZWorkDbContext();
        // GET: Seller
        public ActionResult ViewProfile()
        {
            var viewsellers = db.Sellers;
                //.Include(p => p.EZUser.FullName)
                //.Include(p=>p.EZUser.Gender)
                //.Include(p=>p.EZUser.BirthDay)
                //.Include(p=>p.EZUser.ImageProfile)
                //.Include(p=>p.EZUser.CreateAt)
                //.Include(p=>p.EZUser.ModifierAt)
                //.Include(p=>p.EZUser.Status);
             return View(viewsellers.ToList());
        }
        public ActionResult CreateProfile()
        {
            return View();
        }
        public ActionResult UpdateProfile()
        {
            return View();
        }
    }
}