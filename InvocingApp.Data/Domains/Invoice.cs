using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvocingApp.Data.Domains
{
    public class Invoice : BaseEntity
    {
        public DateTime DueDate { get; set; }

        public double? AmountPaid { get; set; }

        public double? Balance { get; set; }

        public bool PaymentStatus { get; set; }

        [StringLength(200), Display(Name = "Note")]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        public long OrderItemId { get; set; }

        public long CustomerId { get; set; }

        public long CompanyId { get; set; }

        public string Code { get; set; }
    }
}
