using InvocingApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Repositories
{
    public interface ICompanyService
    {
        List<Company> GetAllCompany();
        Company GetCompanyById(long Id);
        object PostCompany(Company company);
        void BulkPostCompanies(IEnumerable<Company> companies);
        void UpdateCompanyObject(Company company);
        void UpdateCompanyById(long Id);
        void RemoveCompanyById(long Id);
    }
}
