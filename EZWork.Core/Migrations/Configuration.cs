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
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EZWork.Core.DBContext.EZWorkDbContext context)
        {           
            base.Seed(context);
        }
    }
}
