using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class Rating
    {
        [Key]
        public int RateId { get; set; }
        [Range(1,5)]
        public int? Value { get; set; }

        public virtual Seller Seller { get; set; }
        public virtual EZUser EZUser { get; set; }
    }
}
