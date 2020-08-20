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
            var viewsellers = db.EZUsers.Where(s=>s.Id==s.Seller.SellerId)
                .Include(p => p.Seller.Description)
                .Include(p=>p.Seller.Status);
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