using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Models
{
    public class ReviewViewModel
    {
        public string Text { get; set; }
        public string SellerID { get; set; }
        public string ReviewerID { get; set; }
        public int Rate { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}