using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindModel;
using NorthwindModel.Interface;
using NorthwindService.Service;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindService.Service.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void AddTest_當產品名已存在時不可新增()
        {
            //Arrange
            IProductRepository stubProductRepo = Substitute.For<IProductRepository>();
            stubProductRepo.GetAll().Returns(new List<Product>() { new Product { ProductName = "BanKey" } });
            var target = new ProductService(stubProductRepo);
            var addProduct = new Product() { ProductName = "BanKey" };

            //Act
            target.Add(addProduct);

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void UpdateTest_更新產品名不可與其它產品同名()
        {
            //Arrange
            IProductRepository stubProductRepo = Substitute.For<IProductRepository>();
            stubProductRepo.GetAll()
                .Returns(
                new List<Product>()
                {
                    new Product { ProductID = 1, ProductName = "BanKey" },
                    new Product { ProductID = 2, ProductName = "KongKey"}
                }
                );
            var target = new ProductService(stubProductRepo);
            var modifyProduct = new Product() { ProductID = 2, ProductName = "BanKey" };

            //Act
            target.Update(modifyProduct);

            //Assert
            Assert.Fail();
        }
    }
}