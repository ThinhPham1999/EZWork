﻿using EZWork.Core.DBContext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Repository
{
    public class RoleRepository : RoleManager<IdentityRole>
    {
        public RoleRepository(IRoleStore<IdentityRole, string> roleStore)
           : base(roleStore)
        {
        }

        public static RoleRepository Create(IdentityFactoryOptions<RoleRepository> options, IOwinContext context)
        {
            return new RoleRepository(new RoleStore<IdentityRole>(context.Get<EZWorkDbContext>()));
        }
    }
}
