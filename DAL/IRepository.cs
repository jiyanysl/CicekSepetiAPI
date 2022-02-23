using CicekSepetiAPI.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepetiAPI.DAL
{
    public interface IRepository<T, in TKey> where T : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(TKey id);
        Task<T> AddAsync(T entity);
    }
}
