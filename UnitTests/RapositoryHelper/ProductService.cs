using CicekSepetiAPI.DAL;
using CicekSepetiAPI.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepetiAPI.UnitTests.RapositoryHelper
{
    public class ProductService : IRepository<Product, string>
    {
        readonly IRepository<Product, string> repository;

        public ProductService(IRepository<Product, string> repository)
        {
            this.repository = repository;
        }

        public Task<Product> AddAsync(Product entity)
        {
            return repository.AddAsync(entity);
        }

        public IQueryable<Product> Get(Expression<Func<Product, bool>> predicate = null)
        {
            return repository.Get(predicate);
        }

        public Task<Product> GetAsync(Expression<Func<Product, bool>> predicate)
        {
            return repository.GetAsync(predicate);
        }

        public Task<Product> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
