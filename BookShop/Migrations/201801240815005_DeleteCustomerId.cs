namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCustomerId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
