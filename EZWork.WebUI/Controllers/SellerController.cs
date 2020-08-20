using EZWork.Core.Abstract;
using EZWork.Core.Entities;
using EZWork.Core.Repository;
using EZWork.WebUI.Models;
using EZWork.Extensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Controllers
{
    public class SellerController : Controller
    {
        private ISKillRepository skillRepository;
        private ISellerRepository sellerRepository;
        
        public SellerController()
        {
            skillRepository = new SkillRepository();
            sellerRepository = new SellerRepository();
        }

        public ActionResult Index(string searchTerm, string skillID, int? page, int? pageSize)
        {
            page = page ?? 1;
            pageSize = pageSize ?? 3;
            ListSellerViewModel model = new ListSellerViewModel();
            //model.Careers = careerRepository.getAllCareers().ToList();
            model.SearchTerm = searchTerm;
            model.Sellers = sellerRepository.SearchSeller(searchTerm, skillID, page.Value, pageSize.Value);
            var totalFilterSkill = sellerRepository.SearchSellerCount(searchTerm, skillID);
            model.Pager = new Pager(totalFilterSkill, page.Value, pageSize.Value);
            return View(model);
        }

        //[HttpGet]
        //public ActionResult Action(int? ID)
        //{
        //    ActionSkillViewModel model = new ActionSkillViewModel();
        //    if (ID.HasValue)
        //    {
        //        var skill = skillRepository.GetSkillByID(ID.Value);
        //        model.SkillId = ID.Value;
        //        model.SkillName = skill.Name;
        //        model.SkillDescription = skill.Description;
        //        model.CareerId = skill.CareerId;
        //    }
        //    model.Careers = careerRepository.getAllCareers().ToList();
        //    return PartialView("Action", model);
        //}

        //public JsonResult Action(ActionSkillViewModel model)
        //{
        //    JsonResult json = new JsonResult();
        //    json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    bool result = false;
        //    if (model.SkillId > 0)
        //    { //try to edit
        //        var skill = skillRepository.GetSkillByID(model.SkillId);
        //        skill.Name = model.SkillName;
        //        skill.CareerId = model.CareerId;
        //        skill.Description = model.SkillDescription;
        //        skill.UrlSlug = model.SkillUrlSlug;
        //        result = skillRepository.UpdateSkill(skill);
        //    }
        //    else
        //    {
        //        //try to create 
        //        Skill skill = new Skill();
        //        skill.Name = model.SkillName;
        //        skill.CareerId = model.CareerId;
        //        skill.Description = model.SkillDescription;
        //        skill.UrlSlug = model.SkillUrlSlug;
        //        result = skillRepository.SaveSkill(skill);
        //    }
        //    if (result)
        //    {
        //        json.Data = new { Success = true };
        //    }
        //    else
        //    {
        //        json.Data = new { Success = false, Message = "Unable to add Category" };
        //    }
        //    return json;
        //}

    }
}