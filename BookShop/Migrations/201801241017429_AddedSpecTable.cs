namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpecTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "SpecId", "dbo.BookSpecializations");
            AddColumn("dbo.Books", "BookSpecialization_Id", c => c.Int());
            AddColumn("dbo.BookSpecializations", "Book_Id", c => c.Int());
            CreateIndex("dbo.Books", "BookSpecialization_Id");
            CreateIndex("dbo.BookSpecializations", "Book_Id");
            AddForeignKey("dbo.BookSpecializations", "Book_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.Books", "BookSpecialization_Id", "dbo.BookSpecializations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "BookSpecialization_Id", "dbo.BookSpecializations");
            DropForeignKey("dbo.BookSpecializations", "Book_Id", "dbo.Books");
            DropIndex("dbo.BookSpecializations", new[] { "Book_Id" });
            DropIndex("dbo.Books", new[] { "BookSpecialization_Id" });
            DropColumn("dbo.BookSpecializations", "Book_Id");
            DropColumn("dbo.Books", "BookSpecialization_Id");
            AddForeignKey("dbo.Books", "SpecId", "dbo.BookSpecializations", "Id", cascadeDelete: true);
        }
    }
}
