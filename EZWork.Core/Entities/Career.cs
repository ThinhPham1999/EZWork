using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class Career
    {
        [Key]
        public int CareerId { get; set; }
        [Required(ErrorMessage = "Name không được để trống")]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        [StringLength(255)]
        public string UrlSlug { get; set; }
    }
}
