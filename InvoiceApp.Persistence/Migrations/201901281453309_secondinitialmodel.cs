namespace InvoiceApp.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondinitialmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ExpiryDate", c => c.String());
            DropColumn("dbo.Products", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            DropColumn("dbo.Products", "ExpiryDate");
        }
    }
}
