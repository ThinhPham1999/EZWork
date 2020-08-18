using EZWork.Core.Entities;
using EZWork.Core.Repository;
using EZWork.WebUI.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Areas.Admin.Controllers
{
    public class SkillController : Controller
    {
        // GET: Admin/Skill
        private SkillRepository skillRepository;
        private CareerRepository careerRepository;
        public SkillController()
        {
            skillRepository = new SkillRepository();
            careerRepository = new CareerRepository();
        }
        public ActionResult Index(string searchTerm, int? categoryID, int? page, int? pageSize)
        {
            page = page ?? 1;
            pageSize = pageSize ?? 3;
            ListSkillViewModels model = new ListSkillViewModels();
            model.Careers = careerRepository.getAllCareers().ToList();
            model.SearchTerm = searchTerm;
            model.Skills = skillRepository.SearchSkill(searchTerm, categoryID, page.Value, pageSize.Value);
            var totalFilterSkill = skillRepository.SearchSkillCount(searchTerm, categoryID);
            model.Pager = new Pager(totalFilterSkill, page.Value, pageSize.Value);
            return View(model);
        }
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            ActionSkillViewModel model = new ActionSkillViewModel();
            if (ID.HasValue)
            {
                var skill = skillRepository.GetSkillByID(ID.Value);
                model.SkillId = ID.Value;
                model.SkillName = skill.Name;            
                model.SkillDescription = skill.Description;         
                model.CareerId = skill.CareerId;
            }
            model.Careers = careerRepository.getAllCareers().ToList();      
            return PartialView("Action", model);
        }
        public JsonResult Action(ActionSkillViewModel model)
        {
            JsonResult json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            bool result = false;      
            if (model.SkillId > 0)
            { //try to edit
                var skill = skillRepository.GetSkillByID(model.SkillId);
                skill.Name = model.SkillName;
                skill.CareerId = model.CareerId;
                skill.Description = model.SkillDescription;
                skill.UrlSlug = model.SkillUrlSlug;
                result = skillRepository.UpdateSkill(skill);
            }
            else
            {
                //try to create 
                Skill skill = new Skill();
                skill.Name = model.SkillName;
                skill.CareerId = model.CareerId;
                skill.Description = model.SkillDescription;
                skill.UrlSlug = model.SkillUrlSlug;
                result = skillRepository.SaveSkill(skill);
            }
            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Category" };
            }
            return json;
        }
        public JsonResult Delete(int ID)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var skill = skillRepository.GetSkillByID(ID);
            result = skillRepository.DeleteSkill(skill);
            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = true, Message = "Unable to perform action on Accomodation Package." };
            }
            return json;
        }

    }
}