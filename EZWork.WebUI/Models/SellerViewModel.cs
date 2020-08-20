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
        public List<Seller> Sellers { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
    public class ActionSellerSkillViewModel
    {
        public string SearchTerm { get; set; }
        public List<Skill> Skills { get; set; }
    }
}