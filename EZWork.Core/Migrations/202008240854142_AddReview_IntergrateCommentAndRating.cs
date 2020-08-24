namespace EZWork.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReview_IntergrateCommentAndRating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "EZUser_Id", "dbo.EZUsers");
            DropForeignKey("dbo.ReplyComments", "Comment_CommentId", "dbo.Comments");
            DropForeignKey("dbo.ReplyComments", "EZUser_Id", "dbo.EZUsers");
            DropForeignKey("dbo.Comments", "Seller_SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Ratings", "EZUser_Id", "dbo.EZUsers");
            DropForeignKey("dbo.Ratings", "Seller_SellerId", "dbo.Sellers");
            DropIndex("dbo.Comments", new[] { "EZUser_Id" });
            DropIndex("dbo.Comments", new[] { "Seller_SellerId" });
            DropIndex("dbo.ReplyComments", new[] { "Comment_CommentId" });
            DropIndex("dbo.ReplyComments", new[] { "EZUser_Id" });
            DropIndex("dbo.Ratings", new[] { "EZUser_Id" });
            DropIndex("dbo.Ratings", new[] { "Seller_SellerId" });
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        SellerID = c.String(maxLength: 128),
                        ReviewerID = c.String(),
                        Rate = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        EZUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EZUsers", t => t.EZUser_Id)
                .ForeignKey("dbo.Sellers", t => t.SellerID)
                .Index(t => t.SellerID)
                .Index(t => t.EZUser_Id);
            
            DropTable("dbo.Comments");
            DropTable("dbo.ReplyComments");
            DropTable("dbo.Ratings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        Value = c.Int(),
                        EZUser_Id = c.String(maxLength: 128),
                        Seller_SellerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RateId);
            
            CreateTable(
                "dbo.ReplyComments",
                c => new
                    {
                        ReplyCommentId = c.Int(nullable: false, identity: true),
                        CreateAt = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Comment_CommentId = c.Int(),
                        EZUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReplyCommentId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CreateAt = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        EZUser_Id = c.String(maxLength: 128),
                        Seller_SellerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentId);
            
            DropForeignKey("dbo.Reviews", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.Reviews", "EZUser_Id", "dbo.EZUsers");
            DropIndex("dbo.Reviews", new[] { "EZUser_Id" });
            DropIndex("dbo.Reviews", new[] { "SellerID" });
            DropTable("dbo.Reviews");
            CreateIndex("dbo.Ratings", "Seller_SellerId");
            CreateIndex("dbo.Ratings", "EZUser_Id");
            CreateIndex("dbo.ReplyComments", "EZUser_Id");
            CreateIndex("dbo.ReplyComments", "Comment_CommentId");
            CreateIndex("dbo.Comments", "Seller_SellerId");
            CreateIndex("dbo.Comments", "EZUser_Id");
            AddForeignKey("dbo.Ratings", "Seller_SellerId", "dbo.Sellers", "SellerId");
            AddForeignKey("dbo.Ratings", "EZUser_Id", "dbo.EZUsers", "Id");
            AddForeignKey("dbo.Comments", "Seller_SellerId", "dbo.Sellers", "SellerId");
            AddForeignKey("dbo.ReplyComments", "EZUser_Id", "dbo.EZUsers", "Id");
            AddForeignKey("dbo.ReplyComments", "Comment_CommentId", "dbo.Comments", "CommentId");
            AddForeignKey("dbo.Comments", "EZUser_Id", "dbo.EZUsers", "Id");
        }
    }
}
