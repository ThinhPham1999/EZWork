using EZWork.Core.Entities;
using EZWork.Extensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Models
{
    public class SellerViewModel
    {

    }

    public class ListSellerViewModel
    {
        public List<Seller> ViewSellers { get; set; }
        public string SearchTerm { get; set; }
        public List<SkillViewModel> ViewSkills { get; set; }
        public Pager Pager { get; set; }
       
    }

    public class SkillViewModel{
        public Skill Skill { get; set; }
        public bool IsChecked { get; set; }
    }

    public class BecomeSellerViewModel
    {
        public string SellerId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string CareerTitle { get; set; }
        public List<SellerMapSkill> OwnerSkill { get; set; }
        public List<Skill> Skills { get; set; }
    }

    public class BecomeSellerPostView
    {
        public string SellerId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public List<int> SkillIds { get; set; }
    }
}