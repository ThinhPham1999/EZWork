using EZWork.Core.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.DBContext
{
    public class EZWorkDbContext : IdentityDbContext<EZAccount>
    {
        public EZWorkDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<EZWorkDbContext>(new EZWorkInitializer());
        }


        public static EZWorkDbContext Create()
        {
            return new EZWorkDbContext();
        }

        public DbSet<EZUser> EZUsers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SellerMapSkill> SellerMapSkills { get; set; }
        // public DbSet<Rating> Ratings { get; set; }
        //  public DbSet<Comment> Comments { get; set; }
        //  public DbSet<ReplyComment> ReplyComments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Contact_AboutMe> Contact_AboutMes { get; set; }
        public DbSet<Payer> Payers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CardAccount> CardAccounts { get; set; }
        public DbSet<Level> Levels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        private class EZWorkInitializer : DropCreateDatabaseAlways<EZWorkDbContext>
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
                    manager.Create(role1);
                    manager.Create(role2);
                }

                if (!context.Users.Any(u => u.UserName == "phamquochung23121997@gmail.com"))
                {
                    var store = new UserStore<EZAccount>(context);
                    var manager = new UserManager<EZAccount>(store);
                    var user = new EZAccount {Email= "phamquochung23121997@gmail.com", UserName = "phamquochung23121997@gmail.com" };
                    manager.Create(user, "quochung");
                    manager.AddToRole(user.Id, "Admin");
                }
               // base.Seed(context);
                base.Seed(context);
            }
        }
    }
}
