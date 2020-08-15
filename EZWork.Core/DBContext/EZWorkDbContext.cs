using EZWork.Core.Entities;
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

        public DbSet<EZUser>  EZUsers{ get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SellerMapSkill> SellerMapSkills { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ReplyComment> ReplyComments { get; set; }
        public DbSet<Contact_AboutMe> Contact_AboutMes { get; set; }
        public DbSet<Payer> Payers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
