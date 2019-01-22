using InvocingApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Configurations
{
    public class InvoiceConfiguration : EntityTypeConfiguration<Customer>
    {
        public InvoiceConfiguration()
        {
            this.HasKey(x => x.Id);
        }
    }
}
