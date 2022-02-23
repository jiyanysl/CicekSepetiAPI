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
    public class ProductRepositoryInsertTest
    {
        private ProductService productService;
        private Mock<IRepository<Product, string>> repositoryInsert;
        [SetUp]
        public void Setup()
        {
            var data = new List<Product>();
            repositoryInsert = new Mock<IRepository<Product, string>>();
            repositoryInsert.Setup(x => x.AddAsync(It.IsAny<Product>()))
            .Callback<Product>((s) => data.Add(s))
            .Returns((Product model) => Task.FromResult(model));

            productService = new ProductService(repositoryInsert.Object);
        }
        /// <summary>
        /// test if a new Product can be added
        /// </summary>
        [Test]
        public async Task TestToAddProductToMemory()
        {
            var product = new Product() { Name = "added product", Price = 1, StockQuantity = 100 };
            var addedProduct = await productService.AddAsync(product);
            Assert.NotNull(addedProduct);
        }
    }
}
