namespace EZWork.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrder_CardAccount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CardAccounts", "OrderId", "dbo.Orders");
            DropPrimaryKey("dbo.CardAccounts");
            AddPrimaryKey("dbo.CardAccounts", "OrderId");
            AddForeignKey("dbo.CardAccounts", "OrderId", "dbo.Orders", "OrderId");
            DropColumn("dbo.CardAccounts", "CardId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CardAccounts", "CardId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.CardAccounts", "OrderId", "dbo.Orders");
            DropPrimaryKey("dbo.CardAccounts");
            AddPrimaryKey("dbo.CardAccounts", "CardId");
            AddForeignKey("dbo.CardAccounts", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
    }
}
