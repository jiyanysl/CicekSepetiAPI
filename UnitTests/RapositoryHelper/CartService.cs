using CicekSepetiAPI.DAL;
using CicekSepetiAPI.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepetiAPI.UnitTests.RapositoryHelper
{
    public class CartService : IRepository<Cart, string>
    {
        readonly IRepository<Cart, string> repository;

        public CartService(IRepository<Cart, string> repository)
        {
            this.repository = repository;
        }

        public Task<Cart> AddAsync(Cart entity)
        {
            return repository.AddAsync(entity);
        }

        public IQueryable<Cart> Get(Expression<Func<Cart, bool>> predicate = null)
        {
            return repository.Get(predicate);
        }

        public Task<Cart> GetAsync(Expression<Func<Cart, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }

}
