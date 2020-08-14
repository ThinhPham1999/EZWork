using EZWork.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class ActionAccountRoleViewModel
    {
        public string UserID { get; set; }
        public List<IdentityRole> UserRoles { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}