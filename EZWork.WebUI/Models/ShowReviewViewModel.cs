using EZWork.Core.Entities;
using EZWork.WebUI.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Models
{
    public class ShowReviewViewModel
    {
        public List<Review> Reviews { get; set; }
        public Pager Pager { get; set; }
        //public List<ReplyComment> ReplyComments { get; set; }
        //public double AverageRate { get; set; }
    }
}
