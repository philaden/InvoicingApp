using InvocingApp.Data.Domains;
using InvoiceApp.Persistence.Repositories;
using InvoiceApp.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Services
{
    public class InvoiceService
    {
        private IBaseRepository<InvoiceAppDbContext> _baseRepository;
        private IOtherRepository<InvoiceAppDbContext> _otherRepository;

        public InvoiceService(IBaseRepository<InvoiceAppDbContext> baseRepository, IOtherRepository<InvoiceAppDbContext> otherRepository)
        {
            _baseRepository = baseRepository;
            _otherRepository = otherRepository;
        }

        public List<Invoice> GetAllInvoice()
        {
            var listOfInvoice = _baseRepository.Getall<Invoice>().Where(x => !x.IsDeleted && x.IsActive).ToList();
            return listOfInvoice;
        }

        public Invoice GetInvoiceById(long Id)
        {
            if (Id == 0 && Id < 0)
                return null;
            var Invoiceresult = _baseRepository.GetById<Invoice>(Id);
            return Invoiceresult;
        }

        public void PostInvoice(Invoice invoice)
        {
          
        }


        public void UpdateInvoiceById(long Id)
        {
            if (Id == 0 || Id < 0)
                return;
           
        }

        public void RemoveInvoiceById(long Id)
        {
            _baseRepository.Delete<Invoice>(Id);
            var entity = _baseRepository.GetById<Invoice>(Id);
            entity.IsDeleted = true;
            _otherRepository.Save();
        }
    }
}
