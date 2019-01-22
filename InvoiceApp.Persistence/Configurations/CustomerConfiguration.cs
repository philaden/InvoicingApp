using InvocingApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Configurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            this.HasMany(x => x.Product);
            this.Property(x => x.CustomerName).IsRequired();
        }
    }
}
