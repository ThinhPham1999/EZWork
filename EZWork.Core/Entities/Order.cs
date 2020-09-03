using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        // [Column(Order = 0)]
        [ForeignKey("Seller")]
        public string SellerId { get; set; }
       // [Column(Order = 1)]
        [ForeignKey("EZUser")]
        public string EZUserId { get; set; }
       
     //   public int CardId { get; set; }
        // [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Range(0,2)]
        public int Status { get; set; }
        public DateTime CreateAt { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual EZUser EZUser { get; set; }
       // public virtual CardAccount CardAccount { get; set; }
    }
}
