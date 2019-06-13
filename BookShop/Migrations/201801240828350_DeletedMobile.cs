namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedMobile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            DropColumn("dbo.AspNetUsers", "Adress");
            DropColumn("dbo.AspNetUsers", "Mobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Mobile", c => c.String());
            AddColumn("dbo.AspNetUsers", "Adress", c => c.String());
            DropColumn("dbo.AspNetUsers", "Address");
        }
    }
}
