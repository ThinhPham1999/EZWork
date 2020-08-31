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
  [Authorize(Roles = "Admin")]
    public class SkillAdminController : Controller
    {
        // GET: Admin/Skill
        private ISKillRepository skillRepository;
        private ICareerRepository careerRepository;

        public SkillAdminController()
        {
            skillRepository = new SkillRepository();
            careerRepository = new CareerRepository();
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
        public JsonResult Add(SkillViewModel skill)
        {
            Career career = careerRepository.Find(skill.CareerId);
            Skill newSkill = new Skill()
            {
                SkillId = skill.SkillId,
                Name = skill.SkillName,
                Description = skill.SkillDescription,
                UrlSlug = skill.SkillUrlSlug,
                CareerId = skill.CareerId
            };
            skillRepository.Create(newSkill);
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetbyID(int id)
        {
            var item = skillRepository.Find(id);
            SkillViewModel skillView =  new SkillViewModel()
            {
                CareerId = item.Career.CareerId,
                CareerName = item.Career.Name,
                SkillName = item.Name,
                SkillDescription = item.Description,
                SkillId = item.SkillId,
                SkillUrlSlug = item.UrlSlug
            };
            return Json(skillView, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(SkillViewModel skillView)
        {
            Skill updateSkill = new Skill()
            {
                SkillId = skillView.SkillId,
                Name = skillView.SkillName,
                Description = skillView.SkillDescription,
                UrlSlug = skillView.SkillUrlSlug,
                CareerId = skillView.CareerId
            };
            skillRepository.Update(updateSkill);
            return Json(0 , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            return Json(skillRepository.Delete(id), JsonRequestBehavior.AllowGet);
        }
    }
}