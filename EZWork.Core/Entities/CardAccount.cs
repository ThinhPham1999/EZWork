using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class CardAccount
    {
        [Required]
        public string CardName { get; set; }
        [Required]
        public string CardCode { get; set; }
        [Required]
        public string BankName { get; set; }
        [Key, ForeignKey("Order")]
        public int OrderId { get; set; }
        [Required]
        public virtual Order Order { get; set; }
    }
}
