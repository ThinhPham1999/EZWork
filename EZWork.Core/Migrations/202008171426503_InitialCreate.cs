namespace EZWork.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EZUsers", "Status", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EZUsers", "Status");
        }
    }
}
