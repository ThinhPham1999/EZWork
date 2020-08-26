using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
   public class Review
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string SellerID { get; set; }
        public Seller Seller { get; set; }
        public string ReviewerID { get; set; }
       // public EZUser EZUser { get; set; }
        public int Rate { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
