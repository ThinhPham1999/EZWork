using EZWork.Core.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Controllers
{
    public class UserLogController : Controller
    {
        private EZWorkDbContext db = new EZWorkDbContext();
        // GET: UserLog
        public ActionResult Index()
        {
            return View();
        }
    }
}