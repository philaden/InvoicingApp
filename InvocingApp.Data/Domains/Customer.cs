using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvocingApp.Data.Domains
{
    public class Customer : BaseEntity
    {
        public string CustomerName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public long InvoiceId { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
