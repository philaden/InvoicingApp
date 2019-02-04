using InvocingApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Repositories
{
    public interface IProductSevice
    {
        List<Product> GetAllProduct();
        Product GetProductById(long Id);
        void PostCompany(Product product);
        void BulkPostProducts(IEnumerable<Product> products);
        void UpdateProductObject(Product product);
        void UpdateCompanyById(long Id);
        void RemoveProductById(long Id);
    }
}
