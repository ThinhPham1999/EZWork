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
        }

        public static EZWorkDbContext Create()
        {
            return new EZWorkDbContext();
        }
        public DbSet<EZUser>  EZUsers{ get; set; }
    }
}
