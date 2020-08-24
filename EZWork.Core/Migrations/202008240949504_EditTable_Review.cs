namespace EZWork.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTable_Review : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "EZUser_Id", "dbo.EZUsers");
            DropIndex("dbo.Reviews", new[] { "EZUser_Id" });
            DropColumn("dbo.Reviews", "EZUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "EZUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reviews", "EZUser_Id");
            AddForeignKey("dbo.Reviews", "EZUser_Id", "dbo.EZUsers", "Id");
        }
    }
}
