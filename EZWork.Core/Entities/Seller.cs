using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class Seller
    {
        [ForeignKey("EZUser")]
        public string SellerId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tóm tắt về bản thân")]
        [StringLength(1024)]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giới thiệu về bản thân")]
        public string Description { get; set; }
        [Range(0,3)]
        public int Status { get; set; }

        public virtual EZUser EZUser { get; set; }
        public virtual IList<SellerMapSkill> SellerMapSkills { get; set; }
        public virtual IList<Rating> Ratings { get; set; }
    }
}
