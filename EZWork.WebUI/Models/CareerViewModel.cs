using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Models
{
    public class CareerViewModel
    {
        public IEnumerable<Career> Careers { get; set; }
    }
}