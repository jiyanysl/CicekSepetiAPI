using CicekSepetiAPI.Helpers;
using CicekSepetiAPI.Models;
using Microsoft.Extensions.Options;

namespace CicekSepetiAPI.DAL.CartRepo
{
    public class CartRepository : MongoDbRepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(IOptions<MongoDbSettings> options) : base(options)
        {

        }
    }
}
