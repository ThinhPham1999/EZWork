using EZWork.Core.Abstract;
using EZWork.Core.Entities;
using EZWork.Core.Repository;
using EZWork.WebUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Areas.Admin.Controllers
{
    public class SkillAdminController : Controller
    {
        // GET: Admin/Skill
        private ISKillRepository skillRepository;

        public SkillAdminController()
        {
            skillRepository = new SkillRepository();
        }

        // GET: Admin/Career
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List()
        {
            var list = skillRepository.GetAll();
            IList<SkillViewModel> listView = new List<SkillViewModel>();
            foreach (var item in list)
            {
                listView.Add(new SkillViewModel()
                {
                    CareerId = item.Career.CareerId,
                    CareerName = item.Career.Name,
                    SkillName = item.Name,
                    SkillDescription = item.Description,
                    SkillId = item.SkillId,
                    SkillUrlSlug = item.UrlSlug
                });
            }
            return Json(listView, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(Skill skill)
        {
            return Json(skillRepository.Create(skill), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetbyID(int id)
        {
            var career = skillRepository.Find(id);
            return Json(career, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Skill skill)
        {
            return Json(skillRepository.Update(skill), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            return Json(skillRepository.Delete(id), JsonRequestBehavior.AllowGet);
        }
    }
}