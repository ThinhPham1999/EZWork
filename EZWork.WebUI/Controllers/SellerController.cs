using EZWork.Core.Abstract;
using EZWork.Core.Entities;
using EZWork.Core.Repository;
using EZWork.WebUI.Models;
using EZWork.Extensions.Extensions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Microsoft.AspNet.Identity.Owin;

namespace EZWork.WebUI.Controllers
{
    public class SellerController : Controller
    {
        private ISKillRepository skillRepository;
        private ISellerRepository sellerRepository;
        private ReviewRepository reviewRepository;
        private ILevelRepository levelRepository;


        private AccountRepository _userManager;
        public AccountRepository UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AccountRepository>();
            }
            set
            {
                _userManager = value;
            }
        }
        private RoleRepository _roleManager;
        public RoleRepository RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<RoleRepository>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public SellerController()
        {
            skillRepository = new SkillRepository();
            sellerRepository = new SellerRepository();
            reviewRepository = new ReviewRepository();
            levelRepository = new LevelRepository();
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
            ViewBag.ViewSkill = Searchskills;
            return View(model);
        }

        [HttpGet]
        //[ChildActionOnly]
        public ActionResult Detail(string id)
        {
            DetailSellerViewModel model = new DetailSellerViewModel();
            model.Seller = sellerRepository.GetSellerByID(id);
            model.Reviews = reviewRepository.GetReviewsByID(id);
         //   model.AverageStars = reviewRepository.GetAverageRate(id);
          //  model.FeedbackCounts = reviewRepository.GetFeedbackCount(id);
            return View(model);
        }

        [Authorize(Roles = "User,Seller")]
        [HttpGet]
        public ActionResult BecomeSeller()
        {
            string id = User.Identity.GetUserId();  
            var seller = sellerRepository.GetSellerByID(id);
            var skills = skillRepository.GetAll();
            BecomeSellerViewModel becomeSellerViewModel = new BecomeSellerViewModel();
            becomeSellerViewModel.SellerId = id;
            if (seller != null)
            {
                becomeSellerViewModel.Description = seller.Description;
                becomeSellerViewModel.ShortDescription = seller.ShortDescription;
                becomeSellerViewModel.CareerTitle = seller.CareerTitle;
                becomeSellerViewModel.OwnerSkill = seller.SellerMapSkills.ToList();
                ViewBag.Title = "Edit your seller info";
            }
            else
            {
                ViewBag.Title = "Become a seller";
            }
         //   becomeSellerViewModel.Skills = new List<Skill>();
            becomeSellerViewModel.Skills = skills.ToList();
            becomeSellerViewModel.Levels = levelRepository.GetAll();
            return View(becomeSellerViewModel);
        }

        [Authorize(Roles = "User,Seller")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult BecomeSeller(int[] skillID, string shortDescription, string description, int[] level, string careerTitle)
        {
            if (skillID == null || level == null)
            {
                return RedirectToAction("BecomeSeller");
            }
            string sellerid = User.Identity.GetUserId();

            if (sellerRepository.GetSellerByID(sellerid) == null)
            {
                Seller newSeller = new Seller()
                {
                    Description = description,
                    ShortDescription = shortDescription,
                    SellerId = sellerid,
                    CreateAt = DateTime.UtcNow,
                    CareerTitle = careerTitle
                };
                var oldUser = UserManager.FindById(sellerid);
                var oldRoleId = oldUser.Roles.SingleOrDefault().RoleId;
                var oldRoleName = RoleManager.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;
                UserManager.RemoveFromRoles(sellerid, oldRoleName);
                UserManager.AddToRoles(sellerid, "Seller");

                sellerRepository.SaveSeller(newSeller);
            }
            else
            {
                Seller updateSeller = sellerRepository.GetSellerByID(sellerid);
                updateSeller.CareerTitle = careerTitle;
                updateSeller.Description = description;
                updateSeller.ShortDescription = shortDescription;
                sellerRepository.UpdateSeller(updateSeller);
            }

            Seller seller = sellerRepository.GetSellerByID(sellerid);

            List<SellerMapSkill> sellerMaps = new List<SellerMapSkill>();
            for (int i = 0; i < skillID.Length; i++)
            {
                sellerMaps.Add(new SellerMapSkill()
                {
                    SkillId = skillID[i],
                    SellerId = sellerid,
                    LevelId = level[i]
                });
            }

            sellerRepository.UpdateSkill(sellerMaps, seller);
            return RedirectToAction("BecomeSeller");
        }
    }
}