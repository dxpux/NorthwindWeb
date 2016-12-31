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
        public IEnumerable<Product> GetAll()
        {
            return this.productRepository.GetAll();
        }
    }
}
