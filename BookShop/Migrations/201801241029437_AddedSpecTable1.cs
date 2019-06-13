namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpecTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookSpecializations", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Books", "BookSpecialization_Id", "dbo.BookSpecializations");
            DropIndex("dbo.Books", new[] { "SpecId" });
            DropIndex("dbo.Books", new[] { "BookSpecialization_Id" });
            DropIndex("dbo.BookSpecializations", new[] { "Book_Id" });
            DropColumn("dbo.Books", "SpecId");
            RenameColumn(table: "dbo.Books", name: "BookSpecialization_Id", newName: "SpecId");
            AlterColumn("dbo.Books", "SpecId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "SpecId");
            AddForeignKey("dbo.Books", "SpecId", "dbo.BookSpecializations", "Id", cascadeDelete: true);
            DropColumn("dbo.BookSpecializations", "Book_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookSpecializations", "Book_Id", c => c.Int());
            DropForeignKey("dbo.Books", "SpecId", "dbo.BookSpecializations");
            DropIndex("dbo.Books", new[] { "SpecId" });
            AlterColumn("dbo.Books", "SpecId", c => c.Int());
            RenameColumn(table: "dbo.Books", name: "SpecId", newName: "BookSpecialization_Id");
            AddColumn("dbo.Books", "SpecId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookSpecializations", "Book_Id");
            CreateIndex("dbo.Books", "BookSpecialization_Id");
            CreateIndex("dbo.Books", "SpecId");
            AddForeignKey("dbo.Books", "BookSpecialization_Id", "dbo.BookSpecializations", "Id");
            AddForeignKey("dbo.BookSpecializations", "Book_Id", "dbo.Books", "Id");
        }
    }
}
