using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Areas.Admin.ViewModels
{
    public class ListSkillViewModels
    {
        public List<Skill> Skills { get; set; }
        public List<Career> Careers { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
    public class ActionSkillViewModel {
        public int SkillId { get; set; }
        public int CareerId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public string SkillUrlSlug { get; set; } 
        public List<Career> Careers { get; set; }
    }

}