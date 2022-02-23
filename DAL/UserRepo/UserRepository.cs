using CicekSepetiAPI.Helpers;
using CicekSepetiAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace CicekSepetiAPI.DAL.UserRepo
{
    public class UserRepository: MongoDbRepositoryBase<User>, IUserRepository
    {
        //private readonly FilterDefinitionBuilder<User> builder;
        public UserRepository(IOptions<MongoDbSettings> options): base(options)
        {
            //builder = Builders<User>.Filter;
        }

        /// <summary>
        /// Get user by username and password. A custom method for user repository.
        /// </summary>
        ///// <param name="username"></param>
        ///// <param name="password"></param>
        /// <returns></returns>
        //public async Task<User> Authenticate(string username, string password)
        //{
        //    return await Collection.Find(x => x.UserName == username && x.Password == password).FirstOrDefaultAsync();
        //}
    }
}
