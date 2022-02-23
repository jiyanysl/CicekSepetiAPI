using CicekSepetiAPI.DAL;
using CicekSepetiAPI.Models;
using CicekSepetiAPI.UnitTests.RapositoryHelper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepetiAPI.UnitTests
{
    [TestFixture]
    public class CartRepositoryInsertTest
    {
        private CartService cartService;
        private Mock<IRepository<Cart, string>> repositoryInsert;
        [SetUp]
        public void Setup()
        {
            var data = new List<Cart>();
            repositoryInsert = new Mock<IRepository<Cart, string>>();
            repositoryInsert.Setup(x => x.AddAsync(It.IsAny<Cart>()))
            .Callback<Cart>((s) => data.Add(s))
            .Returns((Cart model) => Task.FromResult(model));

            cartService = new CartService(repositoryInsert.Object);
        }
        /// <summary>
        /// test if a new Cart can be added
        /// </summary>
        [Test]
        public async Task TestToAddProductToMemory()
        {
            var cart = new Cart() { Product = new Product() { Name = "added cart", Price = 1, StockQuantity = 5 }, Quantity = 1, UserId = "2" };
            var addedCart = await cartService.AddAsync(cart);
            Assert.NotNull(addedCart);
        }
    }
}
