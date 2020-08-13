using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [Required(ErrorMessage = "Name không được để trống")]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Trình độ không được để trống")]
        [Range(0, Int32.MaxValue)]
        public int Level { get; set; }
        [StringLength(255)]
        public string UrlSlug { get; set; }
    }
}
