using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvocingApp.Data.Domains
{
    public class ReportData : BaseEntity
    {
        public string ProductName { get; set; }
        public double TotalSalesRevenue { get; set; }
        public long TotalNumberOfInvoicesIssued { get; set; }
        public long TotalQuantityOfProductSold  { get; set; }
        public long TotalQuantityOfProductBought { get; set; }
        public long AmountSpent { get; set; }
        public long TotalNumberOfCustomers { get; set; }
        public DateTime Date { get; set; }
        public long InvoiceId { get; set; }
        public long ProductId { get; set; }
    }
}
