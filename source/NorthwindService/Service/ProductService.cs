﻿using NorthwindModel;
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
            if (this.productRepository.FindByName(product.ProductName) != null)
            {
                throw new Exception("同名產品已存在");
            }

            this.productRepository.Add(product);
        }

        public void Continued(int productID)
        {
            var product = this.productRepository.FindByID(productID);
            product.Discontinued = false;
            this.productRepository.Update(product);
        }

        public void Discontinued(int productID)
        {
            var product = this.productRepository.FindByID(productID);
            if (product == null) return;
            if (product.UnitsOnOrder > 0)
            {
                throw new Exception("產品尚有訂單，無法停用");
            }

            product.Discontinued = true;
            this.productRepository.Update(product);
        }

        public Product FindByID(int productID)
        {
            return GetAll().Where(p => p.ProductID == productID).FirstOrDefault();
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

        public void Update(Product product)
        {
            if (GetAll()
                .Where(p => 
                p.ProductID != product.ProductID
                && p.ProductName == product.ProductName).Any())
            {
                throw new Exception("更新產品名與其它產品同名");
            }

            this.productRepository.Update(product);
        }
    }
}
