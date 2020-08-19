using EZWork.Core.DBContext;
using System;
using System.Collections.Generic;
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
            return View(db.EZUsers);
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