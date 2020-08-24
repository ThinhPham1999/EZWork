using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Areas.Admin.Models
{
    public class CareerViewModel
    {
        public int CareerId { get; set; }
        public string CareerName { get; set; }
        public string CareerDescription { get; set; }
        public string CareerUrlSlug { get; set; }
    }
}