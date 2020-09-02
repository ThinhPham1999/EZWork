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
        [Column(Order = 0)]
        public string SellerId { get; set; }
        [Column(Order = 1)]
        [ForeignKey("EZUser")]
        public string EZUserId { get; set; }
        [Key]
        public int OrderId { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual EZUser EZUser { get; set; }
    }
}
