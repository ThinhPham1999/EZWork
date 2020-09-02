using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class Payer
    {
        [Key]
        public int PayerId { get; set; }
        [Required]
        [StringLength(100)]
        public string PayerAccountNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string PayerAccountName { get; set; }
        [Required]
        [StringLength(255)]
        public string PayerBank { get; set; }
    }
}
