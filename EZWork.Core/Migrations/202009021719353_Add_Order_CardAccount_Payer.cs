namespace EZWork.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Order_CardAccount_Payer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardAccounts",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        CardName = c.String(nullable: false),
                        CardCode = c.String(nullable: false),
                        BankName = c.String(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        SellerId = c.String(maxLength: 128),
                        EZUserId = c.String(maxLength: 128),
                        OrderId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Sellers", t => t.SellerId)
                .ForeignKey("dbo.EZUsers", t => t.EZUserId)
                .Index(t => t.SellerId)
                .Index(t => t.EZUserId);
            
            AlterColumn("dbo.Payers", "PayerAccountNumber", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Payers", "PayerAccountName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Payers", "PayerBank", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardAccounts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "EZUserId", "dbo.EZUsers");
            DropForeignKey("dbo.Orders", "SellerId", "dbo.Sellers");
            DropIndex("dbo.Orders", new[] { "EZUserId" });
            DropIndex("dbo.Orders", new[] { "SellerId" });
            DropIndex("dbo.CardAccounts", new[] { "OrderId" });
            AlterColumn("dbo.Payers", "PayerBank", c => c.String(maxLength: 255));
            AlterColumn("dbo.Payers", "PayerAccountName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Payers", "PayerAccountNumber", c => c.String(maxLength: 100));
            DropTable("dbo.Orders");
            DropTable("dbo.CardAccounts");
        }
    }
}
