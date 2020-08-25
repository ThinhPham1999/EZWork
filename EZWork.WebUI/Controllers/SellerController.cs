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
using System.Text;

namespace EZWork.WebUI.Controllers
{
    public class SellerController : Controller
    {
        private ISKillRepository skillRepository;
        private ISellerRepository sellerRepository;
        private ReviewRepository reviewRepository;
        public SellerController()
        {
            skillRepository = new SkillRepository();
            sellerRepository = new SellerRepository();
            reviewRepository = new ReviewRepository();
        }

        public ActionResult Index(string searchTerm, int? page, int? pageSize, int[] Searchskills, int? oneSkill)
        {
            page = page ?? 1;
            pageSize = pageSize ?? 3;
            ListSellerViewModel model = new ListSellerViewModel();
            if (oneSkill != null)
            {
                Searchskills = new int[] { oneSkill.Value };
                oneSkill = null;
            }
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
            model.SearchTerm = searchTerm ?? "";

            return View(model);
        }

        [HttpGet]
        //[ChildActionOnly]
        public ActionResult Detail(string id)
        {
            DetailSellerViewModel model = new DetailSellerViewModel();
            model.Seller = sellerRepository.GetSellerByID(id);
            model.Reviews = reviewRepository.GetReviewsByID(id);
            return View(model);
        }

        public ActionResult BecomeSeller(string id)
        {
            return View();
        }
    }
}