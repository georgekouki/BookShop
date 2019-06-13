namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookSpecTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookSpecializations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "SpecId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "SpecId");
            AddForeignKey("dbo.Books", "SpecId", "dbo.BookSpecializations", "Id", cascadeDelete: true);
            DropColumn("dbo.Books", "Specialization");
            DropColumn("dbo.Books", "ProductTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ProductTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Specialization", c => c.String());
            DropForeignKey("dbo.Books", "SpecId", "dbo.BookSpecializations");
            DropIndex("dbo.Books", new[] { "SpecId" });
            DropColumn("dbo.Books", "SpecId");
            DropTable("dbo.BookSpecializations");
        }
    }
}
