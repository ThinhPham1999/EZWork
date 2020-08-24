﻿using EZWork.Core.Abstract;
using EZWork.Core.Entities;
using EZWork.Core.Repository;
using EZWork.WebUI.Models;
using EZWork.Extensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

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

        public ActionResult Index(string searchTerm, int? page, int? pageSize, int[] Searchskills)
        {
            page = page ?? 1;
            pageSize = pageSize ?? 3;
            ListSellerViewModel model = new ListSellerViewModel();
            
            model.SearchTerm = searchTerm;
            model.ViewSellers = sellerRepository.SearchSeller(searchTerm, page.Value, pageSize.Value, Searchskills);
            model.ViewSkills = new List<SkillViewModel>();
            List<Skill> skills = skillRepository.GetAll().ToList();
            foreach (var item in skills)
            {
                SkillViewModel skillViewModel = new SkillViewModel();
                skillViewModel.Skill = item;
                skillViewModel.IsChecked = false;
                if (Searchskills != null)
                {
                    if (Searchskills.ToList().Contains(item.SkillId))
                    {
                        skillViewModel.IsChecked = true;
                    }
                }
                model.ViewSkills.Add(skillViewModel);
            }
            var totalFilterSeller = sellerRepository.SearchSellerCount(searchTerm, Searchskills);
            model.Pager = new Pager(totalFilterSeller, page.Value, pageSize.Value);
            model.SearchTerm = searchTerm?? "";
            return View(model);
        }

        
        public ActionResult SearchOneSkill(int id)
        {
            int[] search = new int[] { id };
            return RedirectToAction("Index", new { searchTerm = "", page = 1, pageSize = 3, Searchskills = search });
        }

        [HttpGet]
        public ActionResult Detail() 
        {
            return View();
        }
    }
}