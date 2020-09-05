namespace EZWork.Core.Migrations
{
    using EZWork.Core.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EZWork.Core.DBContext.EZWorkDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EZWork.Core.DBContext.EZWorkDbContext context)
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
                var user = new EZAccount { UserName = "phamquochung23121997@gmail.com" };
                manager.Create(user, "quochung");
                manager.AddToRole(user.Id, "Admin");
            }
            base.Seed(context);
        }
    }
}
