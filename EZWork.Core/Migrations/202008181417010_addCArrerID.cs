namespace EZWork.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCArrerID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "Career_CareerId", "dbo.Careers");
            DropIndex("dbo.Skills", new[] { "Career_CareerId" });
            RenameColumn(table: "dbo.Skills", name: "Career_CareerId", newName: "CareerId");
            AlterColumn("dbo.Skills", "CareerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Skills", "CareerId");
            AddForeignKey("dbo.Skills", "CareerId", "dbo.Careers", "CareerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "CareerId", "dbo.Careers");
            DropIndex("dbo.Skills", new[] { "CareerId" });
            AlterColumn("dbo.Skills", "CareerId", c => c.Int());
            RenameColumn(table: "dbo.Skills", name: "CareerId", newName: "Career_CareerId");
            CreateIndex("dbo.Skills", "Career_CareerId");
            AddForeignKey("dbo.Skills", "Career_CareerId", "dbo.Careers", "CareerId");
        }
    }
}
