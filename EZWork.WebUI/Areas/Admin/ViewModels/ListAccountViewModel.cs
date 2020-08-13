using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Areas.Admin.ViewModels
{
    public class ListAccountViewModel
    {
        public List<EZAccount> EZAccounts { get; set; }
        public string searchTerm { get; set; }
        public Pager Pager { get; set; }
    }
}