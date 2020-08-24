using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Models
{
    public class PartialHeaderViewModel
    {
        public EZAccount EZAccount { get; set; }
        public EZUser EZUser { get; set; }
    }
}