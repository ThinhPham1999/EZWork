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
        [Key]
        [ForeignKey("EZUser")]
        public string SellerId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tóm tắt về bản thân")]
        [StringLength(1024)]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giới thiệu về bản thân")]
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        [Range(0,3)]
        public int Status { get; set; }
        [Range(0,5)]
        public decimal? Rate { get; set; }
        [Range(0, Int32.MaxValue)]
        public int FeedBackCount { get; set; }
        [StringLength(1024)]
        public string CareerTitle { get; set; }

        public virtual EZUser EZUser { get; set; }
        public virtual IList<SellerMapSkill> SellerMapSkills { get; set; }
        // public virtual IList<Rating> Ratings { get; set; }
        public virtual IList<Review> Reviews { get; set; }
        public virtual IList<Order> Orders { get; set; }
    }
}
