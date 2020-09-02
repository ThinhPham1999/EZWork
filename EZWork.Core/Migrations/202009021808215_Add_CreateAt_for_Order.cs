namespace EZWork.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CreateAt_for_Order : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CreateAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CreateAt");
        }
    }
}
