using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Areas.Admin.Models
{
    public class SkillViewModel
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public string SkillUrlSlug { get; set; }
        public int CareerId { get; set; }
      //  public string CareerName { get; set; }
        public List<Career> Careers { get; set; }
    }
}