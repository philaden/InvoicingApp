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
    public class ProductService : IProductSevice
    {
        private IBaseRepository<InvoiceAppDbContext> _baseRepository;
        private IOtherRepository<InvoiceAppDbContext> _otherRepository;

        public ProductService(IBaseRepository<InvoiceAppDbContext> baseRepository, IOtherRepository<InvoiceAppDbContext> otherRepository)
        {
            _baseRepository = baseRepository;
            _otherRepository = otherRepository;
        }

        public List<Product> GetAllProduct()
        {
            var listOfProduct = _baseRepository.Getall<Product>().Where(x => !x.IsDeleted && x.IsActive).ToList();
            return listOfProduct;
        }

        public Product GetProductById(long Id)
        {
            if (Id == 0 && Id < 0)
                return null;
            var productresult = _baseRepository.GetById<Product>(Id);
            return productresult;
        }

        public void PostCompany(Product product)
        {
            var existingProduct = GetAllProduct().FirstOrDefault(x => x.Id == product.Id && x.ProductType.ProductTypeName == product.ProductType.ProductTypeName);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Description = product.Description;
                existingProduct.Quantity = product.Quantity;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.ProductType = product.ProductType;
                existingProduct.Discount = product.Discount;

                existingProduct.Modified = DateTime.Now;
            }
            _baseRepository.Create(product);
        }

        public void BulkPostProducts(IEnumerable<Product> products)
        {
            foreach (var prod in products)
            {
                if (GetAllProduct().FirstOrDefault(x => x.Id == prod.Id && x.ProductType.ProductTypeName == prod.ProductType.ProductTypeName) != null)
                    products = null;
            }
            _baseRepository.Create(products);
        }

        public void UpdateProductObject(Product product)
        {
            if (product != null)
                _baseRepository.Update(product);
            _otherRepository.Save();
        }

        public void UpdateCompanyById(long Id)
        {
            if (Id == 0 || Id < 0)
                return;
            _otherRepository.UpdateById<Product>(Id);
            _otherRepository.Save();
        }

        public void RemoveProductById (long Id)
        {
            _baseRepository.Delete<Product>(Id);
            var entity = _baseRepository.GetById<Product>(Id);
            entity.IsDeleted = true;
            _otherRepository.Save();
        }
    }
}
