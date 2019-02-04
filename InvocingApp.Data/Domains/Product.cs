using InvocingApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvocingApp.Data.Domains
{
    public class Product : BaseEntity
    {
        [Required, StringLength(100), Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required, StringLength(1000), Display(Name = "Product Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public long ProductTypeId { get; set; }

        [Display(Name = "Category")]
        public ProductType ProductType { get; set; }

        public string ExpiryDate { get; set; }

        public long Quantity { get; set; }

        public double? Discount { get; set; }

        [Display(Name ="Price")]
        public long UnitPrice { get; set; }

        public long CompanyId { get; set; }
    }
}
