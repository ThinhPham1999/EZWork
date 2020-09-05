namespace EZWork.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLevel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SellerMapSkills", "Level_LevelId", "dbo.Levels");
            DropIndex("dbo.SellerMapSkills", new[] { "Level_LevelId" });
            RenameColumn(table: "dbo.SellerMapSkills", name: "Level_LevelId", newName: "LevelId");
            AlterColumn("dbo.SellerMapSkills", "LevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.SellerMapSkills", "LevelId");
            AddForeignKey("dbo.SellerMapSkills", "LevelId", "dbo.Levels", "LevelId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellerMapSkills", "LevelId", "dbo.Levels");
            DropIndex("dbo.SellerMapSkills", new[] { "LevelId" });
            AlterColumn("dbo.SellerMapSkills", "LevelId", c => c.Int());
            RenameColumn(table: "dbo.SellerMapSkills", name: "LevelId", newName: "Level_LevelId");
            CreateIndex("dbo.SellerMapSkills", "Level_LevelId");
            AddForeignKey("dbo.SellerMapSkills", "Level_LevelId", "dbo.Levels", "LevelId");
        }
    }
}
