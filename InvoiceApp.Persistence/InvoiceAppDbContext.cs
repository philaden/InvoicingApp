using InvocingApp.Data.BusinessDomains;
using InvocingApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence
{
    public class InvoiceAppDbContext : DbContext
    {
        public InvoiceAppDbContext(string nameOrconnectionString) : base(nameOrconnectionString)
        {

        }
        public InvoiceAppDbContext()
        {
            var getdll = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<InvoiceAppDbContext>(null);
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<NotificationRecipient> NotificationRecipient { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ReportLog> ReportLog { get; set; }
        public DbSet<RecipientReportType> RecipientReportType { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<ReportData> ReportData { get; set; }
    }
}

