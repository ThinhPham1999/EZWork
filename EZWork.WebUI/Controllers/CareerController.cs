using EZWork.Core.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [ChildActionOnly]
        public ActionResult GetMenu()
        {
            return PartialView("_CareerPartial");
        }
    }
}