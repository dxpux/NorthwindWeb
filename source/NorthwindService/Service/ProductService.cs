using NorthwindModel;
using NorthwindModel.Interface;
using NorthwindService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindService.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Add(Product product)
        {
            if (GetAll().Where(p => p.ProductName == product.ProductName).Any())
            {
                throw new Exception("同名產品已存在");
            }

            this.productRepository.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return this.productRepository.GetAll();
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return this.productRepository.GetAllCategory();
        }

        public IEnumerable<Supplier> GetAllSupplier()
        {
            return this.productRepository.GetAllSupplier();
        }
    }
}
