﻿using CicekSepetiAPI.Entity;
using CicekSepetiAPI.Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepetiAPI.DAL
{
    public abstract class MongoDbRepositoryBase<T> : IRepository<T, string> where T : MongoDbEntity, new()
    {
        protected readonly IMongoCollection<T> Collection;
        private readonly MongoDbSettings settings;

        protected MongoDbRepositoryBase(IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            var db = client.GetDatabase(this.settings.DatabaseName);
            this.Collection = db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? Collection.AsQueryable()
                : Collection.AsQueryable().Where(predicate);
        }

        public virtual Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefaultAsync();
        }

        public virtual Task<T> GetByIdAsync(string id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await Collection.InsertOneAsync(entity, options);
            return entity;
        }
    }
}
