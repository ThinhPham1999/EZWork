using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using EZWork.Core.Entities;

namespace EZWork.Core.DBContext
{
    public class EZWorkInitializer : CreateDatabaseIfNotExists<EZWorkDbContext>
    {
        protected override void Seed(EZWorkDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin") || !context.Roles.Any(r => r.Name == "User") || !context.Roles.Any(r => r.Name == "Seller"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                var role1 = new IdentityRole { Name = "User" };
                var role2 = new IdentityRole { Name = "Seller" };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "phamquochung23121997@gmail.com"))
            {
                var store = new UserStore<EZAccount>(context);
                var manager = new UserManager<EZAccount>(store);
                var user = new EZAccount { UserName = "phamquochung23121997@gmail.com",Email= "phamquochung23121997@gmail.com" };
                manager.Create(user, "quochung");
                manager.AddToRole(user.Id, "Admin");
            }
            base.Seed(context);
        }
    }
}
