namespace EZWork.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EZWork.Core.DBContext.EZWorkDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EZWork.Core.DBContext.EZWorkDbContext context)
        {
            
        }
    }
}
