namespace InvoiceApp.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CartOrderedItemId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 1000),
                        ProductTypeId = c.Long(nullable: false),
                        ImagePath = c.String(),
                        Quantity = c.Long(nullable: false),
                        Discount = c.Double(),
                        UnitPrice = c.Long(nullable: false),
                        CompanyId = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CartItem_Id = c.Long(),
                        Customer_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId, cascadeDelete: true)
                .ForeignKey("dbo.CartItems", t => t.CartItem_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.ProductTypeId)
                .Index(t => t.CompanyId)
                .Index(t => t.CartItem_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductTypeName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        InvoiceId = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Company_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DueDate = c.DateTime(nullable: false),
                        AmountPaid = c.Double(),
                        Balance = c.Double(),
                        PaymentStatus = c.Boolean(nullable: false),
                        Note = c.String(maxLength: 200),
                        OrderItemId = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        CompanyId = c.Long(nullable: false),
                        Code = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.NotificationRecipients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Code = c.String(),
                        Approved = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrdereditemId = c.Guid(nullable: false),
                        CartItemId = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipientReportTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NotificationRecipientId = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReportDatas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        TotalSalesRevenue = c.Double(nullable: false),
                        TotalNumberOfInvoicesIssued = c.Long(nullable: false),
                        TotalQuantityOfProductSold = c.Long(nullable: false),
                        TotalQuantityOfProductBought = c.Long(nullable: false),
                        AmountSpent = c.Long(nullable: false),
                        TotalNumberOfCustomers = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        InvoiceId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReportLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LastReportingTime = c.DateTime(nullable: false),
                        ReportType = c.Int(nullable: false),
                        RecurrenceInterval = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Customers", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Products", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Products", "CartItem_Id", "dbo.CartItems");
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropIndex("dbo.Invoices", new[] { "CompanyId" });
            DropIndex("dbo.Customers", new[] { "Company_Id" });
            DropIndex("dbo.Products", new[] { "Customer_Id" });
            DropIndex("dbo.Products", new[] { "CartItem_Id" });
            DropIndex("dbo.Products", new[] { "CompanyId" });
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            DropTable("dbo.ReportLogs");
            DropTable("dbo.ReportDatas");
            DropTable("dbo.RecipientReportTypes");
            DropTable("dbo.OrderItems");
            DropTable("dbo.NotificationRecipients");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.Companies");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.CartItems");
        }
    }
}
