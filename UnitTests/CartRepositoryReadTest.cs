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
    public class CartRepositoryReadTest
    {
        private CartService cartService;
        private Mock<IRepository<Cart, string>> repositoryRead;
        [SetUp]
        public void Setup()
        {
            var data = new List<Cart>() {
                new Cart() {Product = new Product() { Name = "Test name1", Price = 1, StockQuantity = 15 }, Quantity = 2, UserId = "1"},
                new Cart() {Product = new Product() { Name = "Test name2", Price = 1, StockQuantity = 1 }, Quantity = 2, UserId = "1"},
                new Cart() {Product = new Product() { Name = "Test name3", Price = 1, StockQuantity = -1 }, Quantity = 2, UserId = "1"},
                new Cart() {Product = new Product() { Name = "Test name4", Price = 1, StockQuantity = 9 }, Quantity = 2, UserId = "1"},
                new Cart() {Product = new Product() { Name = "Test name5", Price = 1, StockQuantity = 12 }, Quantity = 2, UserId = "1"}
            };
            IQueryable<Cart> queryableData = data.AsQueryable();
            repositoryRead = new Mock<IRepository<Cart, string>>();
            repositoryRead.Setup(_ => _.Get(It.IsAny<Expression<Func<Cart, bool>>>()))
            .Returns((Expression<Func<Cart, bool>> filter) => {
                  return filter == null ? queryableData : queryableData.Where(filter);
              });
            cartService = new CartService(repositoryRead.Object);
        }
        /// <summary>
        /// test if there is any product that is out of stock in the cart list
        /// </summary>
        [Test]
        public void TestIsCartHasProductThatIsOutOfStock()
        {
            var product = cartService.Get(c => c.Product.StockQuantity <= 0);
            Assert.NotNull(product.FirstOrDefault());
        }

        /// <summary>
        /// test sum of quantity of the cart list
        /// </summary>
        [Test]
        public void testThereAreNoStockWith15Quantity()
        {
            var cartList = cartService.Get(_ => true);

            var expected = cartList.Sum(x => x.Quantity);
            var actual = 10;
            Assert.AreEqual(expected, actual);
        }
    }
}
