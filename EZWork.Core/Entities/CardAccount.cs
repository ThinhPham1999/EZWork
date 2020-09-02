using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class CardAccount
    {
        [Key]
        public int CardId { get; set; }
        [Required]
        public string CardName { get; set; }
        [Required]
        public string CardCode { get; set; }
        [Required]
        public string BankName { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
