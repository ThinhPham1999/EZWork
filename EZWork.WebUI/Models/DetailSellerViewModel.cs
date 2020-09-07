using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Models
{
    public class DetailSellerViewModel
    {
        public Seller Seller { get; set; }
        public List<Review> Reviews { get; set; }
        //public decimal AverageStars { get; set; }
        //public int FeedbackCounts { get; set; }
    }
}