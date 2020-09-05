namespace EZWork.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLevel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.LevelId);
            
            AddColumn("dbo.SellerMapSkills", "Level_LevelId", c => c.Int());
            CreateIndex("dbo.SellerMapSkills", "Level_LevelId");
            AddForeignKey("dbo.SellerMapSkills", "Level_LevelId", "dbo.Levels", "LevelId");
            DropColumn("dbo.SellerMapSkills", "Level");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SellerMapSkills", "Level", c => c.Int(nullable: false));
            DropForeignKey("dbo.SellerMapSkills", "Level_LevelId", "dbo.Levels");
            DropIndex("dbo.SellerMapSkills", new[] { "Level_LevelId" });
            DropColumn("dbo.SellerMapSkills", "Level_LevelId");
            DropTable("dbo.Levels");
        }
    }
}
