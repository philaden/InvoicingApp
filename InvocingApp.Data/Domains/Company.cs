using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvocingApp.Data.Domains
{
    public class Company : BaseEntity
    {
        [Required, Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
