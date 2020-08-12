using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetSkill()
        {
            return PartialView("_SkillPartial");
        }
    }
}