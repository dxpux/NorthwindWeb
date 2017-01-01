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
            stubProductRepo.FindByName("BanKey").Returns(new Product { ProductName = "BanKey" });
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

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void DiscontinuedTest_尚有訂單的產品不能停用()
        {
            //Arrange
            IProductRepository stubProductRepository = Substitute.For<IProductRepository>();
            stubProductRepository.FindByID(2)
                .Returns(
                new Product
                {
                    ProductID = 2,
                    ProductName = "BanKey",
                    UnitsOnOrder = 3,//產品訂單未消
                    Discontinued = false
                }
                );
            var target = new ProductService(stubProductRepository);
            int discontinuedID = 2;

            //Act
            target.Discontinued(discontinuedID);

            //Assert
            Assert.Fail();
        }
    }
}