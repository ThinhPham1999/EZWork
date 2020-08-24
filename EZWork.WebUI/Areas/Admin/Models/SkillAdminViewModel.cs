using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EZWork.Core.Entities;

namespace EZWork.WebUI.Areas.Admin.Models
{
    public class SkillAdminViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(1024)]
        public string Description { get; set; }
        [Required]
        [StringLength(255)]
        public string UrlSlug { get; set; }
        [Required]
        public int CareerId { get; set; }
    }
}