using EZWork.Core.Entities;
using EZWork.WebUI.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Areas.Admin.Models
{
    public class SellerListViewModel
    {
        public IEnumerable<EZUser> EZUsers { get; set; }
        public IEnumerable<Seller> Sellers { get; set; }
        public IEnumerable<SellerMapSkill> SellerMapSkills { get; set; }
        public IEnumerable<Skill> skills { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int CurrentCategory { get; set; }
    }
}