using CicekSepetiAPI.Helpers;
using CicekSepetiAPI.Models;
using Microsoft.Extensions.Options;

namespace CicekSepetiAPI.DAL.ProductRepo
{
    public class ProductRepository: MongoDbRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IOptions<MongoDbSettings> options): base(options)
        {

        }
    }
}
