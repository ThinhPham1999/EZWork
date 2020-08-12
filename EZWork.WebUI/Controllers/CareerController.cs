using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Controllers
{
    public class CareerController : Controller
    {
        // GET: Career
        public ActionResult Index()
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