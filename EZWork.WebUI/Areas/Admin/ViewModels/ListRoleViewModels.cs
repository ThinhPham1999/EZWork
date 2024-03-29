﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Areas.Admin.ViewModels
{
    public class ListRoleViewModels
    {
        public List<IdentityRole> IdentityRoles { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
    public class ActionIdentityRoleViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}