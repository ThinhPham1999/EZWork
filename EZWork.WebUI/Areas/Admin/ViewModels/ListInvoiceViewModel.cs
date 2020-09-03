using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Areas.Admin.ViewModels
{
    public class ListInvoiceViewModel
    {
        public List<Order> Orders { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
}