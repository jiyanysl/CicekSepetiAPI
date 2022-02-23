using CicekSepetiAPI.DAL;
using CicekSepetiAPI.Models;
using CicekSepetiAPI.UnitTests.RapositoryHelper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CicekSepetiAPI.UnitTests
{
    [TestFixture]
    public class ProductRepositoryReadTest
    {
        private ProductService productService;
        private Mock<IRepository<Product, string>> repositoryRead;
        [SetUp]
        public void Setup()
        {
            //Mock setup to read products
            var data = new List<Product>() {
                new Product() { Name = "Test name1", Price = 1, StockQuantity = 15 },
                new Product() { Name = "Test name2", Price = 2, StockQuantity = 0 },
                new Product() { Name = "Test name3", Price = 3, StockQuantity = 12 },
                new Product() { Name = "Test name4", Price = 4, StockQuantity = 20 },
                new Product() { Name = "Test name5", Price = 5, StockQuantity = -1 },
            };
            IQueryable<Product> queryableData = data.AsQueryable();
            repositoryRead = new Mock<IRepository<Product, string>>();
            repositoryRead.Setup(_ => _.Get(It.IsAny<Expression<Func<Product, bool>>>()))
            .Returns((Expression<Func<Product, bool>> filter) => {
                  return filter == null ? queryableData : queryableData.Where(filter);
              });
            productService = new ProductService(repositoryRead.Object);
        }
        /// <summary>
        /// test if Product that has 15 quantity is not null
        /// </summary>
        [Test]
        public void TestIsProductWithQuantityIsNotNull()
        {
            var product = productService.Get(x => x.StockQuantity == 15);
            Assert.NotNull(product.FirstOrDefault());
        }

        /// <summary>
        /// test if there is any product that has more 20 quantity
        /// </summary>
        [Test]
        public void TestThereAreNoStockWith15Quantity()
        {
            var product = productService.Get(x => x.StockQuantity > 20);
            
            var expected = product.Count() == 0;
            Assert.True(expected);
        }

        /// <summary>
        /// test if count of products is 5
        /// </summary>
        [Test]
        public void TestCountAllProduct()
        {
            var product = productService.Get(x => x.Name != "");
            var expected = product.Count() == 5;
            Assert.IsTrue(expected);
        }
    }
}
