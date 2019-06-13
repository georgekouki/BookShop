namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderAndOrderrowTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Int(nullable: false),
                        CustomerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderRows", "BookId", "dbo.Books");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderRows", new[] { "OrderId" });
            DropIndex("dbo.OrderRows", new[] { "BookId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRows");
        }
    }
}
