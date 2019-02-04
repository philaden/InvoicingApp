using InvocingApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Repositories
{
    public interface IInvoiceService
    {
        List<Invoice> GetAllInvoice();
        Invoice GetInvoiceById(long Id);
        void PostInvoice(Invoice invoice);
        void UpdateInvoiceById(long Id);
        void RemoveInvoiceById(long Id);
    }
}
